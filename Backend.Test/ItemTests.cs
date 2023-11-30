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
        private readonly ItemManager _sut;
        private Item _item;


        public ItemTests()
        {
            _sut = new ItemManager();
            _item = new Item() { Name = "Salary", Amount = 3000f };
        }

        [Fact]
        public void CanValidateItem_ShouldValidateItem_WhenGivenValidDetails()
        {
            // Arrange
            

            // Act
            var actual = _sut.CheckValidItem(_item);

            // Assert
            Assert.Equal(actual.Name, _item.Name);

        }


        [Fact]
        public void ValidateItem_ShouldThrowArgumentException_WhenGivenInvalidDetails()
        {
            // Arrange
            var invalidNameItem = new Item() { Name = string.Empty, Amount = 10f};
            var invalidFloatItem = new Item() { Name = "Mat", Amount = -1f};


            // Act & Assert
            var ex1 = Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(invalidNameItem));
            Assert.Contains("Name", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(invalidFloatItem));
            Assert.Contains("Amount", ex2.Message);

        }


        [Fact]
        public void ValidateItem_ShouldHandleBoundaryValue_ForItemAmount()
        {
            // Arrange
            var boundaryItem = new Item() { Name = "BoundaryTestItem", Amount = 0f };            

            // Act
            var actual = _sut.CheckValidItem(boundaryItem);

            // Assert
            Assert.Equal(boundaryItem.Name, actual.Name);
            Assert.Equal(boundaryItem.Amount, actual.Amount);
        }



        [Fact]
        public void CreateItem_ShoudlThrowException_WhenItemNameExceedsLengthLimit()
        {
            // Arrange
            var itemWithLongName = new Item() { Name = new string('a', 51), Amount = 100f};
            

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithLongName));
            Assert.Contains("Name", ex.Message);
        }


        [Fact]
        public void ValidateItem_ShouldHandleLargeItemAmounts()
        {
            // Arrange
            var itemWithLargeAmount = new Item() { Name = "LargeAmountItem", Amount = 1e6f};
            

            // Act
            var actual = _sut.CheckValidItem(itemWithLargeAmount);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(itemWithLargeAmount.Amount, actual.Amount);
        }


        [Theory]
        [InlineData("Item1")]
        [InlineData("ITEM_UPPERCASE")]
        [InlineData("item lowercase")]
        public void CreateItem_ShouldHandleDifferentNameFormats(string itemName)
        {
            // Arrange
            var itemWithDifferentNames = new Item() { Name = itemName, Amount = 100f };

            // Act
            var actual = _sut.CheckValidItem(itemWithDifferentNames);

            // Assert
            Assert.Equal(itemWithDifferentNames.Name, actual.Name);
        }


        //[Theory]
        //[InlineData("   ItemWithSpaces   ")]
        //[InlineData("\tItemWithTab\t")]
        //[InlineData("\nItemWithNewLine\n")]
        //public void ValidateItem_ShouldTrimWhitespaceFromItemName(string itemName)
        //{
        //    // Arrange
        //    var itemWithWhiteSpace = new Item() { Name = itemName, Amount = 100f};            
        //    var expectedName = itemName.Trim();

        //    // Act
        //    var actual = _sut.CheckValidItem(itemWithWhiteSpace);

        //    // Assert
        //    Assert.NotNull(actual);
        //    Assert.Equal(expectedName, actual.Name);
        //}


        [Theory]
        [InlineData("#InvalidName")]
        [InlineData("!AnotherInvalid")]
        [InlineData("@NotValid")]
        public void CreateItem_ShouldNotAllowNamesStartingWithSpecialCharacters(string itemName)
        {
            // Arrange
            var itemWithInvalidNames = new Item() { Name = itemName, Amount = 100f};
            

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _sut.CheckValidItem(itemWithInvalidNames));
            Assert.Contains("start with a special character", ex.Message);
        }

    }
}
