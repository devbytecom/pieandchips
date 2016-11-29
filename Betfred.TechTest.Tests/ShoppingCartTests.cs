using System;
using NUnit.Framework;

namespace Betfred.TechTest.Tests
{
    public class ShoppingCartTests
    {
        private IShoppingCart _shoppingCart;

        [SetUp]
        public void SetupShoppingCart()
        {
            _shoppingCart = new ShoppingCart();
        }

        [Test]
        public void AddAChip_TotalIsOne()
        {
            // Arrange
            const int expectedTotal = 1;

            // Act
            _shoppingCart.Add(new Chips());
            var result = _shoppingCart.ItemCount;

            // Assert
            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void AddAChip_CalculateTotal()
        {
            // Arrange
            const decimal expectedAmount = 1m;

            // Act
            _shoppingCart.Add(new Chips());
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedAmount));
        }

        [Test]
        public void AddAPie_TotalIsOne()
        {
            // Arrange
            const int expectedTotal = 1;

            // Act
            _shoppingCart.Add(new Pie(DateTime.MinValue));
            var result = _shoppingCart.ItemCount;

            // Assert
            Assert.That(result, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void AddAPie_TotalIsTwo()
        {
            // Arrange
            const decimal expectedAmount = 2m;

            // Act
            _shoppingCart.Add(new Pie(DateTime.MaxValue));
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedAmount));
        }

        [Test]
        public void AddAPie_SameDayExpiryDate_FiftyPercentOff()
        {
            // Arrange
            var pieBuyDate = DateTime.Today;
            var pie = new Pie(pieBuyDate);
            const decimal expectedCost = 2m / 2;

            // Act
            _shoppingCart.Add(pie);
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedCost));
        }
        
        [Test]
        public void AddPies_SameDayExpiryDateOtherNotExpired_FiftyPercentOffAndSamePriceCalculated()
        {
            // Arrange
            var pieBuyDate = DateTime.Today;
            var expiredPie = new Pie(pieBuyDate);
            var notExpiredPie = new Pie(pieBuyDate.AddDays(-2));
            const decimal expectedCost = 3m;

            // Act
            _shoppingCart.Add(expiredPie);
            _shoppingCart.Add(notExpiredPie);
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedCost));
        }

        [Test]
        public void AddNewGiftSet_ContainsPieAndChips_DiscountPercentageApplied()
        {
            // Arrange 
            var pie = new Pie(DateTime.Now.AddDays(-2));
            var chips = new Chips();
            // 2m (pie) + 1m (chips) * 0.75m 25% off
            var expectedPrice = (2m + 1m)*0.75m;

            // Act
            _shoppingCart.Add(new PieAndChipsGiftBox(chips, pie));
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedPrice));
        }
        
        [Test]
        public void AddNewGiftSet_ContainsPieAndChips_PieIsExpired_DiscountPercentageApplied()
        {
            // Arrange 
            var pie = new Pie(DateTime.Today);
            var chips = new Chips();
            // 1m (pie 50% off) + 1m (chips) * 0.75m 25% off
            var expectedPrice = (1m + 1m)*0.75m;

            // Act
            _shoppingCart.Add(new PieAndChipsGiftBox(chips, pie));
            var result = _shoppingCart.TotalCost;

            // Assert
            Assert.That(result, Is.EqualTo(expectedPrice));
        }
    }
}
