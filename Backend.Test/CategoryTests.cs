using Backend.Models;

namespace Backend.Test
{
    public class CategoryTests
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
            var actual = _sut.CreateCategory();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanFillCategory()
        {
            // Arrange
            var expected = _category;

            // Act
            var listOfItems = _sut.FillCategoryWithItems();
            var actual = new Category()
            {
                Name = expected.Name,
                TotalAmount = expected.TotalAmount,
                Items = listOfItems
            };

            // Assert
            Assert.NotNull(actual.Items);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanDeleteCategory()
        {
            // Arrange
            var categoryToDelete = new Category()
            {
                Name = "Category to delete",
                TotalAmount = float.MaxValue,
                Items = _items
            };

            // Act
            _sut.DeleteCategory(categoryToDelete);

            // Assert
            Assert.Null(categoryToDelete);
        }
    }
}
