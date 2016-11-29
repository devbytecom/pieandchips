namespace Betfred.TechTest
{
    public abstract class ShoppingCartItem : IShoppingCartItem
    {
        public abstract decimal Price { get; }
        public virtual decimal CalculatedPrice 
        {
            get { return Price; }
        }
    }
}