using eDecor.DAO.Entities;
using NUnit.Framework;

namespace test
{
    /*
     * This test class should test the InteriorDecorator Model 
     * 
     */

    [TestFixture]
    public class TestInteriorDecoratorModel
    {
        //Should Test Model for its type and properties
        [Test]
        public void ShouldTestInteriorDecoratorModel()
        {
            //Arrange
            var interior = new InteriorDecorator(
                "Woods",
                2,
                "Experts",
                "Chennai",
                "woods@gmail.com",
                "9876543210"
                );

            //Act
            interior.SetId(1002);
            
            //Assert
            Assert.IsAssignableFrom<InteriorDecorator>(interior, "The value is not of type InteriorDecorator");
            Assert.IsAssignableFrom<int>(interior.Id, "The value is not of expected");
            Assert.IsAssignableFrom<string>(interior.DecoratorName, "The value is not of expected");
            Assert.IsAssignableFrom<int>(interior.YearsOfExperience, "The value is not of expected");
            Assert.IsAssignableFrom<string>(interior.Expertise, "The value is not of expected");
            Assert.IsAssignableFrom<string>(interior.Location, "The value is not of expected");
            Assert.IsAssignableFrom<string>(interior.Email, "The value is not of expected");
            Assert.IsAssignableFrom<string>(interior.ContactNo, "The value is not of expected");
        }

    }
}
