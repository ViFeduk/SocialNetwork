using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.Collections.Generic;

namespace SocialNetwork.PLL
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");
            UserRepository userRepository = new UserRepository();
            
            while (true)
            {
                
                Console.WriteLine("Для регистрации введите имя пользователя");
                var firstname = Console.ReadLine();
                Console.WriteLine("Введите Фамилию");
                var lastname = Console.ReadLine();
                Console.WriteLine("Введите пароль (не менее 8 символов)");
                var password = Console.ReadLine();
                Console.WriteLine("Введите почту (Email)");
                var email = Console.ReadLine();

                var user = new UserRegistrationData()
                {
                    email = email,
                    firstname = firstname,
                    lastname = lastname,
                    password = password
                
                };
                try
                {
                    userService.Registration(user);
                    Console.WriteLine("Вы успешно зарегестрированы");
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные значения");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла непредвиденная ошибка: "+ex.Message+ " Обратитесь к поддержке");
                }
                Console.ReadLine();
            }
        }
    }
}
