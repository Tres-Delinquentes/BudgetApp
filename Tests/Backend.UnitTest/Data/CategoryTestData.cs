namespace Backend.UnitTest.Data;

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

    public class InvalidCategoryAmount : TheoryData<Category> 
    {
        public InvalidCategoryAmount()
        {
            Add(new Category()
            {
                Id = 1,
                Name = "Test1",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 25 }
                }
            });

            Add(new Category()
            {
                Id = 1,
                Name = "Test1",
                TotalAmount = 1000,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 125 }
                }
            });

        }
        
    }

    public class CheckValidNamesOfCategories : TheoryData<Category> 
    {
        public CheckValidNamesOfCategories()
        {
            Add(new Category()
            {
                Id = 1,
                Name = "Home",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 2,
                Name = "Transportation",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 3,
                Name = "Rent",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
        }
    }

    public class CheckInvalidNamesOfCategories : TheoryData<Category>
    {
        public CheckInvalidNamesOfCategories()
        {
            Add(new Category()
            {
                Id = 1,
                Name = " home ",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 2,
                Name = "@!Transp%rt",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 3,
                Name = "    ---    ",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
        }
    }

    public class InvalidSqlStringsInCategoryName : TheoryData<Category> 
    {
        public InvalidSqlStringsInCategoryName()
        {
            Add(new Category()
            {
                Id = 1,
                Name = "home Delete",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 2,
                Name = "Transport Insert Into",
                TotalAmount = 100,
                Items = new List<Item>()
                {
                    new Item{ Name = "TestItem1", Amount = 50 },
                    new Item{ Name = "TestItem2", Amount = 50 }
                }
            });
            Add(new Category()
            {
                Id = 3,
                Name = "Truncate",
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
