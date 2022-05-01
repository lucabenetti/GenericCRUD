namespace GenericCore.Notifier
{
    public interface INotifier
    {
        List<Notification> GetNotifications();
        void AddNotifications(IEnumerable<string> errors);
        bool HasNotification();
        IEnumerable<string> GetErrors();
        void AddNotification(string message);
    }
}
