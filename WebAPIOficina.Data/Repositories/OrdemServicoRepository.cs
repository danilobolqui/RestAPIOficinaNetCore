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
    public class OrdemServicoRepository : RepositoryBase<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(WebAPIOficinaDbContext context) : base(context)
        {
        }

        public async Task AddOsCompleta(OrdemServico osCompleta)
        {
            ///***
            ///Não precisaria criar este método, já que poderia ser tratado os Id's na camada de negócios.
            ///A ideia seria exemplificar uma transação com várias tabelas, mesmo que neste caso não seja necessário.
            ///***

            //Id OS.
            osCompleta.Id = Guid.NewGuid();

            //Id dos item da OS.
            if (osCompleta.OsProdutoServicos != null)
            {
                foreach (var item in osCompleta.OsProdutoServicos)
                {
                    item.Id = new Guid();
                    item.IdOrdemServico = osCompleta.Id;
                }
            }

            //Add.
            DbSet.Add(osCompleta);

            //SaveChanges.
            await SaveChanges();
        }
    }
}
