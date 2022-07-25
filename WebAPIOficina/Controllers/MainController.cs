using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAPIOficina.Domain.Interfaces;
using WebAPIOficina.Domain.Notifier;

namespace WebAPIOficina.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUser _appUser;

        protected Guid UsuarioId { get; set; }
        protected bool AuthenticatedUser { get; set; }

        public MainController(INotifier notifier, IUser appUser)
        {
            _notifier = notifier;
            _appUser = appUser;

            if (_appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                AuthenticatedUser = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.NotificationMessage)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotificarErroModelInvalida(modelState);
            }

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notifier.AddNotification(new Notification(mensagem));
        }
    }
}
