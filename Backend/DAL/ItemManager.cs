using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.DAL
{
    public class ItemManager
    {
        public ItemManager()
        {

        }

        public bool CheckIfItemsAreValidInBudget(Budget budget)
        {
            // if no exception is thrown from checkvaliditem, then the items are clear?
            bool isValid = true;
            foreach (var expense in budget.Expenses)
            {
                foreach (var item in expense.Items)
                {
                    var itemToCheck = CheckValidItem(item);
                    item.Name = itemToCheck.Name;
                    item.Amount = itemToCheck.Amount;                        
                }
            }

            return isValid;
        }


        public Item CheckValidItem(Item item) 
        {
            // More checks to se if name contains sql injections? 

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ArgumentException("Name cannot be null, empty, or whitespace." + item.Id.ToString());
            }

            if (item.Name.Length > 50)
            {
                throw new ArgumentException("Name cannot be longer then 50 characters.");
            }

            if (!char.IsLetterOrDigit(item.Name[0]))
            {
                throw new ArgumentException("Name cannot start with a special character.");
            }

            // Regex: Each word must start with an alphanumeric character, underscore, or dash.
            // This allows for whitespace to be inside the string, but not have leading/trailing due to Trim();
            Regex validNameRegex = new(@"^[a-zåäöA-ZÅÄÖ0-9-_]+( [a-zåäöA-ZÅÄÖ0-9-_]+)*$");
            if (!validNameRegex.IsMatch(item.Name))
            {
                throw new ArgumentException("Name contains invalid characters. : " + item.Name);
            }

            // Gör om string till float ifall vi väljer den vägen.
            //float amount = ParseAmount(amountString);

            if (item.Amount < 0)
            {
                throw new ArgumentException("Amount cannot be a negative number.");
            }
            return item;
        }

        public void DeleteItem()
        {

        }

        public void EditItem()
        {

        }

    }
}
