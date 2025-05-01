
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetContext
{
    public class Owner : BaseEntity
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
    }
}