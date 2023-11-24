using Backend.Models;

namespace Backend.Helpers
{
    internal class BudgetFiller
    {
        internal Budget? FetchLargeBudget()
        {
            var budget = new Budget();
            budget.Title = "Large budget";

            budget.Expenses = CreateCategoriesForLargeBudget();


            return budget;
        }

        internal Budget? FetchMediumBudget()
        {
            var budget = new Budget();
            budget.Title = "Medium budget";

            budget.Expenses = CreateCategoriesForMediumBudget();


            return budget;
        }

        internal Budget FetchSmallBudget()
        {
            var budget = new Budget();
            budget.Title = "Small budget";
            budget.Income.Add(new Item() { Name = "Lön", Amount = 20000 });
            budget.Expenses = CreateCategoriesForSmallBudget();

            return budget;
        }

        private List<Category> CreateCategoriesForSmallBudget()
        {
            var items = new List<Item>()
            {
                new Item { Id = 1, Name = "Hyra", Amount = 100 }
            };

            var categories = new List<Category>();
            categories.Add(new Category() { Name = "Boende", Items = items });
            categories.Add(new Category() { Name = "Mat" });
            categories.Add(new Category() { Name = "Transport" });
            categories.Add(new Category() { Name = "Hälsa" });
            categories.Add(new Category() { Name = "Skulder & Lån" });


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
