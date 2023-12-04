using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Runtime.CompilerServices;

namespace Backend.DAL
{
    public class BudgetManager : IBudgetManager
    {
        private static BudgetManager? _instance;
        private readonly CategoryManager _categoryManager;
        private readonly ItemManager _itemManager;

        public Budget? SmallBudget { get; set; }
        public Budget? MediumBudget { get; set; }
        public Budget? LargeBudget { get; set; }

        private BudgetManager(CategoryManager categoryManager, ItemManager itemManager)
        {

            var helpers = new Helpers.BudgetFiller();
            SmallBudget = helpers.FetchSmallBudget();
            MediumBudget = helpers.FetchMediumBudget();
            LargeBudget = helpers.FetchLargeBudget();

            _categoryManager = categoryManager;
            _itemManager = itemManager;


        }


        public Budget BudgetChecker(Budget budget)
        {
            Budget newBudget = new Budget();
            if (budget != null)
            {
                foreach (Category cat in budget.Expenses)
                {
                    foreach (Item item in cat.Items)
                    {
                        item.Name = item.Name.Trim();
                    }
                    cat.Name = cat.Name.Trim();
                }

                if (_itemManager.CheckIfItemsAreValidInBudget(budget) 
                    && _categoryManager.CheckExpensesOfBudget(budget) 
                    && _categoryManager.CheckIncomeOfBudget(budget) 
                    && BudgetIsValid(budget))
                {
                    // Do a pdf and send back?
                }

                return budget;
            }
            return newBudget;

        }

        public bool BudgetIsValid(Budget budget)
        {
            bool isValid = false;

            if (budget.Title is not null && budget.Expenses.Count > 0 && budget.Income.Id is not -1)
            {             
                    isValid = true;
            }

            return isValid;
        }

        public static BudgetManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    // You might want to add locking to ensure thread safety
                    var categoryManager = new CategoryManager();
                    var itemManager = new ItemManager();
                    _instance = new BudgetManager(categoryManager, itemManager);
                }
                return _instance;
            }
        }
    }
}
