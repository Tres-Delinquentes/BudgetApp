using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test.Data
{
    public class ItemTestData
    {
        public class ValidItems : TheoryData<Item>
        {
            public ValidItems()
            {
                Add(new Item() { Name = "Salary", Amount = 3000f });
            }
        }

        public class BoundaryItems : TheoryData<Item>
        {
            public BoundaryItems()
            {
                Add(new Item() { Name = "BoundaryTestItem", Amount = 0f });
            }
        }

        public class InvalidPropItems : TheoryData<Item>
        {
            public InvalidPropItems()
            {
                Add(new Item() { Name = "", Amount = 10f });
                Add(new Item() { Name = "Mat", Amount = -1f });
            }
        }

        public class ItemsWithLongName : TheoryData<Item>
        {
            public ItemsWithLongName()
            {
                Add(new Item() { Name = new string('a', 51), Amount = 100f });
            }
        }

        public class ItemsWithLargeAmount : TheoryData<Item>
        {
            public ItemsWithLargeAmount()
            {
                Add(new Item() { Name = "LargeAmountItem", Amount = 1e6f });
            }
        }

        public class ItemsWithDifferentNames : TheoryData<Item>
        {
            public ItemsWithDifferentNames()
            {
                Add(new Item() { Name = "Item1", Amount = 100f });
                Add(new Item() { Name = "ITEM_UPPERCASE", Amount = 100f });
                Add(new Item() { Name = "item lowercase", Amount = 100f });
            }
        }
        public class InvalidNameItems : TheoryData<Item>
        {
            public InvalidNameItems()
            {
                Add(new Item() { Name = "#InvalidName", Amount = 100f });
                Add(new Item() { Name = "!AnotherInvalid", Amount = 100f });
                Add(new Item() { Name = "@NotValid", Amount = 100f });
            }
        }
        public class ItemNamesWithSqlKeywords : TheoryData<Item> 
        {
            public ItemNamesWithSqlKeywords()
            {
                Add(new Item() { Name = "Hyra Delete database", Amount = 100f });
                Add(new Item() { Name = "Drop table", Amount = 100f });
                Add(new Item() { Name = "Alter", Amount = 100f });
            }
        }

    }
}
