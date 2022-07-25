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

            //CreateMap<OrdemServico, OsViewModel>().ReverseMap();

            //CreateMap<OrdemServico, OsCompletaViewModel>()
            //    .ForMember(dest => dest.Os, opt => opt.MapFrom(src => src))
            //    .ForMember(dest => dest.listProdutoServico, opt => opt.MapFrom(src => src.OSProdutoServicos))
            //    .ReverseMap();

            //Exemplos:
            //CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            //CreateMap<ProdutoViewModel, Produto>();
            //CreateMap<Produto, ProdutoViewModel>()
            //.ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}
