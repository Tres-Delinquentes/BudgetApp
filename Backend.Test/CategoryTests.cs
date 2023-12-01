using Backend.Models;

namespace Backend.Test
{
    public class CategoryTests : IClassFixture<CategoryFixture>
    {
        private CategoryManager _sut;
        private Category _category;

        public CategoryTests(CategoryFixture categoryFixture)
        {
            
            _sut = categoryFixture.CategoryManager;
            _category = categoryFixture.Category;
        }

        [Fact]
        public void GetCorrectTotalAmountFromCategory()
        {
            // Arrange     
            // Act
            var actual = _sut.TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(_category);

            // Assert
            Assert.True(actual);
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
