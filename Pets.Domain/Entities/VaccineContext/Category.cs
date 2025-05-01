using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Category : BaseEntity
    {
        public Category(string description) : base(description)
        {
            
        }
        public string Name { get; private set; }
    }
}