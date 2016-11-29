using System;

namespace Betfred.TechTest
{
    public class Pie : ShoppingCartItem, IExpiryDateItem
    {
        private readonly DateTime _expiryDate;

        public Pie(DateTime expiryDate)
        {
            _expiryDate = expiryDate;
        }
        
        public override decimal Price
        {
            get { return 2m; }
        }

        public override decimal CalculatedPrice
        {
            get
            {
                var expiryCalculator = new ExpiresTodayHalfPriceCalculator();
                return expiryCalculator.Calculate(this, Price);
            }
        }

        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
        }
    }
}