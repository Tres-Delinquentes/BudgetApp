using Backend.DAL;
using Backend.Models;

namespace Backend.Test
{
    public class BudgetTests
    {
        [Fact]
        public void UserCanFetchBudgetTemplate() // rename?
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
        public void LargeBudgetGets10Expenses() 
        {
            var expected = 10;

            var sut = new BudgetManager();

            var largerBudget = sut.LargeBudget;

            Assert.Equal(expected, largerBudget.Expenses.Count());
        }

        

    }
}