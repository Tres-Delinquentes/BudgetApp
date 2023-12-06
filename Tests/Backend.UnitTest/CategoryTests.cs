namespace Backend.UnitTest;

public class CategoryTests : IClassFixture<CategoryFixture>
{
    private readonly CategoryManager _sut;

    public CategoryTests(CategoryFixture categoryFixture)
    {
        
        _sut = categoryFixture.CategoryManager;
    }

    [Theory]
    [ClassData(typeof(CategoryTestData.CheckAmountCategories))]
    public void CategoryTotalAmountIsCalculatedCorrectly(Category category)
    {
        // Arrange     
        // Act
        var actual = _sut.TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(category);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [ClassData(typeof(CategoryTestData.InvalidCategoryAmount))]
    public void WrongCalculationsShouldThrowInvalidOperationException(Category category)
    {
        // Arrage
        //Act
        // Assert
        Assert.Throws<InvalidOperationException>(() => _sut.TEST_CheckCategoryTotalAmountIsCalculatedCorrectly(category));

    }


    [Theory]
    [ClassData(typeof(CategoryTestData.CheckValidNamesOfCategories))]
    public void CheckCategorynameToBeValid(Category category)
    {
        // Arrage
        //Act
        var actual = _sut.TEST_CheckIfCategorynameIsValid(category);

        // Assert
        Assert.True(actual);
    }


    [Theory]
    [ClassData(typeof(CategoryTestData.CheckInvalidNamesOfCategories))]
    public void InvalidNamesShouldThrowArgumentException(Category category)
    {
        // Arrage
        //Act
        // Assert
        Assert.Throws<ArgumentException>(() => _sut.TEST_CheckIfCategorynameIsValid(category));

    }


    [Theory]
    [ClassData(typeof(CategoryTestData.InvalidSqlStringsInCategoryName))]
    public void CheckForSqlKeywordsAndThrowArgumentException(Category category)
    {
        // Arrage
        //Act
        // Assert
        Assert.Throws<ArgumentException>(() => _sut.TEST_CheckIfCategorynameIsValid(category));

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
