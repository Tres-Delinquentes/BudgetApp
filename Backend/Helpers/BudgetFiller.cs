using Backend.Models;

namespace Backend.Helpers
{
    internal class BudgetFiller
    {
        internal  Budget? FetchLargeBudget()
        {
            var budget = new Budget();
            budget.Expenses = CreateCategoriesForLargeBudget();


            return budget;
        }

        internal  Budget? FetchMediumBudget()
        {
            var budget = new Budget();
            budget.Expenses = CreateCategoriesForMediumBudget();


            return budget;
        }

        internal Budget FetchSmallBudget()
        {
            var budget = new Budget();
            budget.Expenses = CreateCategoriesForSmallBudget();

            return budget;
        }

        private List<Category> CreateCategoriesForSmallBudget()
        {
            var categories = new List<Category>();
            categories.Add(new Category(){ Name = "Boende"});
            categories.Add(new Category(){ Name = "Mat"});
            categories.Add(new Category(){ Name = "Transport"});
            categories.Add(new Category(){ Name = "Hälsa"});
            categories.Add(new Category(){ Name = "Skulder & Lån"});
                
            
            return categories;
            
        }

        private List<Category> CreateCategoriesForMediumBudget()
        {
            var categories = new List<Category>();
            categories.Add(new Category() { Name = "Boende" });
            categories.Add(new Category() { Name = "Mat" });
            categories.Add(new Category() { Name = "Transport" });
            categories.Add(new Category() { Name = "Hälsa" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });


            return categories;

        }

        private List<Category> CreateCategoriesForLargeBudget()
        {
            var categories = new List<Category>();
            categories.Add(new Category() { Name = "Boende" });
            categories.Add(new Category() { Name = "Mat" });
            categories.Add(new Category() { Name = "Transport" });
            categories.Add(new Category() { Name = "Hälsa" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });
            categories.Add(new Category() { Name = "Skulder & Lån" });


            return categories;

        }


    }
}
