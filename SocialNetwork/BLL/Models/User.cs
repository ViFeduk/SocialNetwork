﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string favorite_movie { get; set; }
        public string favoriteBook { get; set; }

        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }
        public IEnumerable <Friend> Friends { get; }

        public User(int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,
             IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages,
             IEnumerable<Friend> friends)
           
        {
            this.Id = id;
            this.firstname = firstName;
            this.lastname = lastName;
            this.password = password;
            this.email = email;
            this.photo = photo;
            this.favoriteBook = favoriteBook;
            this.favorite_movie = favoriteMovie;
            this.IncomingMessages = incomingMessages;
            this.OutgoingMessages = outgoingMessages;
            Friends = friends;
        }
    }
}
