using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pets.Application.Input.Commands.PetsContexts;
using Pets.Application.Input.Handlers.Interfaces;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.PetContext;
using Pets.Domain.Entities.PetContext;
using Pets.Domain.Notifications;

namespace Pets.Application.Input.Handlers.PetsContext
{
    public class InsertOwnerHandler : IHandlerBase<InsertOwnerCommand>
    {
        private IOwnerRepository _ownerRepository;
        public InsertOwnerHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public IResultBase Handle(InsertOwnerCommand command)
        {
            var owner = new Owner(command.Name, command.Email, command.Document);
            Result result;
            if (owner.Validation())
            {
                try
                {
                    _ownerRepository.InsertOwner(owner);
                    result = new Result(200, $"Owner {owner.Name} successfully registered.", true);

                }
                catch (Exception ex)
                {
                    result = new Result(500, $"An error occurred while registering the owner: {ex.Message}", false);
                }
            }
            result = new Result(400, "Invalid owner data.", false);
            result.SetNotification(owner.Notifications as List<Notification>);
            return result;
        }
    }
}