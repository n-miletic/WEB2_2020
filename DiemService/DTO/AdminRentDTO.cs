﻿using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace DiemService.DTO
{
    public class AdminRentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<User> PendingFriends { get; set; }
        public ICollection<User> FriendRequestsSent { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<RentACar> OwnedRentServices { get; set; }
        public Role Role { get; set; }
        public AdminRentDTO(User user,DiemServiceDB _context)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            Role = user.Role;
            Username = user.Username;
            Email = user.Email;
            PendingFriends = user.PendingFriends;
            Friends = user.Friends;
            FriendRequestsSent = user.FriendRequestsSent;
             OwnedRentServices = _context.AdminRentDbSet.Where(u => u.Id == user.UlogaID)
                                                        .Include(x => x.OwnedRentServices.Select(y => y.Address))
                                                        .FirstOrDefault().OwnedRentServices;
        }
    }
}