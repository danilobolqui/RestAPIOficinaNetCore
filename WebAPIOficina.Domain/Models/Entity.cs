using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIOficina.Domain.Models
{
    public abstract class Entity
    {
        public abstract bool IsValid();
    }
}
