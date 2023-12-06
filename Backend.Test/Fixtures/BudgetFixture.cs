namespace Backend.UnitTest;

public class BudgetFixture
{
    public BudgetManager BudgetManager { get; set; }

    public Budget? Budget { get; set; }

    public BudgetFixture()
    {
        BudgetManager = BudgetManager.Instance;
        Budget = BudgetManager.SmallBudget;
    }
}
