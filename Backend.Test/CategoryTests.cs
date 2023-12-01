using Backend.Models;
using Backend.Test.Data;

namespace Backend.Test
{
    public class CategoryTests : IClassFixture<CategoryFixture>
    {
        private CategoryManager _sut;

        public CategoryTests(CategoryFixture categoryFixture)
        {
            
            _sut = categoryFixture.CategoryManager;
        }

        [Theory]
        [ClassData(typeof(CategoryTestData.CheckAmountCategories))]
        public void GetCorrectTotalAmountFromCategory(Category category)
        {
            // Arrange     
            // Act
            var actual = _sut.TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(category);

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
