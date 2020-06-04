using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Commercialobj.DomainObjects;
using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using Commercialobj.InfrastructureServices.Presenters;

namespace Commercialobj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommercialobjsController : ControllerBase
    {
        private readonly ILogger<CommercialobjsController> _logger;
        private readonly IGetCommercialobjListUseCase _getCommercialobjListUseCase;

        public CommercialobjsController(ILogger<CommercialobjsController> logger,
                                IGetCommercialobjListUseCase getCommercialobjListUseCase)
        {
            _logger = logger;
            _getCommercialobjListUseCase = getCommercialobjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCommercialobjs()
        {
            var presenter = new CommercialobjListPresenter();
            await _getCommercialobjListUseCase.Handle(GetCommercialobjListUseCaseRequest.CreateAllCommercialobjsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{commercialobjId}")]
        public async Task<ActionResult> GetCommercialobj(long commercialobjId)
        {
            var presenter = new CommercialobjListPresenter();
            await _getCommercialobjListUseCase.Handle(GetCommercialobjListUseCaseRequest.CreateCommercialobjRequest(commercialobjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("admarea/{admarea}")]
        public async Task<ActionResult> GetAdmAreaCommercialobjs(string admarea)
        {
            var presenter = new CommercialobjListPresenter();
            await _getCommercialobjListUseCase.Handle(GetCommercialobjListUseCaseRequest.CreateCommercialobjsRequest(admarea), presenter);
            return presenter.ContentResult;
        }
    }
}
