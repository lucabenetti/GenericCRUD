namespace GenericCore.Notifier
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;
        
        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void AddNotifications(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                AddNotification(error);
            }
        }

        public void AddNotification(string error)
        {
            _notifications.Add(new Notification(error));
        }

        public IEnumerable<string> GetErrors()
        {
            return _notifications.Select(n => n.Message);
        }
    }
}
