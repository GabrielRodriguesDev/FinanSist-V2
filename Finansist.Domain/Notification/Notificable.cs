namespace Finansist.Domain.Notification
{
    public abstract class Notificable
    {
        public List<Notification> Notifications { get; private set; }
        public Notificable()
        {
            this.Notifications = new List<Notification>();
        }

        public void AddNotification(string key, string value)
        {
            this.Notifications.Add(new Notification(key, value));
        }

        public bool Valid
        {
            get { return this.Notifications.Count() == 0; }
        }
        public bool Invalid
        {
            get { return this.Notifications.Count() > 0; }
        }

        public abstract void Validate();
    }
}