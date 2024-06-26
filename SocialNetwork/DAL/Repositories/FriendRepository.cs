﻿using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where user_id = :id_del", new { id_del = id });
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
           return Query<FriendEntity>(@"select * from friends where user_id = :id_us", new {id_us =  userId});
        }
        public FriendEntity FindRecord(int userId, int friendId)
        {
            return QueryFirstOrDefault<FriendEntity>(@"select * from  friends where user_id = :id_us and friend_id = :id_fr", new { id_us = userId, id_fr = friendId });
        }
    }
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
        FriendEntity FindRecord(int userId, int friendId);
    }
}
