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
    public class VeiculoController : MainController
    {
        private readonly IVeiculoApplication _veiculoApplication;

        public VeiculoController(INotifier notifier, IUser user, IVeiculoApplication veiculoApplication) : base(notifier, user)
        {
            _veiculoApplication = veiculoApplication;
        }

        [HttpGet("search-veiculo-cor")]
        public async Task<ActionResult> SearchVeiculoCor(Guid id)
        {
            var veiculoCor = await _veiculoApplication.SearchVeiculoCorById(id);
            if (veiculoCor == null) return NotFound();
            return CustomResponse(CustomStatusCode.Ok200);
        }

        [HttpPost("add-veiculo-cor")]
        public async Task<ActionResult> AddVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel)
        {
            var guid = await _veiculoApplication.AddVeiculoCor(veiculoCorViewModel);
            return CustomResponse(successStatusCode: CustomStatusCode.Created201, result: guid);
        }

        [HttpPut("update-veiculo-cor")]
        public async Task<ActionResult> UpdateVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel)
        {
            await _veiculoApplication.UpdateVeiculoCor(veiculoCorViewModel);
            return CustomResponse();
        }

        [HttpDelete("remove-veiculo-cor")]
        public async Task<ActionResult> RemoveVeiculoCor(Guid id)
        {
            await _veiculoApplication.RemoveVeiculoCor(id);
            return CustomResponse();
        }
    }
}
