using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.DOMAIN.Notifications;

namespace TeamGM.DOMAIN.Interfaces.Helpers
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);

    }
}
