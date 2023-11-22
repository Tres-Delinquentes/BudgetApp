using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DAL;
using Backend.Models;

namespace Backend.Test
{
    public class ItemTests
    {

        [Fact]
        public void CanMakeNewItem_ShouldCreateItem_WhenGivenValidDetails()
        {
            // Arrange
            var itemName = "Salary";
            var itemAmount = 3000f;
            var sut = new ItemManager();

            // Act
            var actual = sut.CreateItem(itemName, itemAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(itemName, actual.Name);
            Assert.Equal(itemAmount, actual.Amount);

        }


        [Fact]
        public void CreateItem_ShouldThrowArgumentException_WhenGivenInvalidDetails()
        {
            // Arrange
            var invalidItemName = string.Empty;
            var invalidItemAmount = -1f;
            var sut = new ItemManager();

            // Act & Assert
            var ex1 = Assert.Throws<ArgumentException>(() => sut.CreateItem(invalidItemName, 3000f));
            Assert.Contains("Name", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => sut.CreateItem("Salary", invalidItemAmount));
            Assert.Contains("Amount", ex2.Message);

        }


        [Fact]
        public void CreateItem_ShouldHandleBoundaryValue_ForItemAmount()
        {
            // Arrange
            var itemName = "BoundaryTestItem";
            var boundaryAmount = 0f;
            var sut = new ItemManager();

            // Act
            var actual = sut.CreateItem(itemName, boundaryAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(itemName, actual.Name);
            Assert.Equal(boundaryAmount, actual.Amount);
        }


        [Fact]
        public void CreateItem_ShouldCreateUniqueItems()
        {
            // Arrange
            var sut = new ItemManager();

            // Act
            var item1 = sut.CreateItem("Item1", 100f);
            var item2 = sut.CreateItem("Item2", 200f);

            // Assert
            Assert.NotEqual(item1, item2);
        }


        [Fact]
        public void CreateItem_ShoudlThrowException_WhenItemNameExceedsLengthLimit()
        {
            // Arrange
            var longItemName = new string('a', 51);
            var itemAmount = 100f;
            var sut = new ItemManager();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.CreateItem(longItemName, itemAmount));
            Assert.Contains("Name", ex.Message);
        }


        [Fact]
        public void CreateItem_ShouldHandleLArgeItemAmounts()
        {
            // Arrange
            var itemName = "LargeAmountItem";
            var largeAmount = 1e6f;
            var sut = new ItemManager();

            // Act
            var actual = sut.CreateItem(itemName, largeAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(largeAmount, actual.Amount); 
        }


        [Theory]
        [InlineData("Item1")]
        [InlineData("ITEM_UPPERCASE")]
        [InlineData("item lowercase")]
        public void CreateItem_ShouldHandleDifferentNameFormats(string itemName)
        {
            // Arrange
            var itemAmount = 100f;
            var sut = new ItemManager();

            // Act
            var actual = sut.CreateItem(itemName, itemAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(itemName, actual.Name);
        }


        [Theory]
        [InlineData("        ItemWithSpaces   ")]
        [InlineData("\tItemWithTab\t")]
        [InlineData("\nItemWithNewLine\n")]
        public void CreateItem_ShouldTrimWhitespaceFromItemName(string itemName)
        {
            // Arrange
            var itemAmount = 100f;
            var sut = new ItemManager();
            var expectedName = itemName.Trim();

            // Act
            var actual = sut.CreateItem(itemName, itemAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedName, actual.Name);
        }


        [Theory]
        [InlineData("#InvalidName")]
        [InlineData("!AnotherInvalid")]
        [InlineData("@NotValid")]
        public void CreateItem_ShouldNotAllowNamesStartingWithSpecialCharacters(string itemName)
        {
            // Arrange
            var itemAmount = 100f;
            var sut = new ItemManager();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => sut.CreateItem(itemName, itemAmount));
            Assert.Contains("start with a special character", ex.Message);
        }

    }
}
