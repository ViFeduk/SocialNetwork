using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Sender_ID { get; set; }
        public int Recipient_ID { get; set; }
        public Message(int id, string content, int sender_id, int recipient_id)
        {
            Id = id;
            Content = content;
            Sender_ID = sender_id;
            Recipient_ID = recipient_id;
        }
    }
}
