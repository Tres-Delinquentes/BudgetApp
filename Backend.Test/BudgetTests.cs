using Backend.DAL;
using Backend.Models;

namespace Backend.Test
{
    public class BudgetTests
    {
        [Fact]
        public void BudgetsGetInitializedWhenCalledOnBudgetManager() // rename?
        {
            // Arrange            
            var sut = new BudgetManager();           

            // Act
            var smallBudget = sut.SmallBudget;
            var mediumBudget = sut.MediumBudget;
            var largeBudget = sut.LargeBudget;

            

            // Assert
            Assert.NotNull(smallBudget);
            Assert.NotNull(mediumBudget);
            Assert.NotNull(largeBudget);
        }

        [Fact]
        public void LargeBudgetGets10CategoriesAsDefault() 
        {
            // Arrange
            var expected = 10;

            var sut = new BudgetManager();

            //Act
            var largerBudget = sut.LargeBudget;

            // Assert
            Assert.Equal(expected, largerBudget.Expenses.Count());
        }

        [Fact]
        public void MediumBudgetGets7CategoriesAsDefault()
        {
            // Arrange
            var expected = 7;
            var sut = new BudgetManager();

            // Act
            var actual = sut.MediumBudget;

            // Assert
            Assert.Equal(expected, actual.Expenses.Count());
        }

        [Fact]
        public void SmallBudgetGets5CategoriesAsDefault()
        {
            // Arrange
            var expected = 5;
            var sut = new BudgetManager();

            // Act
            var actual = sut.SmallBudget;

            // Assert
            Assert.Equal(expected, actual.Expenses.Count());
        }




    }
}