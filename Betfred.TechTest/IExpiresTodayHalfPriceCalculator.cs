namespace Betfred.TechTest
{
    public interface IExpiresTodayHalfPriceCalculator
    {
        decimal Calculate(IExpiryDateItem pie, decimal price);
    }
}
