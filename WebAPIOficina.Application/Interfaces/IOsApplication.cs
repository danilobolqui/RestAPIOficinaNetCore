using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.ViewModels;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Application.Interfaces
{
    public interface IOsApplication
    {
        Task<OsCompletaIptViewModel> SearchOsCompletaById(Guid id);
        Task<Guid> AddOsCompleta(OsCompletaIptViewModel osCompletaItpViewModel);
        Task UpdateOsCompleta(OsCompletaIptViewModel osCompletaItpViewModel);
        Task RemoveOsCompleta(Guid id);
    }
}
