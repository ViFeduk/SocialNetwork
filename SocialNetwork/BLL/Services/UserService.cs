using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
       private  MessageService _messageService;
        private FriendService _friendService;
        public UserService()
        {
            _userRepository = new UserRepository();
            _messageService = new MessageService();
            _friendService = new FriendService();
        }
        public void Registration(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.firstname))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.lastname)) 
                throw new ArgumentNullException();
            
            if (string.IsNullOrEmpty(userRegistrationData.email)) 
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.password)) 
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userRegistrationData.email) != null)
                throw new ArgumentNullException();

            if (userRegistrationData.password.Length < 8) 
                throw new ArgumentNullException();

            var user = new UserEntity()
            {
                email = userRegistrationData.email,
                password = userRegistrationData.password,
                lastname = userRegistrationData.lastname,
                firstname = userRegistrationData.firstname,
            };

            if (_userRepository.Create(user) == 0)
                throw new Exception("Ошибка");   
        }
        public User FindByEmail(string email)
        {
            var findUserEmail = _userRepository.FindByEmail(email);
            if (findUserEmail is null) throw new UserNotFoundException();
            return ConstructUserModel(findUserEmail);
        }

        public User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }
        public User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = _messageService.GetIncomingMessagesByUserId(userEntity.Id);

            var outgoingMessages = _messageService.GetOutcomingMessagesByUserId(userEntity.Id);

            var friends = _friendService.GetAllFriends(userEntity.Id);

            return new User
                (userEntity.Id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favoriteBook,
                incomingMessages,
                          outgoingMessages,
                          friends
                );
        }
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }
        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                Id = user.Id,
                firstname = user.firstname,
                lastname = user.lastname,
                password = user.password,
                email = user.email,
                photo = user.photo,
                favorite_movie = user.favorite_movie,
                favoriteBook = user.favoriteBook
            };

            if (_userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

    }
}
