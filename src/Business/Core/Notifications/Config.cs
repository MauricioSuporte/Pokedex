﻿using Business.Core.Notifications.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Core.Notifications;

public static class Config
{
    public static IServiceCollection AddSmartNotification(this IServiceCollection services)
    {
        services.AddScoped<INotifier, Notifier>();
        services.AddMvcCore(options => options.Filters.Add<NotificationFilter>());
        return services;
    }
}
