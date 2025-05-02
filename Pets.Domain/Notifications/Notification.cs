using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Notifications.Interfaces;

namespace Pets.Domain.Notifications
{
    public class Notification : INotification
    {
        public string Message { get; private set; }
        public string Property { get; private set; }
        public Notification(string message, string property)
        {
            Message = message;
            Property = property;
        }
    }
}