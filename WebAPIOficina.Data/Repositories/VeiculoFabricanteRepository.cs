using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Data.Context;
using WebAPIOficina.Domain.Interfaces;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Data.Repositories
{
    public class VeiculoFabricanteRepository : RepositoryBase<VeiculoFabricante>, IVeiculoFabricanteRepository
    {
        public VeiculoFabricanteRepository(WebAPIOficinaDbContext context) : base(context)
        {
        }
    }
}
