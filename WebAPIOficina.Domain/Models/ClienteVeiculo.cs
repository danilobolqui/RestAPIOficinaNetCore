using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class ClienteVeiculo : Entity
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdVeiculoModelo { get; set; }
        public Guid IdVeiculoCor { get; set; }
        public string Placa { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string? Detalhe { get; set; }
        public string? Observacao { get; set; }
        
        //FK.
        public virtual Cliente Cliente { get; set; } = new Cliente();
        public virtual VeiculoModelo VeiculoModelo { get; set; } = new VeiculoModelo();
        public virtual VeiculoCor VeiculoCor { get; set; } = new VeiculoCor();

        //FK invesa.
        public virtual ICollection<OrdemServico>? ClienteVeiculosOrdermServico { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
