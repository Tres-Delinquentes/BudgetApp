using Backend.Interfaces;
using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.DAL
{
    public class ItemManager : IItemManager
    {
        public ItemManager()
        {

        }

        public bool CheckIfItemsAreValidInBudget(Budget budget)
        {
            budget.Expenses.ForEach(x => x.Items.ForEach(z => CheckValidItem(z)));           
             
            return true;
        }


        public bool CheckValidItem(Item item) 
        {
            List<string> invalidSqlExpressions = new List<string>() { "Delete", "Insert", "Into", "Alter", "Drop Table", "Select", "Create Database", "Truncate" };

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

            foreach (string sql in invalidSqlExpressions.Where(sql => item.Name.ToLower().Contains(sql.ToLower())))
            {
                throw new ArgumentException("Name cannot contain any sql keywords! " + item.Id + " " + item.Name);
            }
            

            // Regex: Each word must start with an alphanumeric character, underscore, or dash.
            Regex validNameRegex = new Regex(@"^[a-zåäöA-ZÅÄÖ0-9-_]+( [a-zåäöA-ZÅÄÖ0-9-_]+)*$", RegexOptions.None, TimeSpan.FromMilliseconds(2000));
            if (!validNameRegex.IsMatch(item.Name))
            {
                throw new ArgumentException("Name contains invalid characters. : " + item.Name);
            }
            

            if (item.Amount < 0)
            {
                throw new ArgumentException("Amount cannot be a negative number.");
            }

            return true;
        }
    }
}
