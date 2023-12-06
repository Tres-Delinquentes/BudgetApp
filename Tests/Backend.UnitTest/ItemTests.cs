namespace Backend.UnitTest;

public class ItemTests : IClassFixture<ItemFixture>
{
    private readonly ItemManager _sut;

    public ItemTests(ItemFixture itemFixture)
    {
        _sut = itemFixture.ItemManager;
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ValidItems))]
    public void CanValidateItem_ShouldValidateItem_WhenGivenValidDetails(Item validItem)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(validItem);

        // Assert
        Assert.True(actual);

    }


    [Theory]
    [ClassData(typeof(ItemTestData.InvalidPropItems))]
    public void ValidateItem_ShouldThrowArgumentException_WhenGivenInvalidDetails(Item invalidPropItem)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(invalidPropItem));
    }


    [Theory]
    [ClassData(typeof(ItemTestData.BoundaryItems))]
    public void ValidateItem_ShouldHandleBoundaryValue_ForItemAmount(Item boundaryItem)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(boundaryItem);

        // Assert
        Assert.True(actual);
    }



    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithLongName))]
    public void CreateItem_ShoudlThrowException_WhenItemNameExceedsLengthLimit(Item itemWithLongName)
    {
        // Arrange

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithLongName));
        Assert.Contains("Name", ex.Message);
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithLargeAmount))]
    public void ValidateItem_ShouldHandleLargeItemAmounts(Item itemWithLargeAmount)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(itemWithLargeAmount);

        // Assert
        Assert.True(actual);
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithDifferentNames))]
    public void CreateItem_ShouldHandleDifferentNameFormats(Item itemWithDifferentNames)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(itemWithDifferentNames);

        // Assert
        Assert.True(actual);
    }


    [Theory]
    [ClassData(typeof(ItemTestData.InvalidNameItems))]
    public void CreateItem_ShouldNotAllowNamesStartingWithSpecialCharacters(Item itemWithInvalidName)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithInvalidName));
    }

    [Theory]
    [ClassData(typeof(ItemTestData.ItemNamesWithSqlKeywords))]
    public void ItemNameShouldNotBeValidWithSqlKeywords(Item itemWithSqlKeywords)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithSqlKeywords));
    }
}
