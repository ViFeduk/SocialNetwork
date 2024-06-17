using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        private FriendService _friendService;
       
        public AddFriendView()
        {
            _friendService = new FriendService();
            
        }
        public void Show(User user)
        {
            var friend = new FriendCreateData();
            Console.WriteLine("Введите email друга, чтобы его добавить");
            friend.EmailFriend = Console.ReadLine();
            friend.UserId = user.Id;
            try
            {
                _friendService.AddNewFriends(friend);
                SuccessMessage.Show("Друг успешно добавлен!");
            }
            catch( UserNotFoundException )
            {
               AlertMessage.Show("Пользователь не найден");
            }
            catch (RecordExistsException)
            {
                AlertMessage.Show("Пользователь уже ваш друг!");
            }
            catch 
            {
               AlertMessage.Show("Непредвиденная ошибка");
            }
        }
    }
}
