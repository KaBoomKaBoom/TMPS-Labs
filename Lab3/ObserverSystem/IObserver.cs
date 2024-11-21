//Observer Pattern for notifing when an orde changes its shippment status

namespace Lab3.ObserverSystem
{
    public interface IObserver
    {
        void Update(string orderId, string status);
    }
}