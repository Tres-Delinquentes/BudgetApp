using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.DAL
{
    public class ItemManager
    {
        public ItemManager()
        {
            
        }

        public Item CreateItem(string name, float amount) //string amount
        {

            // Trim leading and trailing whitespaces
            name = name?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null, empty, or whitespace.");
            }

            if (name.Length > 50)
            {
                throw new ArgumentException("Name cannot be longer then 50 characters.");
            }

            if (!char.IsLetterOrDigit(name[0]))
            {
                throw new ArgumentException("Name cannot start with a special character.");
            }

            // Regex: Each word must start with an alphanumeric character, underscore, or dash.
            // This allows for whitespace to be inside the string, but not have leading/trailing due to Trim();
            Regex validNameRegex = new(@"^[a-zA-Z0-9-_]+( [a-zA-Z0-9-_]+)*$");
            if(!validNameRegex.IsMatch(name))
            {
                throw new ArgumentException("Name contains invalid characters.");
            }

            // Gör om string till float ifall vi väljer den vägen.
            //float amount = ParseAmount(amountString);

            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be a negative number.");
            }

            return new Item { Name = name, Amount = amount };
        }

        public void DeleteItem()
        {

        }

        public void EditItem()
        {

        }

    }
}
