namespace Backend.Core.Interfaces;

public interface ICategoryManager
{
    public bool CheckExpensesOfBudget(Budget budget);
    public bool CheckIncomeOfBudget(Budget budget);
    public bool TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(Category category);
    public bool TEST_CheckIfCategorynameIsValid(Category category);

}
