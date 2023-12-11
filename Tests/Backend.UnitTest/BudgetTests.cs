namespace Backend.UnitTest;

public class BudgetTests : IClassFixture<BudgetFixture>
{
    private readonly BudgetManager _sut;
    private readonly Budget? _budget;
    public BudgetTests(BudgetFixture budgetFixture)
    {
        _sut = budgetFixture.BudgetManager; 
        _budget = budgetFixture.Budget;
    }


    [Fact]
    public void BudgetIsValidReturnsValidBudgetWhenGivenValidInformation()
    {
        // Arrange

        // Act
        var actual = _sut.BudgetIsValid(_budget);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void BudgetsGetInitializedWhenCalledOnBudgetManager()
    {
        // Arrange
        // Act
        // Assert
        Assert.NotNull(_sut.SmallBudget);
        Assert.NotNull(_sut.MediumBudget);
        Assert.NotNull(_sut.LargeBudget);
    }

    [Fact]
    public void LargeBudgetGets8CategoriesAsDefault()
    {
        // Arrange
        var expected = 8;

        //Act

        // Assert
        Assert.Equal(expected, _sut.LargeBudget?.Expenses.Count);
    }

    [Fact]
    public void MediumBudgetGets7CategoriesAsDefault()
    {
        // Arrange
        var expected = 7;

        // Act
        // Assert
        Assert.Equal(expected, _sut.MediumBudget?.Expenses.Count);
    }

    [Fact]
    public void SmallBudgetGets6CategoriesAsDefault()
    {
        // Arrange
        var expected = 6;

        // Act
        Assert.Equal(expected, _sut.SmallBudget?.Expenses.Count);
    }
}