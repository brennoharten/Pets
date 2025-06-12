using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pets.Domain.Enums;
using Pets.Domain.Entities.PetContext;
using Pets.Domain.ValueObjects;
using System.Threading.Tasks;
using Pets.Domain.Specifications;

namespace Pets.Tests.Test
{
    [TestClass]
    public class SpecTests
    {
        [TestMethod]
        public void ShouldReturnTrueWhenSpecialPet()
        {
            var specialPet = new Pet(
                name: new Name("Lucky", "Dog"), 
                identifier: 1,
                age: 1);

            Assert.AreEqual(true, 
                new IsSpecialPet().IsSatisfiedBy(specialPet));
        }
    }
}