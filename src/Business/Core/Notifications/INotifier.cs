using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Business.Core.Notifications;

public interface INotifier
{
    bool HasNotifications { get; }
    IReadOnlyCollection<Notification> GetNotifications();
    void Notify(string message);
    void Notify(ValidationResult validationResult);
    JsonResult GetAsJsonResult();
}
