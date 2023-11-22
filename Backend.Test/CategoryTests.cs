namespace Backend.Test
{
    public class CategoryTests
    {
        private CategoryManager _sut;

        public CategoryTests(CategoryManager categoryManager)
        {
            _sut = categoryManager;
        }

        [Fact]
        public void CanCreateCategoryTemplate()
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
        }
    }
}
