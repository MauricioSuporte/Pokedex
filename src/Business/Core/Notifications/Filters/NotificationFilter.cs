using Microsoft.AspNetCore.Mvc.Filters;

namespace Business.Core.Notifications.Filters;

public class NotificationFilter : IActionFilter
{
    private readonly INotifier _notifier;

    public NotificationFilter(INotifier notifier)
    {
        this._notifier = notifier;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (!_notifier.HasNotifications)
            return;

        context.Result = _notifier.GetAsJsonResult();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Not implemented.
    }
}
