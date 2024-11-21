namespace Lab3.ObserverSystem
{
    public class Order : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private string _status;

        public string OrderId { get; }
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                Notify(); // Notify observers when the status changes
            }
        }

        public Order(string orderId, string initialStatus)
        {
            OrderId = orderId;
            _status = initialStatus;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(OrderId, _status);
            }
        }
    }

}