using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Core.Dto.CreateDto;
using AMS.Data.Data;
using FirebaseAdmin.Messaging;

namespace AMS.Infrastructure.Service.NotificationServices
{
    public class NotificationService : INotificationService
    {

        private readonly FirebaseMessaging _messaging;
        

        public NotificationService()
        {
            _messaging = FirebaseMessaging.DefaultInstance;
            
        }

        public List<Message> CreateNotifications(MessageCreateDto dto, List<string> tokens)
        {

            var messages = new List<Message>();

            foreach (var token in tokens)
            {

                var message = new Message()
                {
                    Token = token,
                    Data = new Dictionary<string, string>() {

                        {"Title",dto.Title},
                        {"Body",dto.Body},
                        {"Action",dto.Action},
                        {"ActionId",dto.ActionId.ToString()},
                    },
                };

                messages.Add(message);
            }

            return messages;

        }

        public async Task<int> PushNotifications(List<Message> messages)
        {
          var result = await _messaging.SendAllAsync(messages);

           return result.SuccessCount;
        }

        
    }
}
