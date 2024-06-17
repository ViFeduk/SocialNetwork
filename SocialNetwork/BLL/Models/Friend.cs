using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public  class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string EmailFriend { get; set; }
        public Friend(int id,string firstname, string lastname, string emailName)
        {
            Id = id;
            FirstName = firstname;
            Lastname = lastname;
            EmailFriend = emailName;
        }
    }
}
