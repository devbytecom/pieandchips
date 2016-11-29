namespace Betfred.TechTest
{
    public interface IShoppingCart
    {
        void Add(ShoppingCartItem item);

        int ItemCount { get; }

        decimal TotalCost { get; }
    }
}