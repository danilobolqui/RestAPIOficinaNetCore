using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIOficina.Application.ViewModels
{
    public class OsIptViewModel
    {
        public Guid? Id { get; set; }
        public Guid IdClienteVeiculo { get; set; }
        public Guid IdClienteDonoAtual { get; set; }
        public string Defeito { get; set; } = string.Empty;
        public int? KmEntrada { get; set; }
        public int? KmSaida { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }

    public class OsOtpViewModel
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
    }

    public class OsProdutoServicoIptViewModel
    {
        public Guid? Id { get; set; }
        public Guid? IdOrdemServico { get; set; }
        public Guid IdProdutoServico { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
    }

    public class OsProdutoServicoOtpViewModel
    {
        public Guid Id { get; set; }
        public Guid? IdOrdemServico { get; set; }
        public Guid IdProdutoServico { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
    }

    public class OsCompletaIptViewModel
    {
        public Guid? Id { get; set; }
        public Guid IdClienteVeiculo { get; set; }
        public Guid IdClienteDonoAtual { get; set; }
        public string Defeito { get; set; } = string.Empty;
        public int? KmEntrada { get; set; }
        public int? KmSaida { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        public IEnumerable<OsProdutoServicoIptViewModel>? listProdutoServico { get; set; }
    }

    public class OsCompletaOtpViewModel
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

        public IEnumerable<OsProdutoServicoIptViewModel>? listProdutoServico { get; set; }
    }
}
