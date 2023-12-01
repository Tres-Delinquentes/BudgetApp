namespace Backend.Interfaces
{
    public interface ICategoryManager
    {
        public bool CheckExpensesOfBudget(Budget budget);
        public bool CheckIncomeOfBudget(Budget budget);

    }
}
