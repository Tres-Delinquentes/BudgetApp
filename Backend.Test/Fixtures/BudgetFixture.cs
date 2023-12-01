using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class BudgetFixture
    {
        public BudgetManager BudgetManager { get; set; }

        public Budget Budget { get; set; }

        public BudgetFixture()
        {
            BudgetManager = BudgetManager.Instance;
            Budget = BudgetManager.SmallBudget;
        }
    }
}
