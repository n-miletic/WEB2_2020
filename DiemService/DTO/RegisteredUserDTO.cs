using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.DTO
{
    public class RegisteredUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<User> PendingFriends { get; set; }
        public ICollection<User> FriendRequestsSent { get; set; }
        public ICollection<User> Friends { get; set; }

    }
}