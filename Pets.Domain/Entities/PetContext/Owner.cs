
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public class Owner : BaseEntity, IContract
    {
        public Owner(Name name,string email, Document document, string documentType) : base(name)
        {
            Email = email;
            Document = document;
        }
        public string Email { get; private set; }
        public Document Document { get; private set; }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public override bool Validation()
        {
            var contracts = new ContractValidation<Owner>()
                .FirstNameIsOk(this.Name, 5, 20, "first name must be between 5 and 20 characters long.", "FirstName")
                .LastNameIsOK(this.Name, 5, 20, "first name must be between 5 and 20 characters long.", "LastName")
                .EmailIsOk(this.Email, "email is not valid.", "Email")
                .DocumentIsOk(this.Document, "document is not valid.", "Document");

            return contracts.IsValid();
        }
    }
}