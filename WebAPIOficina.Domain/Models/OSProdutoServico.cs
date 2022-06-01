using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class OSProdutoServico : Entity
    {
        public Guid Id { get; set; }
        public Guid IdOrdemServico { get; set; }
        public Guid IdProdutoServico { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }

        //FK.
        public virtual OrdemServico OrdemServico { get; set; }  = new OrdemServico();
        public virtual ProdutoServico ProdutoServico { get; set; } = new ProdutoServico();

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
