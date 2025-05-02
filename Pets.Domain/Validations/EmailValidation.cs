using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pets.Domain.Notifications;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Validations
{
    public partial class ContractValidation<T>
    {
        public ContractValidation<T> EmailIsOk(string email, string message, string propertyName){
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                AddNotification(new Notification(message, propertyName));

            return this;
        }
        
    }
}