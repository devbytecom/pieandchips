using System;

namespace Betfred.TechTest
{
    public class ExpiresTodayHalfPriceCalculator : IExpiresTodayHalfPriceCalculator
    {
        public decimal Calculate(IExpiryDateItem expiryDateItem, decimal price)
        {
            if (expiryDateItem.ExpiryDate == DateTime.Today)
            {
                return price / 2;
            }

            return price;
        }
    }
}