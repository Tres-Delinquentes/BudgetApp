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

            budget.Income.Items.Add(new Item() { Name = "Lön 1", Amount = 0 });
            budget.Income.Items.Add(new Item() { Name = "Lön 2", Amount = 0 });
            budget.Income.Items.Add(new Item() { Name = "Bostadsbidrag", Amount = 0 });
            budget.Income.Items.Add(new Item() { Name = "Kapital", Amount = 0 });

            budget.Expenses = CreateCategoriesForLargeBudget();

            return budget;
        }

        internal Budget? FetchMediumBudget()
        {
            var budget = new Budget();
            budget.Title = "Medium budget";

            budget.Income.Items.Add(new Item() { Name = "Lön 1", Amount = 0 });
            budget.Income.Items.Add(new Item() { Name = "Lön 2", Amount = 0 });

            budget.Expenses = CreateCategoriesForMediumBudget();

            return budget;
        }

        internal Budget FetchSmallBudget()
        {
            var budget = new Budget();
            budget.Title = "Small budget";
            budget.Income.Items.Add(new Item() { Name = "Lön", Amount = 0 });
            budget.Expenses = CreateCategoriesForSmallBudget();

            return budget;
        }

        private List<Category> CreateCategoriesForSmallBudget()
        {
            var categories = GetBasicCategories();
            return categories;
        }
        private List<Category> CreateCategoriesForMediumBudget()
        {
            var categories = GetBasicCategories();
            GetItemLists("medium");

            if (ItemLists != null && ItemLists.Count >= 6)
            {
                categories.Add(new Category() { Name = "Prenumerationer", Items = ItemLists[6] });
            }
            else
            {
                categories.Add(new Category() { Name = "Prenumerationer" });
            }

            return categories;
        }

        private List<Category> CreateCategoriesForLargeBudget()
        {
            var categories = GetBasicCategories();
            GetItemLists("large");

            if (ItemLists != null && ItemLists.Count >= 7)
            {
                categories.Add(new Category() { Name = "Prenumerationer", Items = ItemLists[6] });
                categories.Add(new Category() { Name = "Nöjen", Items = ItemLists[7] });
            }
            else
            {
                categories.Add(new Category() { Name = "Prenumerationer" });
                categories.Add(new Category() { Name = "Nöjen" });
            }

            return categories;
        }

        private List<Category> GetBasicCategories()
        {
            GetItemLists("small");
            var categories = new List<Category>();

            if (ItemLists != null && ItemLists.Count >= 5)
            {
                categories.Add(new Category() { Name = "Boende", Items = ItemLists[0] });
                categories.Add(new Category() { Name = "Mat", Items = ItemLists[1] });
                categories.Add(new Category() { Name = "Transport", Items = ItemLists[2] });
                categories.Add(new Category() { Name = "Hälsa", Items = ItemLists[3] });
                categories.Add(new Category() { Name = "Skulder & Lån", Items = ItemLists[4] });
                categories.Add(new Category() { Name = "Försäkringar", Items = ItemLists[5] });
            }
            else
            {
                categories.Add(new Category() { Name = "Boende" });
                categories.Add(new Category() { Name = "Mat" });
                categories.Add(new Category() { Name = "Transport" });
                categories.Add(new Category() { Name = "Hälsa" });
                categories.Add(new Category() { Name = "Skulder & Lån" });
                categories.Add(new Category() { Name = "Försäkringar" });
            }


            return categories;
        }

        private void GetItemLists(string sizeOfBudget)
        {
            var boendeItems = new List<Item>();
            var matItems = new List<Item>();
            var transportItems = new List<Item>();
            var halsaItems = new List<Item>();
            var skulderItems = new List<Item>();
            var forsakringarItems = new List<Item>();
            var prenumerationItems = new List<Item>();
            var nojenItems = new List<Item>();

            if (sizeOfBudget.ToLower() == "small" || sizeOfBudget.ToLower() == "medium" || sizeOfBudget.ToLower() == "large")
            {
                boendeItems.Add(new Item() { Name = "Hyra", Amount = 0 });
                boendeItems.Add(new Item() { Name = "El", Amount = 0 });
                boendeItems.Add(new Item() { Name = "Internet", Amount = 0 });

                matItems.Add(new Item() { Name = "Frukost", Amount = 0 });
                matItems.Add(new Item() { Name = "Middagar", Amount = 0 });

                transportItems.Add(new Item() { Name = "Bränsle", Amount = 0 });

                halsaItems.Add(new Item() { Name = "Hygien", Amount = 0 });

                skulderItems.Add(new Item() { Name = "Lån", Amount = 0 });
                skulderItems.Add(new Item() { Name = "Bil", Amount = 0 });
            }

            if (sizeOfBudget.ToLower() == "medium" || sizeOfBudget.ToLower() == "large")
            {
                boendeItems.Add(new Item() { Name = "Värme", Amount = 0 });
                boendeItems.Add(new Item() { Name = "Vatten", Amount = 0 });

                matItems.Add(new Item() { Name = "Lunch", Amount = 0 });
                matItems.Add(new Item() { Name = "Snacks", Amount = 0 });

                transportItems.Add(new Item() { Name = "Busskort 1", Amount = 0 });
                transportItems.Add(new Item() { Name = "Busskort 2", Amount = 0 });

                halsaItems.Add(new Item() { Name = "Kläder", Amount = 0 });
                halsaItems.Add(new Item() { Name = "Gym", Amount = 0 });

                skulderItems.Add(new Item() { Name = "Telefonabonnemang", Amount = 0 });
                skulderItems.Add(new Item() { Name = "Klarna", Amount = 0 });

                prenumerationItems.Add(new Item() { Name = "Netflix", Amount = 0 });
                prenumerationItems.Add(new Item() { Name = "Discovery+", Amount = 0 });
            }

            if (sizeOfBudget.ToLower() == "large")
            {
                boendeItems.Add(new Item() { Name = "Städtjänst", Amount = 0 });
                boendeItems.Add(new Item() { Name = "Sophämtning", Amount = 0 });

                matItems.Add(new Item() { Name = "Dricka", Amount = 0 });
                matItems.Add(new Item() { Name = "Restaurangbesök", Amount = 0 });

                transportItems.Add(new Item() { Name = "Bränsle 2", Amount = 0 });

                halsaItems.Add(new Item() { Name = "Fritidsaktivitet/Sport", Amount = 0 });

                skulderItems.Add(new Item() { Name = "Bil 2", Amount = 0 });
                skulderItems.Add(new Item() { Name = "Lån 2", Amount = 0 });

                prenumerationItems.Add(new Item() { Name = "Viaplay", Amount = 0 });
                prenumerationItems.Add(new Item() { Name = "Kalle Anka", Amount = 0 });

                nojenItems.Add(new Item() { Name = "Bio", Amount = 0 });
            }

            ItemLists.Add(boendeItems);
            ItemLists.Add(matItems);
            ItemLists.Add(transportItems);
            ItemLists.Add(halsaItems);
            ItemLists.Add(skulderItems);
            ItemLists.Add(forsakringarItems);
            ItemLists.Add(prenumerationItems);
            ItemLists.Add(nojenItems);
        }
    }
}
