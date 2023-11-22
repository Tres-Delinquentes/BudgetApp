using Backend.Models;
using System.Runtime.CompilerServices;

namespace Backend.DAL
{
    internal class BudgetManager
    {
        public Budget SmallBudget { get; set; }
        public Budget MediumBudget { get; set; }
        public Budget LargeBudget { get; set; }

        public BudgetManager()
        {
            SmallBudget = Helpers.BudgetFiller.FetchSmallBudget();
            MediumBudget = Helpers.BudgetFiller.FetchMediumBudget();
            LargeBudget = Helpers.BudgetFiller.FetchLargeBudget();
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
