using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using FirebaseAdmin.Messaging;

namespace AMS.Infrastructure.Service.NotificationServices
{
    public interface INotificationService
    {

        
        Task<int> PushNotifications(List<Message> messages);

        List<Message> CreateNotifications(MessageCreateDto dto, List<string> tokens);

    }
}
