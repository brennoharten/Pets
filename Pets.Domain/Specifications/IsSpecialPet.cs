using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.Entities.PetContext;
using Pets.Domain.Specifications.Interfaces;

namespace Pets.Domain.Specifications
{
    public class IsSpecialPet : ISpecification<Pet>
    {
        public bool IsSatisfiedBy(Pet entity)
        {
            return entity.Age > 10 || entity.Age < 2;
        }
    }
}