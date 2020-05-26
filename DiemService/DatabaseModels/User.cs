using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public int UlogaID { get; set; }
        public ICollection<User> FriendRequests { get; set; }
        public ICollection<User> Friends { get; set; }

        public User(string name, string lastName, Role role, int ulogaID)
        {
            Name = name;
            LastName = lastName;
            Role = role;
            UlogaID = ulogaID;
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