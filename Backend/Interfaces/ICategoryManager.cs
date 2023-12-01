namespace Backend.Interfaces
{
    public interface ICategoryManager
    {
        public bool CheckCategoriesOfBudget(Budget budget);
        public Category CreateCategory(string name, float amount);

    }
}
