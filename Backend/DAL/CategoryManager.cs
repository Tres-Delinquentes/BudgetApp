using Backend.Models;
using System.Text.RegularExpressions;

namespace Backend.DAL
{
    public class CategoryManager
    {       
        public bool CheckCategoriesOfBudget(Budget budget)
        {
            bool isValid = false;
            if (CheckIfCategorynameIsValid(budget))
            {
                if (CheckCategoryTotalAmountIsCalculatedCorrectly(budget))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
       
        public Category CreateCategory(string name, float amount)
        {
            var newCategory = new Category(){ Name = name, TotalAmount = amount, Items = new List<Item>()};
            return newCategory;
        }

        //public Item FillCategoryWithItem(string name, float totalAmount)
        //{
        //    var itemManager = new ItemManager();
        //    var item = itemManager.CreateItem(name, totalAmount);

        //    return item;
        //}

        private bool CheckCategoryTotalAmountIsCalculatedCorrectly(Budget budget)
        {            
            bool isValid = true;
            // do we need or is this set in frontEnd?
            foreach (Category cat in budget.Expenses)
            {
                float categoryCost = 0;
                cat.Items.ForEach(item => categoryCost += item.Amount);
                if (cat.TotalAmount != categoryCost)
                {
                    throw new InvalidOperationException("Calculations invalid at category cost " + cat.Name + " calculations Categorycost: " + categoryCost + " and " + cat.TotalAmount + " is not the same.");
                }
            }

            return isValid;
        }

        private bool CheckIfCategorynameIsValid(Budget budget)
        {
            bool isValid = true;
            foreach (Category cat in budget.Expenses)
            {
                cat.Name = cat.Name.Trim();

                if (string.IsNullOrWhiteSpace(cat.Name))
                {
                    throw new ArgumentException("Name cannot be null, empty, or whitespace." + cat.Id.ToString());
                }

                if (cat.Name.Length > 50)
                {
                    throw new ArgumentException("Name cannot be longer then 50 characters.");
                }

                if (!char.IsLetterOrDigit(cat.Name[0]))
                {
                    throw new ArgumentException("Name cannot start with a special character.");
                }

                // Regex: Each word must start with an alphanumeric character, underscore, or dash.
                // This allows for whitespace to be inside the string, but not have leading/trailing due to Trim();
                Regex validNameRegex = new(@"^[a-zåäöA-ZÅÄÖ0-9-_]+( [a-zåäöA-ZÅÄÖ0-9-_]+)*$");
                if (!validNameRegex.IsMatch(cat.Name))
                {
                    throw new ArgumentException("Name contains invalid characters. : " + cat.Name);
                }
            }

            return isValid;
        }
    }
}
