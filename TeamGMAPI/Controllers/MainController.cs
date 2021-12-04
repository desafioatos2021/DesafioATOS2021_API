using Base.BUSINESS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamGM.DOMAIN.Interfaces.Helpers;
using TeamGM.DOMAIN.Notifications;

namespace TeamGMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }

        protected bool UsuarioAutenticado { get; set; }

        public MainController(INotificador notificador, IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida() =>
            !_notificador.TemNotificacao();

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarModelStateInvalida(modelState);
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected void NotificarModelStateInvalida(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(c => c.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotificarErro(errorMsg);
            }

        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
        //validação de modelstate

        //validação da operação de negócios
    }
}
