using System;
using NUnit.Framework;

namespace Betfred.TechTest.Tests
{
    public class ExpiryItemTests
    {
        [Test]
        public void PieHasAnExpiryDate()
        {
            // Arrange
            var expiryDate = new DateTime(2016, 11, 29);

            // Act
            var pie = new Pie(expiryDate);

            // Assert
            Assert.That(pie.ExpiryDate, Is.EqualTo(expiryDate));
        }
    }
}
