using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class Cliente : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public Guid IdTipoPessoa { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
        public bool Status { get; set; }

        //FK.
        public virtual TipoPessoa TipoPessoa { get; set; } = new TipoPessoa();

        //FK Inversa.
        public virtual ICollection<ClienteVeiculo>? ClienteVeiculos { get; set; }
        public virtual ICollection<OrdemServico>? ClienteDonoAtualOrdemServicos { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
