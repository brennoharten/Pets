using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public abstract class BaseEntity : IValidations
    {
        private List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public BaseEntity(string description)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Description = description;
            
        }
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public virtual void SetDescription(string description)
        {
            Description = description;
        }
        public abstract bool Validation();
        protected void SetNotification(IReadOnlyCollection<Notification> notifications)
        {
            _notifications = (List<Notification>)notifications;
        }
    }
}