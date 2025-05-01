using System;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public abstract class BaseEntity
    {
        public BaseEntity(Name name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedDate = DateTime.UtcNow;
        }
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}