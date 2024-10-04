// OCP: Strategy for discount calculation.
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal total);
}