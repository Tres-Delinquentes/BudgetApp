using Backend.Interfaces;
using Backend.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Backend.DAL
{
    public class CategoryManager : ICategoryManager
    {
        public bool CheckExpensesOfBudget(Budget budget)
        {
            bool isValid = false;
            foreach (var cat in budget.Expenses)
            {
                if (CheckIfCategorynameIsValid(cat))
                {
                    if (CheckCategoryTotalAmountIsCalculatedCorrectly(cat))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
        public bool CheckIncomeOfBudget(Budget budget)
        {
            bool isValid = false;
                if (CheckIfCategorynameIsValid(budget.Income))
                {
                    if (CheckCategoryTotalAmountIsCalculatedCorrectly(budget.Income))
                    {
                        isValid = true;
                    }
                }
            return isValid;
        }

        private bool CheckCategoryTotalAmountIsCalculatedCorrectly(Category category)
        {
            bool isValid = true;
            float categoryCost = 0;
            // do we need or is this set in frontEnd?
            foreach (var item in category.Items)
            {
                categoryCost += item.Amount;
            }

            if (category.TotalAmount != categoryCost)
            {
                throw new InvalidOperationException("Calculations invalid at category cost " + category.Name + " calculations Categorycost: " + categoryCost + " and " + category.TotalAmount + " is not the same.");
            }

            return isValid;
        }

        /// <summary>
        /// THIS IS FOR TESTING CheckCategoryTotalAmountIsCalculatedCorrectly(Budget budget)
        /// </summary>
        /// <param name="Budget"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// 
        public bool TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(Category category)
        {
            bool isValid = true;
            float categoryCost = 0;
            // do we need or is this set in frontEnd?
            foreach (var item in category.Items)
            {
                categoryCost += item.Amount;
            }

            if (category.TotalAmount != categoryCost)
            {
                throw new InvalidOperationException("Calculations invalid at category cost " + category.Name + " calculations Categorycost: " + categoryCost + " and " + category.TotalAmount + " is not the same.");
            }

            return isValid;
        }

        private bool CheckIfCategorynameIsValid(Category category)
        {
            List<string> invalidSqlExpressions = new List<string>() { "Delete", "Insert", "Into", "Alter", "Drop Table", "Select", "Create Database", "Truncate"};

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Name cannot be null, empty, or whitespace." + category.Id.ToString());
            }

            if (category.Name.Length > 50)
            {
                throw new ArgumentException("Name cannot be longer then 50 characters.");
            }

            if (!char.IsLetterOrDigit(category.Name[0]))
            {
                throw new ArgumentException("Name cannot start with a special character.");
            }
            foreach (string sql in invalidSqlExpressions)
            {
                if (category.Name.ToLower().Contains(sql.ToLower()))
                {
                    throw new ArgumentException("Name cannot contain any sql keywords! " + category.Id + " " + category.Name);
                }
            }

            // Regex: Each word must start with an alphanumeric character, underscore, or dash.
            // This allows for whitespace to be inside the string, but not have leading/trailing due to Trim();
            Regex validNameRegex = new(@"^[a-zåäöA-ZÅÄÖ0-9-_]+( [a-zåäöA-ZÅÄÖ0-9-_]+)*$");
            if (!validNameRegex.IsMatch(category.Name))
            {
                throw new ArgumentException("Name contains invalid characters. : " + category.Name);
            }


            return isValid;
        }

        /// <summary>
        /// THIS IS FOR TESTING CheckIfCategorynameIsValid(Budget budget)
        /// </summary>
        /// <param name="Budget"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool TEST_CheckIfCategorynameIsValid(Category category)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Name cannot be null, empty, or whitespace." + category.Id.ToString());
            }

            if (category.Name.Length > 50)
            {
                throw new ArgumentException("Name cannot be longer then 50 characters.");
            }

            if (!char.IsLetterOrDigit(category.Name[0]))
            {
                throw new ArgumentException("Name cannot start with a special character.");
            }

            // Regex: Each word must start with an alphanumeric character, underscore, or dash.
            // This allows for whitespace to be inside the string, but not have leading/trailing due to Trim();
            Regex validNameRegex = new(@"^[a-zåäöA-ZÅÄÖ0-9-_]+( [a-zåäöA-ZÅÄÖ0-9-_]+)*$");
            if (!validNameRegex.IsMatch(category.Name))
            {
                throw new ArgumentException("Name contains invalid characters. : " + category.Name);
            }


            return isValid;
        }
    }
}
