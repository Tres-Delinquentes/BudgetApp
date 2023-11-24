using Backend.Models;

namespace Backend.Helpers
{
    internal class BudgetFiller
    {
        private List<List<Item>> ItemLists = new List<List<Item>>();
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

            GetItemLists();

            var categories = new List<Category>();

            if (ItemLists != null && ItemLists.Count >= 4)
            {
                categories.Add(new Category() { Name = "Boende", Items = ItemLists[0] });
                categories.Add(new Category() { Name = "Mat", Items = ItemLists[1] });
                categories.Add(new Category() { Name = "Transport", Items = ItemLists[2] });
                categories.Add(new Category() { Name = "Hälsa", Items = ItemLists[3] });
                categories.Add(new Category() { Name = "Skulder & Lån", Items = ItemLists[4] });
            }
            else
            {
                categories.Add(new Category() { Name = "Boende" });
                categories.Add(new Category() { Name = "Mat" });
                categories.Add(new Category() { Name = "Transport" });
                categories.Add(new Category() { Name = "Hälsa" });
                categories.Add(new Category() { Name = "Skulder & Lån" });
            }


            return categories;

        }

        private void GetItemLists()
        {

            var boendeItems = new List<Item>()
            {
                new Item() { Name = "Hyra", Amount = 7500 },
                new Item() { Name = "El", Amount = 1250 },
                new Item() { Name = "Internet", Amount = 250 }
            };
            var matItems = new List<Item>()
            {
                new Item() { Name = "Inköp månad", Amount = 6000 },
                new Item() { Name = "Inköp vecka", Amount = 500 }
            };
            var transportItems = new List<Item>()
            {
                new Item() { Name = "Bensin", Amount = 3600 }
            };
            var halsaItems = new List<Item>()
            {
                new Item() { Name = "Gym", Amount = 0 }
            };
            var skulderItems = new List<Item>()
            {
                new Item() { Name = "Stora lånet", Amount = 2700 }
            };

            ItemLists.Add(boendeItems);
            ItemLists.Add(matItems);
            ItemLists.Add(transportItems);
            ItemLists.Add(halsaItems);
            ItemLists.Add(skulderItems);
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
