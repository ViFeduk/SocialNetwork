using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public  class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("Информация о моем профиле");
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.firstname);
            Console.WriteLine("Моя фамилия: {0}", user.lastname);
            Console.WriteLine("Мой пароль: {0}", user.password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.favorite_movie);
            Console.WriteLine("Моя любимая книга: {0}", user.favoriteBook);
        }
    }
}
