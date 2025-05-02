using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Notifications;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Validations
{
    public partial class ContractValidation<T>
    {
        public ContractValidation<T> DescriptionsIsOk(string description, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(description) || description.Length < minLength || description.Length > maxLength)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}