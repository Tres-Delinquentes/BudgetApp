using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test.Data
{
    public class CategoryTestData
    {
        //public static List<Item> GetValidItems()
        //{
        //    var list = new List<Item>()
        //    {
        //        new Item() { Id = 1, Name = "TestItem1", Amount = 100},
        //        new Item() { Id = 1, Name = "TestItem2", Amount = 50},
        //        new Item() { Id = 1, Name = "TestItem3", Amount = 200}
        //    };
        //    return list;
        //}


        public class CheckAmountCategories : TheoryData<Category>
        {
            public CheckAmountCategories()
            {
                Add(new Category()
                {
                    Id = 1,
                    Name = "Test1",
                    TotalAmount = 100,
                    Items = new List<Item>()
                    {
                        new Item{ Name = "TestItem1", Amount = 50 },
                        new Item{ Name = "TestItem2", Amount = 50 }
                    }
                });
            }
        }
    }
}
