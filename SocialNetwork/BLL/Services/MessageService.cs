using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    internal class MessageService
    {
        private IMessageRepository _messageRepository;
        public MessageService()
        {
            _messageRepository = new MessageRepository();
        }
        public void SendMessage(SendMessageData sendMessageData)
        {
            if (String.IsNullOrEmpty(sendMessageData.Content)) 
                throw new ArgumentNullException();

            if (sendMessageData.Content.Length > 500)
                throw new ArgumentOutOfRangeException();
            
            if (sendMessageData.MailAddress )
        }
    }
}
