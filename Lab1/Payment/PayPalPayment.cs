namespace Lab1.Payment
{
    public class PayPalPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment...");
        }
    }
}