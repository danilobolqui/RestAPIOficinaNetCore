using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIOficina.Domain.Notifier
{
    public class Notification
    {
        public Notification(string notificationMessage)
        {
            NotificationMessage = notificationMessage;
        }

        public string NotificationMessage { get; }
    }
}
