using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace DiemService.DTO
{
    public class AdminAvioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<User> PendingFriends { get; set; }
        public ICollection<User> FriendRequestsSent { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<AvioCompany> OwnedAvioCompanies { get; set; }
        public Role Role { get; set; }
        public AdminAvioDTO(User user, DiemServiceDB _context)
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
            OwnedAvioCompanies =  _context.AdminAvioDbSet.Where(u => u.Id == user.UlogaID)
                                                         .Include(x => x.OwnedAvioCompanies.Select(y=> y.Address))
                                                         .FirstOrDefault().OwnedAvioCompanies; // UVEK IDE WHERE PA INCLUDE


        }
    }
}