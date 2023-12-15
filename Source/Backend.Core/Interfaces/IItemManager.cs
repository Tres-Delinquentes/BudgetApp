namespace Backend.Core.Interfaces;

public interface IItemManager
{
    public bool CheckIfItemsAreValidInBudget(IBudget budget);
    public bool CheckValidItem(IItem item);

}
