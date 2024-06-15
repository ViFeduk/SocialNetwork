using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into message(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        public int DeleteById(int messageId)
        {
            return Execute(@"delete from message where id = :id_m", new { id_m = messageId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>(@"select * from message where id = :id_rec", new { id_rec = recipientId });
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>(@"select * from message where id = :id_m", new { id_m = senderId});
        }
    }

    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);
        IEnumerable<MessageEntity> FindBySenderId(int senderId);
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        int DeleteById(int messageId);
    }
}
