using eDecor.DAO.Entities;
using eDecor.DAO.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace test
{
    /*
     * This class should contain test cases for testing InteriorDecorator Repository 
     * This InteriorDecorator Repository handles InteriorDecorator CRUD Operations 
     * 
     */

    [TestFixture]
    public class TestInteriorDecoratorRepository
    {
        private List<InteriorDecorator> decoratorList;
        private InteriorDecoratorRepository _repo;

        public TestInteriorDecoratorRepository()
        {
            decoratorList = new List<InteriorDecorator>() { };
            _repo = new InteriorDecoratorRepository(decoratorList);
            SetUp();
        }
        public void SetUp()
        {
            // should generate seeddata required for testing
            SeedData();
        }

        #region positive_test_cases

        [Test, Order(2)]
        public void ShouldAddDecoratorReturnId()
        {
            // use Equality Assert

            //Arrange
            var interiorDecorator = new InteriorDecorator(
                "Woods returns",
                20,
                "Experts",
                "Chennai",
                "woods@gmail.com",
                "9876543210"
                );

            //Act
            var id = _repo.AddDecorator(interiorDecorator);
            //var result = _repo.GetDecorator(id);

            //Assert
            //Assert.AreEqual(interiorDecorator1, result);
            Assert.AreEqual(interiorDecorator.Id, id, message: "The id is not added as expected");

        }

        [Test, Order(3)]
        public void ShouldGetDecoratorByIdReturnDecorator()
        {
            // use Identity Assert

            //Arrange
            var interiorDecorator = new InteriorDecorator(
                "Trees",
                10,
                "Amateur",
                "Bangalore",
                "trees@gmail.com",
                "1111111111"
                );

            //Act
            var id = _repo.AddDecorator(interiorDecorator);
            var result = _repo.GetDecorator(id);
            //var result = _repo.GetDecorators();

            //Assert
            Assert.AreSame(interiorDecorator, result, "The objects don't match");
        }

        [Test, Order(1)]
        public void ShouldGetAllDecorators()
        {
            // use Collection Assert

            //Act
            var result = _repo.GetDecorators();

            //Assert
            Assert.IsTrue(result.Count == 4, "All the decorators are not fetched properly");
        }

        [Test, Order(4)]
        [TestCase("Chennai")]
        public void ShouldGetDecoratorsByLocation(string location)
        {
            // use Equality Assert

            //Act
            var result = _repo.GetDecoratorsByLocation(location);
            var decoratorNames = result.ConvertAll(x => x.DecoratorName);

            //Assert
            //Assert.AreEqual("Woods", decoratorNames);
            Assert.Contains("Woods", decoratorNames, "Woods is not actually in Chennai. But the function failed to fetch it");
        }

        [Test, Order(5)]
        [TestCase(20)]
        public void ShouldGetDecoratorsByYearsOfExperience(int years)
        {
            // use Equality Assert

            //Act
            var result = _repo.GetDecoratorsWithMinExperience(years);

            var decoratorNames = result.ConvertAll(x => x.DecoratorName);

            //Assert
            //Assert.AreEqual("Woods", decoratorNames);
            Assert.Contains("Woods", decoratorNames, "Woods is not actually in Chennai. But the function failed to fetch it");
        }

        [Test, Order(6)]
        public void ShouldUpdateDecoratorReturnTrue()
        {
            // use Condition Assert

            //Act
            var newName = "I updated the name for testing!!";
            var interiorDecorator = _repo.GetDecorator(1003);
            interiorDecorator.DecoratorName = newName;
            var result = _repo.UpdateDecorator(1003, interiorDecorator);

            //Assert
            Assert.True(result);
            Assert.IsTrue(interiorDecorator.DecoratorName == newName);
        }

        [Test, Order(7)]
        [TestCase(1003)]
        public void ShouldDeleteDecoratorReturnTrue(int decoratorId)
        {
            // use Condition Assert

            //Act
            var decoratorCount = _repo.GetDecorators().Count;
            var result = _repo.RemoveDecorator(decoratorId);

            //Assert
            Assert.True(result);
            Assert.IsTrue(_repo.GetDecorators().Count == decoratorCount - 1, "The decorator is successfully deleted");
        }

        #endregion


        #region negative_test_cases

        [Test]
        public void ShouldAddDecoratorFailWithInvalidContactNo()
        {
            // use Exception Assert

            //Arrange
            //var interiorDecorator = new InteriorDecorator(
            //    "Trees",
            //    10,
            //    "Amateur",
            //    "Bangalore",
            //    "trees@gmail.com",
            //    "123456789"
            //    );

            //Act & Assert            
            Assert.Throws<InvalidInputException>(() => new InteriorDecorator(
                "Sample",
                10,
                "Amateur",
                "Bangalore",
                "trees@gmail.com",
                "123456789"
                ), "Exception is not thrown properly");            
        }

        [Test]
        public void ShouldAddDecoratorFailWithInvalidExperienceYears()
        {
            // use Exception Assert
            Assert.Throws<InvalidInputException>(() => new InteriorDecorator(
                "Sample",
                -1,
                "Amateur",
                "Bangalore",
                "trees@gmail.com",
                "1234567891"
                ), "Exception is not thrown properly");
        }

        [Test]
        [TestCase(9999)]
        public void ShouldGetDecoratorReturnNullWithInvalidId(int decoratorId)
        {
            // use Condition Assert
            //Act
            var result = _repo.GetDecorator(decoratorId);

            //Assert
            Assert.IsTrue(result == null, "The invalid fetch did not return null");
        }

        [Test]
        [TestCase(500)]
        public void ShouldGetDecoratorWithMinExperienceReturnEmptyList(int years)
        {
            // use Collection Assert

            //Act
            var result = _repo.GetDecoratorsWithMinExperience(years);

            //Assert
            Assert.IsTrue(result.Count == 0, "The return with minimum experience did not return an empty list");
        }

        [Test]
        [TestCase("London")]
        public void ShouldGetDecoratorByLocationReturnEmptyList(string location)
        {
            // use Collection Assert

            //Act
            var result = _repo.GetDecoratorsByLocation(location);

            //Assert
            Assert.IsTrue(result.Count == 0, "The get decorator by location did not return an empty list");
        }

        [Test]
        [TestCase(50)]
        public void ShouldUpdateDecoratorReturnFalse(int decoratorId)
        {
            // use Condition Assert

            //Arrange
            var newInteriorDecorator = new InteriorDecorator(
                    "Sample",
                    30,
                    "Specialists",
                    "Delhi",
                    "hills@gmail.com",
                    "3333333333"
                );

            //Act
            var result = _repo.UpdateDecorator(decoratorId, newInteriorDecorator);

            //Assert
            Assert.False(result, "The update did not fail properly");
        }

        [Test]
        [TestCase(50)]
        public void ShouldDeleteDecoratorReturnFalse(int decoratorId)
        {
            // use Condition Assert

            //Act
            var result = _repo.RemoveDecorator(decoratorId);

            //Assert
            Assert.False(result, "The delete operation did not fail properly");
        }

        #endregion

        #region SeedData

        // declare field to store list of Interior Decorators

        private void SeedData()
        {
            // create list items and populate list of interior decorators

            //Arrange
            var interiorDecorator1 = new InteriorDecorator(
                "Woods",
                20,
                "Experts",
                "Chennai",
                "woods@gmail.com",
                "9876543210"
                );

            //Act
            var result1 = _repo.AddDecorator(interiorDecorator1);

            //Arrange
            var interiorDecorator2 = new InteriorDecorator(
                "Trees",
                10,
                "Amateur",
                "Bangalore",
                "trees@gmail.com",
                "1111111111"
                );

            //Act
            var result2 = _repo.AddDecorator(interiorDecorator2);

            //Arrange
            var interiorDecorator3 = new InteriorDecorator(
                "Plants",
                5,
                "Novice",
                "Mumbai",
                "plants@gmail.com",
                "2222222222"
                );

            //Act
            var result3 = _repo.AddDecorator(interiorDecorator3);

            //Arrange
            var interiorDecorator4 = new InteriorDecorator(
                "Hills",
                30,
                "Specialists",
                "Delhi",
                "hills@gmail.com",
                "3333333333"
                );

            //Act
            var result4 = _repo.AddDecorator(interiorDecorator4);

        }

        #endregion
    }
}
