using Backend.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Runtime.CompilerServices;

namespace Backend.DAL
{
    public class BudgetManager
    {
        private static BudgetManager _instance;
        private readonly CategoryManager _categoryManager;
        private readonly ItemManager _itemManager;

        public Budget SmallBudget { get; set; }
        public Budget MediumBudget { get; set; }
        public Budget LargeBudget { get; set; }

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
            // Check all names and all calculations for the budget through the managers?
            // 

            foreach (Category cat in budget.Expenses)
            {
                cat.Items.ForEach(item => item.Name.Trim());
                cat.Name.Trim();
            }

            if (_itemManager.CheckIfItemsAreValidInBudget(budget))
            {

                if (_categoryManager.CheckCategoriesOfBudget(budget))
                {
                    if (BudgetIsValid(budget))
                    {
                        // Do a pdf and send back?

                    }
                }
            }




            return budget;

        }

        private bool BudgetIsValid(Budget budget)
        {
            bool isValid = false;

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



        //private Budget FillSmallBudget()
        //{            
        //    return SmallBudget;
        //}
        //private budget FillMediumBudget()
        //{

        //}
        //private void FillLargeBudget()
        //{

        //}





    }
}
