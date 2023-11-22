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
            var helpers = new Helpers.BudgetFiller();
            SmallBudget = helpers.FetchSmallBudget();
            MediumBudget = helpers.FetchMediumBudget();
            LargeBudget = helpers.FetchLargeBudget();
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
