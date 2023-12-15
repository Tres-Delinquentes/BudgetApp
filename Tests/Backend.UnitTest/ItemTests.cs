namespace Backend.UnitTest;

public class ItemTests : IClassFixture<ItemFixture>
{
    private readonly IItemManager _sut;

    public ItemTests(ItemFixture itemFixture)
    {
        _sut = itemFixture.ItemManager;
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ValidItems))]
    public void CheckValidItemShouldValidateItemWhenGivenValidInformation(Item validItem)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(validItem);

        // Assert
        Assert.True(actual);

    }


    [Theory]
    [ClassData(typeof(ItemTestData.InvalidPropItems))]
    public void CheckValidItemShouldThrowArgumentExceptionWhenGivenInvalidInformation(Item invalidPropItem)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(invalidPropItem));
    }


    [Theory]
    [ClassData(typeof(ItemTestData.BoundaryItems))]
    public void CheckValidItemShouldHandleBoundryValues(Item boundaryItem)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(boundaryItem);

        // Assert
        Assert.True(actual);
    }



    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithLongName))]
    public void CheckValidItemShouldThrowArgumentExceptionWhenItemsHaveTooLongNames(Item itemWithLongName)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithLongName));
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithLargeAmount))]
    public void CheckValidItemShouldHandleLargeAmountsCorrectly(Item itemWithLargeAmount)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(itemWithLargeAmount);

        // Assert
        Assert.True(actual);
    }


    [Theory]
    [ClassData(typeof(ItemTestData.ItemsWithDifferentNames))]
    public void CheckValidItemShouldHandleDifferentNamesCorrectly(Item itemWithDifferentNames)
    {
        // Arrange

        // Act
        var actual = _sut.CheckValidItem(itemWithDifferentNames);

        // Assert
        Assert.True(actual);
    }


    [Theory]
    [ClassData(typeof(ItemTestData.InvalidNameItems))]
    public void CheckValidNameShouldThrowArgumentExceptionWhenCheckingInvalidNamesOfItems(Item itemWithInvalidName)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithInvalidName));
    }

    [Theory]
    [ClassData(typeof(ItemTestData.ItemNamesWithSqlKeywords))]
    public void CheckValidNameShouldThrowArgumentExceptionWhenNamesWithSQLKeyWordsAreUsed(Item itemWithSqlKeywords)
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithSqlKeywords));
    }
}
