using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIOficina.Application.ViewModels
{
    /// <summary>
    /// ViewModel para input veículo cor.
    /// </summary>
    public class VeiculoCorIptViewModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public bool Status { get; set; }
    }

    /// <summary>
    /// ViewModel para output veículo cor.
    /// </summary>
    public class VeiculoCorOtpViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
