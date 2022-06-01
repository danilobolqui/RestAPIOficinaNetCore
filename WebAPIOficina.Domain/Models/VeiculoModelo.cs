using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class VeiculoModelo : Entity
    {
        public Guid Id { get; set; }
        public Guid IdVeiculoFabricante { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Status { get; set; }

        //FK.
        public virtual VeiculoFabricante VeiculoFabricante { get; set; } = new VeiculoFabricante();

        //FK Inversa.
        public virtual ICollection<ClienteVeiculo>? ClientesVeiculo { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
