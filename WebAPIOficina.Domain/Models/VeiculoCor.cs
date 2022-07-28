using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Interfaces;

namespace WebAPIOficina.Domain.Models
{
    public class VeiculoCor : Entity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Status { get; set; }

        //FK inversa.
        public virtual ICollection<ClienteVeiculo>? ClientesVeiculo { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
