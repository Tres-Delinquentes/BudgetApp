using Backend.DAL;
using Backend.Models;

namespace Backend.Test
{
    public class BudgetTests
    {
        [Fact]
        public void BudgetReturnsValid()
        {
            // Arrange
            var itemManager = new ItemManager();
            var categoryManager = new CategoryManager();
            var sut = BudgetManager.Instance;
            var budget = new Budget()
            {
                Title = "BudgetTest",
                Income = new Category()
                {
                    Name = "IncomeTest",
                    TotalAmount = 0,
                    Items = new List<Item> { new Item() { Name = "TestItemInIncome", Amount = 0, Id = 0 } }
                },
                Expenses = new List<Category>() { new Category()
                {
                    Name = "ExpensesTest",
                    TotalAmount = 0,
                    Items = new List<Item> { new Item() { Name = "TestItemInExpenses", Amount = 0, Id = 0 } }
                } }
            };

            // Act
            var actual = sut.BudgetIsValid(budget);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void BudgetsGetInitializedWhenCalledOnBudgetManager() // rename?
        {
            // Arrange
            var itemManager = new ItemManager();
            var categoryManager = new CategoryManager();
            var sut = BudgetManager.Instance;

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
        public void LargeBudgetGets8CategoriesAsDefault()
        {
            // Arrange
            var expected = 8;
            var itemManager = new ItemManager();
            var categoryManager = new CategoryManager();
            var sut = BudgetManager.Instance;

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
            var itemManager = new ItemManager();
            var categoryManager = new CategoryManager();
            var sut = BudgetManager.Instance;

            // Act
            var actual = sut.MediumBudget;

            // Assert
            Assert.Equal(expected, actual.Expenses.Count());
        }

        [Fact]
        public void SmallBudgetGets6CategoriesAsDefault()
        {
            // Arrange
            var expected = 6;
            var itemManager = new ItemManager();
            var categoryManager = new CategoryManager();
            var sut = BudgetManager.Instance;

            // Act
            var actual = sut.SmallBudget;

            // Assert
            Assert.Equal(expected, actual.Expenses.Count());
        }




    }
}