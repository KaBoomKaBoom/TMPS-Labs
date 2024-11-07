namespace Lab2.Payment
{
    public class ApplePayPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing Apple Pay payment...");
        }
    }
}