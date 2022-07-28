using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIOficina.Application.Interfaces;
using WebAPIOficina.Application.ViewModels;
using WebAPIOficina.Controllers;
using WebAPIOficina.Core.Enum;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class OsController : MainController
    {
        private readonly IOsApplication _osApplication;

        public OsController(INotifier notifier, IUser user, IOsApplication osApplication) : base(notifier, user)
        {
            _osApplication = osApplication;
        }

        [HttpGet("search-os-completa")]
        public async Task<ActionResult> SearchVeiculoCor(Guid id)
        {
            var osCompleta = await _osApplication.SearchOsCompletaById(id);
            return CustomResponse(result: osCompleta);
        }

        [HttpPost("add-os-completa")]
        public async Task<ActionResult> AddOsCompleta(OsCompletaIptViewModel osCompletaIptModel)
        {
            var guid = await _osApplication.AddOsCompleta(osCompletaIptModel);
            return CustomResponse(successStatusCode: CustomStatusCode.Created201, result: guid);
        }

        [HttpPut("update-os-completa")]
        public async Task<ActionResult> UpdateOsCompleta(OsCompletaIptViewModel osCompletaIptModel)
        {
            await _osApplication.UpdateOsCompleta(osCompletaIptModel);
            return CustomResponse();
        }

        [HttpDelete("remove-os-completa")]
        public async Task<ActionResult> RemoveOsCompleta(Guid id)
        {
            await _osApplication.RemoveOsCompleta(id);
            return CustomResponse();
        }
    }
}
