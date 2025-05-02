using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Notifications;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Validations
{
    public partial class ContractValidation<T> where T : IContract
    {
        private List<Notification> _notifications;
        public ContractValidation()
        {
            _notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public IReadOnlyCollection<Notification> ExportNotifications()
        {
            return _notifications.AsReadOnly();
        }
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
        public bool IsValid()
        {
            return _notifications.Count == 0 ? true : false;
        }
    }
}