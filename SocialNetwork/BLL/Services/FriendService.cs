using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        private IFriendRepository _friendRepository;
        private IUserRepository _userRepository;

        public FriendService()
        {
            _friendRepository = new FriendRepository();
            _userRepository = new UserRepository();
        }

        public void AddNewFriends(FriendCreateData friendCreate)
        {
            var findFriend = _userRepository.FindByEmail(friendCreate.EmailFriend) ?? throw new UserNotFoundException();

            var friendEntity = new FriendEntity
            {
                friend_id = findFriend.Id,
                user_id = friendCreate.UserId
            };
            var doubleRecord = new FriendEntity
            {
                friend_id = friendCreate.UserId,
                user_id = findFriend.Id
            };
            if (_friendRepository.FindRecord(friendCreate.UserId, findFriend.Id) != null) 
                throw new RecordExistsException();

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
            if (_friendRepository.Create(doubleRecord) == 0)
                throw new Exception();
        }
        public IEnumerable<Friend> GetAllFriends(int UserId)
        {
            var friends = new List<Friend>();
            _friendRepository.FindAllByUserId(UserId).ToList().ForEach(f =>
            {
                var firstname = _userRepository.FindById(f.friend_id);
                var lastname = _userRepository.FindById(f.friend_id);
                var emailFriend = _userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, firstname.firstname, lastname.lastname, emailFriend.email));
            });
            return friends;
        }
    }
}
