namespace Lab2.Payment
{
    public class GooglePayPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing Google Pay payment...");
        }
    }
}