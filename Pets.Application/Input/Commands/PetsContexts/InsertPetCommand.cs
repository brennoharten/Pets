using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Application.Input.Commands.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Application.Input.Commands.PetsContexts
{
    public class InsertPetCommand : ICommandBase
    {
        public Name Name { get; set; }
        public int Age { get; set; }
        public int Identifier { get; set; }
        public Guid OwnerId { get; set; }
    }
}