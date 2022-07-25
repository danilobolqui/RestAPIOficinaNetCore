using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIOficina.Application.Interfaces;
using WebAPIOficina.Application.ViewModels;
using WebAPIOficina.Controllers;
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
            return Ok(veiculoCor);
        }

        [HttpPost("add-veiculo-cor")]
        public async Task<ActionResult> AddVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel)
        {
            await _veiculoApplication.AddVeiculoCor(veiculoCorViewModel);
            return Ok();
        }

        [HttpPut("update-veiculo-cor")]
        public async Task<ActionResult> UpdateVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel)
        {
            await _veiculoApplication.UpdateVeiculoCor(veiculoCorViewModel);
            return Ok();
        }

        [HttpDelete("remove-veiculo-cor")]
        public async Task<ActionResult> RemoveVeiculoCor(Guid id)
        {
            await _veiculoApplication.RemoveVeiculoCor(id);
            return Ok();
        }
    }
}
