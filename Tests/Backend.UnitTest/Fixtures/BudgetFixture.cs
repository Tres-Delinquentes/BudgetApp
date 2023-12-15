namespace Backend.UnitTest;

public class BudgetFixture
{
    public BudgetManager BudgetManager { get; set; }

    public Budget? Budget { get; set; }

    public BudgetFixture()
    {
        ICategoryManager categoryManager = new CategoryManager();
        IItemManager itemManager = new ItemManager();
        BudgetManager = new BudgetManager(categoryManager, itemManager);
        Budget = BudgetManager.SmallBudget;
    }
}
