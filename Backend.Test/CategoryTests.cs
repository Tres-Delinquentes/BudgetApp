using Backend.Models;

namespace Backend.Test
{
    public class CategoryTests : IClassFixture<CategoryManager>
    {
        private CategoryManager _sut;
        private Category _category;
        private List<Item> _items = new List<Item>();

        public CategoryTests(CategoryManager categoryManager)
        {
            
            _sut = categoryManager;
            _category = new Category()
            {
                Name = "",
                TotalAmount = 0,
                Items = new List<Item>()
            };
            _items = new List<Item>()
            {
                new Item{ Name = "", Amount = 0 },
                new Item{ Name = "", Amount = 0 }
            };
            _category.Items = _items;
        }

        [Fact]
        public void CanCreateCategory()
        {
            // Arrange            

            var expected = new Category()
            {
                Name = "",
                TotalAmount = 0,
                Items = new List<Item>()
            };

            // Act
            var actual = _sut.CreateCategory(expected.Name, expected.TotalAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
        }

        //[Fact]
        //public void CanFillCategory()
        //{
        //    // Arrange            
            
        //    var expected = _category;
        //    var name = "Hej";
        //    var amount = 100f;

        //    // Act            
        //    expected.Items.Add(_sut.FillCategoryWithItem(name, amount));

        //    // Assert
        //    Assert.NotNull(expected.Items[0]);
        //    Assert.Equal(expected.Items[2].Name, name);
        //    Assert.Equal(expected.Items[2].Amount, amount);
        //}

        //[Fact]
        //public void CanDeleteCategory()
        //{
        //    // Arrange
        //    var categoryToDelete = new Category()
        //    {
        //        Name = "Category to delete",
        //        TotalAmount = float.MaxValue,
        //        Items = _items
        //    };

        //    // Act
        //    _sut.DeleteCategory(categoryToDelete);

        //    // Assert
        //    Assert.Null(categoryToDelete);
        //}
    }
}
