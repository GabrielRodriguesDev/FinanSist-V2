namespace Finansist.Domain.Notification
{
    public class Notification
    {
        public Notification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public String Key { get; set; } = null!;

        public String Value { get; set; } = null!;

    }
}