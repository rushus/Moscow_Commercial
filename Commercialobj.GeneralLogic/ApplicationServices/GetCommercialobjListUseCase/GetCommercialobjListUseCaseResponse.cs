using Commercialobj.DomainObjects;
using Commercialobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercialobj.ApplicationServices.GetAdmAreaListUseCase
{
    public class GetCommercialobjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<commercialobj> Commercialobjs { get; }

        public GetCommercialobjListUseCaseResponse(IEnumerable<commercialobj> commercialobjs) => Commercialobjs = commercialobjs;
    }
}
