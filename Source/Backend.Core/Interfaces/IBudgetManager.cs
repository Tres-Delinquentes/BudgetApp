namespace Backend.Core.Interfaces;

public interface IBudgetManager
{
    public Budget? SmallBudget { get; set; }
    public Budget? MediumBudget { get; set; }
    public Budget? LargeBudget { get; set; }

    public bool BudgetChecker(Budget budget);

    public bool BudgetIsValid(Budget budget);        

}
