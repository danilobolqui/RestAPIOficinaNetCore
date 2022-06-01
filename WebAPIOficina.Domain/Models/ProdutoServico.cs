using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class ProdutoServico : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Produto { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }

        //FK inversa.
        public virtual ICollection<OSProdutoServico>? OSProdutoServicos { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
