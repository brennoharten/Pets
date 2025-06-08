using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.PetsRequests
{
    public class OwnerRequests
    {
        public Result Result { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}