using System.Threading.Tasks;
using System.Collections.Generic;
using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using Commercialobj.ApplicationServices.Ports;

namespace Commercialobj.ApplicationServices.GetAdmAreaListUseCase
{
    public class GetCommercialobjListUseCase : IGetCommercialobjListUseCase
    {
        private readonly IReadOnlyCommercialobjRepository _readOnlyCommercialobjRepository;

        public GetCommercialobjListUseCase(IReadOnlyCommercialobjRepository readOnlyCommercialobjRepository) 
            => _readOnlyCommercialobjRepository = readOnlyCommercialobjRepository;
        
        public async Task<bool> Handle(GetCommercialobjListUseCaseRequest request, IOutputPort<GetCommercialobjListUseCaseResponse> outputPort)
        {
            IEnumerable<commercialobj> commercialobjs = null;
            if (request.CommercialobjId != null)
            {
                var commercialobj = await _readOnlyCommercialobjRepository.GetCommercialobj(request.CommercialobjId.Value);
                commercialobjs = (commercialobj != null) ? new List<commercialobj>() { commercialobj } : new List<commercialobj>();
                
            }
            else if (request.AdmArea != null)
            {
                commercialobjs = await _readOnlyCommercialobjRepository.QueryCommercialobjs(new AdmAreaCriteria(request.AdmArea));
            }
            else
            {
                commercialobjs = await _readOnlyCommercialobjRepository.GetAllCommercialobjs();
            }
            outputPort.Handle(new GetCommercialobjListUseCaseResponse(commercialobjs));
            return true;
        }
    }
}
