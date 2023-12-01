using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class CategoryFixture
    {
        public CategoryManager CategoryManager { get; set; } = new CategoryManager();
        public Category Category { get; set; }

        public CategoryFixture()
        {
            var items = new List<Item>()
            {
                new Item{ Name = "TestItem1", Amount = 50 },
                new Item{ Name = "TestItem2", Amount = 50 }
            };
            Category = new Category()
            {
                Name = "TestCategory",
                TotalAmount = 100,
                Items = items
            };
        }
    }
}
