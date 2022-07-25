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
    public class VeiculoApplication : ApplicationBase, IVeiculoApplication
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoCorRepository _veiculoCorRepository;

        public VeiculoApplication(INotifier notifier, IMapper mapper, IVeiculoCorRepository veiculoCorRepository) : base(notifier)
        {
            _mapper = mapper;
            _veiculoCorRepository = veiculoCorRepository;
        }

        public async Task<VeiculoCorOtpViewModel> SearchVeiculoCorById(Guid id)
        {
            var veiculoCor = await _veiculoCorRepository.GetById(id);
            return _mapper.Map<VeiculoCorOtpViewModel>(veiculoCor);
        }

        public async Task AddVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel) 
        {
            if (ExecutarValidacao(new VeiculoCorIptViewModelValidation(), veiculoCorViewModel))
            {
                var veiculoCorModel = _mapper.Map<VeiculoCor>(veiculoCorViewModel);

                if (ValidarVeiculoCorNegocio(veiculoCorModel))
                {
                    veiculoCorModel.Id = Guid.NewGuid();
                    await _veiculoCorRepository.Add(veiculoCorModel);
                }
            }
        }

        public async Task UpdateVeiculoCor(VeiculoCorIptViewModel veiculoCorViewModel)
        {
            if (ExecutarValidacao(new VeiculoCorIptViewModelValidation(), veiculoCorViewModel))
            {
                var veiculoCorModel = _mapper.Map<VeiculoCor>(veiculoCorViewModel);

                if (ValidarVeiculoCorNegocio(veiculoCorModel))
                {
                    await _veiculoCorRepository.Update(veiculoCorModel);
                }
            }
        }

        public async Task RemoveVeiculoCor(Guid idVeiculoCor)
        {
             var veiculoCor = (await _veiculoCorRepository.GetById(idVeiculoCor));

            if (veiculoCor != null)
            {
                await _veiculoCorRepository.Remove(veiculoCor);
            }
        }

        private bool ValidarVeiculoCorNegocio(VeiculoCor veiculoCor)
        {
            return true;
        }
    }
}
