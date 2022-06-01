using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class OrdemServico : Entity
    {
        public Guid Id { get; set; }
        public Guid IdClienteVeiculo { get; set; }
        public Guid IdClienteDonoAtual { get; set; }
        public string Defeito { get; set; } = string.Empty;
        public int? KmEntrada { get; set; }
        public int? KmSaida { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        //FK.
        public virtual ClienteVeiculo ClienteVeiculo { get; set; } = new ClienteVeiculo();
        public virtual Cliente ClienteDonoAtual { get; set; } = new Cliente();

        //FK inversa.
        public virtual ICollection<OSProdutoServico>? OSProdutoServicos { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
