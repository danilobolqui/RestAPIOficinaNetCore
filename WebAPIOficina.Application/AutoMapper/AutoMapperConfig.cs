using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.ViewModels;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<VeiculoCorIptViewModel, VeiculoCor>().ReverseMap();
            CreateMap<VeiculoCorOtpViewModel, VeiculoCor>().ReverseMap();

            CreateMap<OsProdutoServicoIptViewModel, OSProdutoServico>().ReverseMap();
            CreateMap<OsCompletaIptViewModel, OrdemServico>()
                .ForMember(dest => dest.OsProdutoServicos, opt => opt.MapFrom(src => src.listProdutoServico))
                .ReverseMap();

            //Exemplos:
            //CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            //CreateMap<ProdutoViewModel, Produto>();
            //CreateMap<Produto, ProdutoViewModel>()
            //.ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}
