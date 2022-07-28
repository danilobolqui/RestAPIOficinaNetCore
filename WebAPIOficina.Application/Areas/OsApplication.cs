using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.Areas.Base;
using WebAPIOficina.Application.Interfaces;
using WebAPIOficina.Application.Validation.ViewModel;
using WebAPIOficina.Application.ViewModels;
using WebAPIOficina.Domain.Interfaces;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Application.Areas
{
    public class OsApplication : ApplicationBase, IOsApplication
    {
        private readonly IMapper _mapper;
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OsApplication(INotifier notifier, IMapper mapper, IOrdemServicoRepository ordemServicoRepository) : base(notifier)
        {
            _mapper = mapper;
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<OsCompletaIptViewModel> SearchOsCompletaById(Guid id)
        {
            var osCompleta = await _ordemServicoRepository.GetById(id);
            return _mapper.Map<OsCompletaIptViewModel>(osCompleta);
        }

        public async Task<Guid> AddOsCompleta(OsCompletaIptViewModel osCompletaItpViewModel)
        {
            if (ExecutarValidacao(new OsCompletaIptViewModelValidation(), osCompletaItpViewModel))
            {
                var osModel = _mapper.Map<OrdemServico>(osCompletaItpViewModel);

                if (ValidarOsNegocio(osModel))
                {
                    await _ordemServicoRepository.AddOsCompleta(osModel);
                    return osModel.Id;
                }
            }

            return Guid.Empty;
        }

        public async Task UpdateOsCompleta(OsCompletaIptViewModel osCompletaItpViewModel)
        {
            if (ExecutarValidacao(new OsCompletaIptViewModelValidation(), osCompletaItpViewModel))
            {
                var osModel = _mapper.Map<OrdemServico>(osCompletaItpViewModel);

                if (ValidarOsNegocio(osModel))
                {
                    await _ordemServicoRepository.Update(osModel);
                }
            }
        }

        public async Task RemoveOsCompleta(Guid id)
        {
            var osCompleta = (await _ordemServicoRepository.GetById(id));

            if (osCompleta != null)
            {
                await _ordemServicoRepository.Remove(osCompleta);
            }
        }

        private bool ValidarOsNegocio(OrdemServico os)
        {
            return true;
        }
    }
}
