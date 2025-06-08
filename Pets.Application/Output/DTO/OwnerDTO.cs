using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Application.Output.DTO
{
    public struct OwnerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
    }
}