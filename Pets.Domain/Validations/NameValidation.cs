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
        public ContractValidation<T> FirstNameIsOk(Name name, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(name.FirstName) || name.FirstName.Length < minLength || name.FirstName.Length > maxLength)
                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidation<T> LastNameIsOK(Name name, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(name.LastName) || name.LastName.Length < minLength || name.LastName.Length > maxLength)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}