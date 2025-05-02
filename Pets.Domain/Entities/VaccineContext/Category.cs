using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Category : BaseEntity, IContract
    {
        public Category(string description) : base(description)
        {
        }

        public override bool Validation()
        {
            var contracts = new ContractValidation<Category>()
                .DescriptionsIsOk(this.Description, 5, 20, "description must be between 5 and 20 characters long.", "Description");

            return contracts.IsValid();
        }
    }
}