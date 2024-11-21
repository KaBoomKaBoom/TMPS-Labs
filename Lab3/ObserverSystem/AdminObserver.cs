namespace Lab3.ObserverSystem
{
    public class AdminObserver : IObserver
    {
        public void Update(string orderId, string status)
        {
            Console.WriteLine($"[Admin Notification] Order {orderId} status updated to: {status}");
        }
    }
}