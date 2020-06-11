using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    
    public class TempUser
    {
        public int Id { get; set; }
        public string ActivationLink { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public TempUser()
        {

        }

        public TempUser(string name, string lastName, string hash, string email,string username,string phoneNum)
        {
            PhoneNumber = phoneNum;
            Username = username;
            Name = name;
            LastName = lastName;
            Pass = hash;
            Email = email;
            ActivationLink = Guid.NewGuid().ToString();
            ExpiryDate = DateTime.Now.AddHours(1);

        }
        public TempUser(TempUser temp)
        {
            PhoneNumber = temp.PhoneNumber;
            Username = temp.Username;
            Name = temp.Name;
            LastName = temp.LastName;
            Pass = temp.Pass;
            Email = temp.Email;
            ActivationLink = Guid.NewGuid().ToString();
            ExpiryDate = DateTime.Now.AddHours(1);
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Hash { get; set; }
        public Role Role { get; set; }
        public int UlogaID { get; set; }
        public string Email { get; set; }
        public ICollection<User> PendingFriends { get; set; }
        public ICollection<User> FriendRequestsSent { get; set; }
        public ICollection<User> Friends { get; set; }

        public User(string name, string lastName, Role role, int ulogaID,string hash,string email)
        {
            Name = name;
            LastName = lastName;
            Role = role;
            UlogaID = ulogaID;
            Hash = hash;
            Email = email;
        }

        public User(TempUser tempUser)
        {
            Username = tempUser.Username;
            Name = tempUser.Name;
            LastName = tempUser.LastName;
            Role = Role.RegisteredUser;
            UlogaID = -1;
            Hash = tempUser.Pass;
            Email = tempUser.Email;
        }

        public User()
        {
            Friends = new List<User>();
            PendingFriends = new List<User>();
            FriendRequestsSent = new List<User>();
        }
    }

    public enum Role
    {
        RegisteredUser,
        AdminAvio,
        AdminRentACar,
        Admin
    }

    public class Admin
    {
        public int Id { get; set; }

        public Admin()
        {
        }
    }
    public class AdminAvio
    {
        public int Id { get; set; }
        public ICollection<AvioCompany> OwnedAvioCompanies { get; set; }
        public AdminAvio()
        {
            OwnedAvioCompanies = new List<AvioCompany>();
        }
    }
    public class AdminRent
    {
        public int Id { get; set; }
        public ICollection<RentACar> OwnedRentServices { get; set; }
        public AdminRent()
        {
            OwnedRentServices = new List<RentACar>();
        }
    }

    public class RegisteredUser
    {
        public int Id { get; set; }
        public ICollection<FlightReservation> FlightReservations { get; set; }//FlightReservation class
        public RegisteredUser()
        {
            FlightReservations = new List<FlightReservation>();
        }
    }
    public class FlightReservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Seat_Reserved { get; set; }
        public int Passport_Number { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
        public User Invited_By { get; set; }
        public Review Review { get; set; }

        public FlightReservation(string name, string lastName, int seat_Reserved, int passport_Number, User appropriate_User,Flight flight)
        {
            Name = name;
            LastName = lastName;
            Seat_Reserved = seat_Reserved;
            Passport_Number = passport_Number;
            User = appropriate_User;
            Flight = flight;
        }

        public FlightReservation(string name, string lastName, int seat_Reserved, int passport_Number, Flight flight)
        {
            Name = name;
            LastName = lastName;
            Seat_Reserved = seat_Reserved;
            Passport_Number = passport_Number;
            Flight = flight;
        }

        public FlightReservation(string name, string lastName, int seat_Reserved, User user, Flight flight)
        {
            Name = name;
            LastName = lastName;
            Seat_Reserved = seat_Reserved;
            User = user;
            Flight = flight;
        }

        public FlightReservation()
        {
        }
    }

}