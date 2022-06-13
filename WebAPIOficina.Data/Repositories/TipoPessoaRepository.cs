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
    public class TipoPessoaRepository : RepositoryBase<TipoPessoa>, ITipoPessoaRepository
    {
        public TipoPessoaRepository(WebAPIOficinaDbContext context) : base(context)
        {
        }
    }
}
