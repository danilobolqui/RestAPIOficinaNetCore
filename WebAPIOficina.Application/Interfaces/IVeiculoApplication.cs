using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.ViewModels;

namespace WebAPIOficina.Application.Interfaces
{
    public interface IVeiculoApplication
    {
        Task<VeiculoCorOtpViewModel> SearchVeiculoCorById(Guid id);

        Task<Guid> AddVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel);

        Task UpdateVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel);

        Task RemoveVeiculoCor(Guid idVeiculoCor);
    }
}
