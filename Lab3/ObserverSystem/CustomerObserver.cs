namespace Lab3.ObserverSystem
{
    public class CustomerObserver : IObserver
    {
        private readonly string _customerName;

        public CustomerObserver(string customerName)
        {
            _customerName = customerName;
        }

        public void Update(string orderId, string status)
        {
            Console.WriteLine($"[Customer Notification] Dear {_customerName}, your order {orderId} is now: {status}");
        }
    }
}