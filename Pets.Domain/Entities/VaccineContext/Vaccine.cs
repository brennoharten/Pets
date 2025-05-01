using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Vaccine : BaseEntity
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
    }
}