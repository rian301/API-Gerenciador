using FluentValidation.Results;
using Black.Domain.Core.Models;
using System.Collections.Generic;

namespace Black.Domain.Core.Notifications
{
    public interface INotificationHandler<in TNotification> where TNotification : Notification
    {
        List<DomainNotification> GetNotifications();
        void Handle(TNotification notification);
        void Handle(CommandResult errors);
        void Handle(IList<ValidationFailure> erros);
        bool HasNotifications();
        void Dispose();
        void Clear();
    }
}
