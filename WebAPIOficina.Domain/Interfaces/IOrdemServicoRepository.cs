using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Domain.Interfaces
{
    public interface IOrdemServicoRepository : IRepositoryBase<OrdemServico>
    {
        Task AddOsCompleta(OrdemServico osCompleta);
    }
}
