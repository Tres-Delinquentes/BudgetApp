namespace Backend.Core.Interfaces;

public interface ICategoryManager
{
    public bool CheckExpensesOfBudget(IBudget budget);
    public bool CheckIncomeOfBudget(IBudget budget);
    public bool TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(Category category);
    public bool TEST_CheckIfCategorynameIsValid(Category category);

}
