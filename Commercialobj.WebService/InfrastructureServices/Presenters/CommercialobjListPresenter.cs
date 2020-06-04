using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using System.Net;
using Newtonsoft.Json;
using Commercialobj.ApplicationServices.Ports;

namespace Commercialobj.InfrastructureServices.Presenters
{
    public class CommercialobjListPresenter : IOutputPort<GetCommercialobjListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public CommercialobjListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetCommercialobjListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Commercialobjs) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
