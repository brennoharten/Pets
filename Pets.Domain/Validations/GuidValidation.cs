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
        public ContractValidation<T> IsGuidOk(Guid guid, string message, string propertyName)
        {
            if (guid == Guid.Empty)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}