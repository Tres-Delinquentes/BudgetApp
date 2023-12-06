namespace Backend.Core.Interfaces;

public interface IItemManager
{
    public bool CheckIfItemsAreValidInBudget(Budget budget);
    public bool CheckValidItem(Item item);

}
