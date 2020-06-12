namespace test
{
    /*
     * This class should contain test cases for testing InteriorDecorator Repository 
     * This InteriorDecorator Repository handles InteriorDecorator CRUD Operations 
     * 
     */

    public class TestInteriorDecoratorRepository
    {
        public void SetUp()
        {
            // should generate seeddata required for testing
        }

        #region positive_test_cases

        public void ShouldAddDecoratorReturnId()
        {
            // use Equality Assert
        }

        public void ShouldGetDecoratorByIdReturnDecorator()
        {
            // use Identity Assert
        }

        public void ShouldGetAllDecorators()
        {
            // use Collection Assert
        }

        public void ShouldGetDecoratorsByLocation(string location)
        {
            // use Equality Assert
        }

        public void ShouldGetDecoratorsByYearsOfExperience(int years)
        {
            // use Equality Assert
        }

        public void ShouldUpdateDecoratorReturnTrue()
        {
            // use Condition Assert
        }

        public void ShouldDeleteDecoratorReturnTrue(int decoratorId)
        {
            // use Condition Assert

        }

        #endregion


        #region negative_test_cases

        public void ShouldAddDecoratorFailWithInvalidContactNo()
        {
            // use Exception Assert
        }

        public void ShouldAddDecoratorFailWithInvalidExperienceYears()
        {
            // use Exception Assert
        }

        public void ShouldGetDecoratorReturnNullWithInvalidId(int decoratorId)
        {
            // use Condition Assert
        }

        public void ShouldGetDecoratorWithMinExperienceReturnEmptyList(int years)
        {
            // use Collection Assert
        }

        public void ShouldGetDecoratorByLocationReturnEmptyList(string location)
        {
            // use Collection Assert
        }

        public void ShouldUpdateDecoratorReturnFalse(int decoratorId)
        {
            // use Condition Assert
        }

        public void ShouldDeleteDecoratorReturnFalse(int decoratorId)
        {
            // use Condition Assert
        }

        #endregion

        #region SeedData

        // declare field to store list of Interior Decorators

        private void SeedData()
        {
            // create list items and populate list of interior decorators
        }

        #endregion
    }
}
