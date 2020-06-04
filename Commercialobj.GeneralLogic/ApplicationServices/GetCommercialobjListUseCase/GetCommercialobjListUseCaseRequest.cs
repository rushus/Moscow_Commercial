using Commercialobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercialobj.ApplicationServices.GetAdmAreaListUseCase
{
    public class GetCommercialobjListUseCaseRequest : IUseCaseRequest<GetCommercialobjListUseCaseResponse>
    {
        public string AdmArea { get; private set; }
        public long? CommercialobjId { get; private set; }

        private GetCommercialobjListUseCaseRequest()
        { }

        public static GetCommercialobjListUseCaseRequest CreateAllCommercialobjsRequest()
        {
            return new GetCommercialobjListUseCaseRequest();
        }

        public static GetCommercialobjListUseCaseRequest CreateCommercialobjRequest(long commercialobjId)
        {
            return new GetCommercialobjListUseCaseRequest() { CommercialobjId = commercialobjId };
        }
        public static GetCommercialobjListUseCaseRequest CreateCommercialobjsRequest(string admarea)
        {
            return new GetCommercialobjListUseCaseRequest() { AdmArea = admarea };
        }
    }
}
