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
        public ICollection<User> FriendRequests { get; set; }
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
        }
    }
    public class AdminRent
    {
        public int Id { get; set; }
        public ICollection<RentACar> OwnedRentServices { get; set; }
        public AdminRent()
        {
        }
    }

    public class RegisteredUser
    {
        public int Id { get; set; }
        public ICollection<Flight> FlightReservations { get; set; }//FlightReservation class
        public ICollection<Vehicle> VehicleReservations { get; set; }//VehicleReservation class
        //invite trip collection
        public RegisteredUser()
        {

        }
    }

}