using SocialNetwork.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class PrintAllFriendsView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Ваши друзья: ");

            if (friends.Count() == 0) Console.WriteLine("Друзей нет!");


            foreach (var friend in friends)
            {
                Console.WriteLine($"{friend.FirstName}  {friend.Lastname}       {friend.EmailFriend}");
            }
        }
    }
}
