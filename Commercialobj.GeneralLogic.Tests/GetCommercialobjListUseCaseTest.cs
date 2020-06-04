using Commercialobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using System.Linq.Expressions;
using Commercialobj.ApplicationServices.Ports;
using Commercialobj.DomainObjects.Ports;
using Commercialobj.ApplicationServices.Repositories;

namespace Commercialobj.WebService.Core.Tests
{
    public class GetCommercialobjListUseCaseTest
    {
        private InMemoryCommercialobjRepository CreateCommercialobjRepository()
        {
            var repo = new InMemoryCommercialobjRepository(new List<commercialobj> {
                new commercialobj { Id = 1, District = "район Кузьминки", Name = "Цветы на Юных Ленинцев, вл.53"},
                new commercialobj { Id = 2, District = "район Текстильщики", Name = "Хлеб на Артюхиной ул. 7"},
                new commercialobj { Id = 3, District = "район Хамовники", Name = "Театральные билеты на Малый Чудов пер., вл. 8"},
                new commercialobj { Id = 4, District = "район Хамовники", Name = "Мороженое на Комсомольский просп., вл. 23-25"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllCommercialobj()
        {
            var useCase = new GetCommercialobjListUseCase(CreateCommercialobjRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetCommercialobjListUseCaseRequest.CreateAllCommercialobjsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Commercialobjs.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Commercialobjs.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllCommercialobjsFromEmptyRepository()
        {
            var useCase = new GetCommercialobjListUseCase(new InMemoryCommercialobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetCommercialobjListUseCaseRequest.CreateAllCommercialobjsRequest(), outputPort).Result);
            Assert.Empty(outputPort.Commercialobjs);
        }

        [Fact]
        public void TestGetCommercialobj()
        {
            var useCase = new GetCommercialobjListUseCase(CreateCommercialobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetCommercialobjListUseCaseRequest.CreateCommercialobjRequest(2), outputPort).Result);
            Assert.Single(outputPort.Commercialobjs, pn => 2 == pn.Id);
        }

        [Fact]
        public void TestTryGetNotExistingCommercialobj()
        {
            var useCase = new GetCommercialobjListUseCase(CreateCommercialobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetCommercialobjListUseCaseRequest.CreateCommercialobjRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Commercialobjs);
        }
      
    }

    class OutputPort : IOutputPort<GetCommercialobjListUseCaseResponse>
    {
        public IEnumerable<commercialobj> Commercialobjs { get; private set; }

        public void Handle(GetCommercialobjListUseCaseResponse response)
        {
            Commercialobjs = response.Commercialobjs;
        }
    }
}
