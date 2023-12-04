namespace Backend.Interfaces
{
    public interface IBudgetManager
    {
        public Budget? SmallBudget { get; set; }
        public Budget? MediumBudget { get; set; }
        public Budget? LargeBudget { get; set; }

        public Budget BudgetChecker(Budget budget);

        public bool BudgetIsValid(Budget budget);

        private readonly static BudgetManager? Instance;



    }
}
