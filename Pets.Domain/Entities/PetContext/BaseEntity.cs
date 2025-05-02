using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public abstract class BaseEntity : IValidations 
    {
        private List<Notification> _notifications;
        public BaseEntity(Name name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedDate = DateTime.UtcNow;
        }
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        protected void SetNotification(IReadOnlyCollection<Notification>notifications)
        {
            _notifications = (List<Notification>)notifications;
        }
        
        public abstract bool Validation();
    }
}