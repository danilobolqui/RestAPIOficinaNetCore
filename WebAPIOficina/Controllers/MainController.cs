using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAPIOficina.Core.Enum;
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

        protected ActionResult CustomResponse(CustomStatusCode successStatusCode = CustomStatusCode.Ok200,
                                              CustomStatusCode errorStatusCode = CustomStatusCode.BadRequest400,
                                              object? result = null)
        {
            if (OperacaoValida())
            {
                return StatusCode((int)successStatusCode, new
                {
                    success = true,
                    data = result,
                    errors = (object)null!
                });
            }

            return StatusCode((int)errorStatusCode, new
            {
                success = false,
                data = (object)null!,
                errors = _notifier.GetNotifications().Select(n => n.NotificationMessage)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotificarErroModelInvalida(modelState);
            }

            return CustomResponse(CustomStatusCode.Ok200);
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
