namespace Business.Core.Notifications;

public class Notification
{
    public string Message { get; }

    public Notification(string message)
    {
        this.Message = message;
    }
}
