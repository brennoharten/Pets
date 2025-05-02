using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public class Pet : BaseEntity, IContract
    {
        public Pet(Name name, int identifier) : base(name)
        {
            Identifier = identifier;
        }
        public int Identifier { get; private set; }

        public void SetIdentifier(int identifier)
        {
            Identifier = identifier;
        }
        public override bool Validation()
        {
            var contracts = new ContractValidation<Pet>()
                .FirstNameIsOk(this.Name, 5, 20, "first name must be between 5 and 20 characters long.", "FirstName")
                .LastNameIsOK(this.Name, 5, 20, "first name must be between 5 and 20 characters long.", "LastName");

            this.SetNotification(contracts.Notifications);

            return contracts.IsValid();
        }
    }
}