namespace Backend.Interfaces
{
    public interface IBudgetFiller
    {
        public Budget? FetchLargeBudget();
        public Budget? FetchMediumBudget();
        public Budget FetchSmallBudget();
    }
}
