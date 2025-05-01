using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public class Pet : BaseEntity
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
    }
}