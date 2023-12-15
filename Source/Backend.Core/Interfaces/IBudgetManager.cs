namespace Backend.Core.Interfaces;

public interface IBudgetManager
{
    public Budget? SmallBudget { get; set; }
    public Budget? MediumBudget { get; set; }
    public Budget? LargeBudget { get; set; }
    public static IBudgetManager Instance
    {
        get; 
    }


    public IBudget BudgetChecker(IBudget budget);

    public bool BudgetIsValid(IBudget budget);        

}
