using SocialNetwork.BLL.Exceptions;
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

            while (true)
            {
                Console.WriteLine("Войти в профиль (нажмите 1)");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();

                            Console.WriteLine("Введите почтовый адрес:");
                            authenticationData.Email = Console.ReadLine();

                            Console.WriteLine("Введите пароль:");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Вы успешно вошли в социальную сеть! Добро пожаловать {0}", user.firstname);
                                Console.ForegroundColor = ConsoleColor.White;

                                while (true)
                                {
                                    Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                                    Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Написать сообщение (нажмите 4)");
                                    Console.WriteLine("Выйти из профиля (нажмите 5)");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моем профиле");
                                                Console.WriteLine("Мой идентификатор: {0}", user.Id);
                                                Console.WriteLine("Меня зовут: {0}", user.firstname);
                                                Console.WriteLine("Моя фамилия: {0}", user.lastname);
                                                Console.WriteLine("Мой пароль: {0}", user.password);
                                                Console.WriteLine("Мой почтовый адрес: {0}", user.email);
                                                Console.WriteLine("Ссылка на моё фото: {0}", user.photo);
                                                Console.WriteLine("Мой любимый фильм: {0}", user.favorite_movie);
                                                Console.WriteLine("Моя любимая книга: {0}", user.favoriteBook);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                            }
                                        case "2":
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

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлён!");
                                                Console.ForegroundColor = ConsoleColor.White;

                                                break;
                                            }
                                    }
                                }

                            }
                            catch (WrongPasswordException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль не корректный!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (UserNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пользователь не найден!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        }

                    case "2":
                        {
                            var userRegistrationData = new UserRegistrationData();

                            Console.WriteLine("Для создания нового профиля введите ваше имя:");
                            userRegistrationData.firstname = Console.ReadLine();

                            Console.Write("Ваша фамилия:");
                            userRegistrationData.lastname = Console.ReadLine();

                            Console.Write("Пароль:");
                            userRegistrationData.password = Console.ReadLine();

                            Console.Write("Почтовый адрес:");
                            userRegistrationData.email = Console.ReadLine();

                            try
                            {
                                userService.Registration(userRegistrationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("Введите корректное значение.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Произошла ошибка при регистрации.");
                            }

                            break;
                        }
                }
            }
        }
    }
}
