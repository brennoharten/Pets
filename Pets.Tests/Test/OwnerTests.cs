using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pets.Domain.Enums;
using Pets.Domain.Entities.PetContext;
using Pets.Domain.ValueObjects;

namespace Pets.Tests.Test
{
    [TestClass]
    public class OwnerTests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenNameIsInvalid()
        {
            var owner = new Owner(
                name: new Name("", "Doe"), 
                email: "brucewayne@email.com", 
                document: new Document("900.021.230-88", EDocumentType.CPF));

            Assert.AreEqual(false, owner.Validation());
        }

        [TestMethod]
        public void ShouldReturnFalseWhenEmailIsInvalid()
        {
            var owner = new Owner(
                name: new Name("Bruce", "Wayne"), 
                email: "brucewayneemail.com", 
                document: new Document("900.021.230-88", EDocumentType.CPF));

            Assert.AreEqual(false, owner.Validation());
        }

        [TestMethod]
        public void ShouldReturnFalseWhenDocumentIsInvalid()
        {
            var owner = new Owner(
                name: new Name("Bruce", "Wayne"), 
                email: "brucewayne@email.com", 
                document: new Document("123456789", EDocumentType.CPF));

            Assert.AreEqual(false, owner.Validation());
        }
    }
}