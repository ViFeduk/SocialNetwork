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
    public class UserDataUpdateView
    {
        UserService userService;
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Меня зовут:");
            user.firstname = Console.ReadLine();

            Console.Write("Моя фамилия:");
            user.lastname = Console.ReadLine();

            Console.Write("Ссылка на моё фото:");
            user.photo = Console.ReadLine();

            Console.Write("Мой любимый фильм:");
            user.favorite_movie = Console.ReadLine();

            Console.Write("Моя любимая книга:");
            user.favoriteBook = Console.ReadLine();

            this.userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
