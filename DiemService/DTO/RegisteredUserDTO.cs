using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
        public ICollection<FlightReservation> FlightReservations { get; set; }
        public Role Role;
        public RegisteredUserDTO(User user, DiemServiceDB _context)
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
            FlightReservations = _context.RegisteredUserDbSet.Where(u => u.Id == user.UlogaID).Include(x=> x.FlightReservations)
                                                       .Include(x => x.FlightReservations.Select(y => y.Flight.To_Location))
                                                      .Include(x => x.FlightReservations.Select(y => y.Flight.From_Location))
                                                      .Include(x => x.FlightReservations.Select(y => y.Flight.Transits))
                                                      .Include(x => x.FlightReservations.Select(y => y.Flight.Provider))

                                                        .Include(x => x.FlightReservations.Select(y => y.Invited_By))
                                                        .Include(x=>x.FlightReservations.Select(y => y.Review).Select(z=>z.User))
                                                       .FirstOrDefault().FlightReservations.Where(u=>!u.Cancelled).ToList();
        }

    }
}