namespace Backend.Interfaces
{
    public interface IItemManager
    {
        public bool CheckIfItemsAreValidInBudget(Budget budget);
        public Item CheckValidItem(Item item);

    }
}
