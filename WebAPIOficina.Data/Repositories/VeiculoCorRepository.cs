using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Data.Context;
using WebAPIOficina.Domain.Models;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Data.Repositories
{
    public class VeiculoCorRepository : RepositoryBase<VeiculoCor>, IVeiculoCorRepository
    {
        public VeiculoCorRepository(WebAPIOficinaDbContext context) : base(context)
        {
        }
    }
}
