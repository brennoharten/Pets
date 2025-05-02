using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Vaccine : BaseEntity, IContract
    {
        public Vaccine(string description, Guid categoryId, Guid petId) : base(description)
        {
            categoryId = categoryId;
            petId = petId;
        }
        public Guid CategoryId { get; private set; }
        public Guid PetId { get; private set; }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
        }

        public override bool Validation()
        {
            var contracts = new ContractValidation<Vaccine>()
                .DescriptionsIsOk(this.Description, 10, 32, "description must be between 5 and 20 characters long.", "Description")
                .IsGuidOk(this.CategoryId, "category id is not valid.", "CategoryId")
                .IsGuidOk(this.PetId, "category id is not valid.", "PetId");

            return contracts.IsValid();
        }
    }
}