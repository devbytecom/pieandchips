using System.Collections.Generic;
using System.Linq;

namespace Betfred.TechTest
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<ShoppingCartItem> _items;

        public ShoppingCart()
        {
            _items = new List<ShoppingCartItem>();
        }
        
        public void Add(ShoppingCartItem item)
        {
            _items.Add(item);
        }

        public int ItemCount
        {
            get { return _items.Count; }
        }

        public decimal TotalCost
        {
            get { return _items.Sum(x => x.CalculatedPrice); }
        }
    }
}