namespace Lab2.Payment
{
    public class PayPalPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment...");
        }
    }
}