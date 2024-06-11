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
        public UserService()
        {
            _userRepository = new UserRepository();
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
    }
}
