using Backend.Models;
using System.Runtime.CompilerServices;

namespace Backend.DAL
{
    public class BudgetManager
    {
        private readonly CategoryManager _categoryManager;
        private readonly ItemManager _itemManager;

        public Budget SmallBudget { get; set; }
        public Budget MediumBudget { get; set; }
        public Budget LargeBudget { get; set; }

        public BudgetManager(CategoryManager categoryManager, ItemManager itemManager)
        {
            var helpers = new Helpers.BudgetFiller();
            SmallBudget = helpers.FetchSmallBudget();
            MediumBudget = helpers.FetchMediumBudget();
            LargeBudget = helpers.FetchLargeBudget();
            _categoryManager = categoryManager;
            _itemManager = itemManager;
        }


        public void BudgetChecker(Budget budget)
        {
            // Check all names and all calculations for the budget through the managers?             

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



        }

        private bool BudgetIsValid(Budget budget)
        {
            bool isValid = false;

            return isValid;
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
