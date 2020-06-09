using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class RentACar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public Address Address { get; set; }
        public string Promo_description { get; set; }
        public int Average_Rating { get; set; }
        public ICollection<Address> Holdings { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public User Owner { get; set; }

        public RentACar(string name, Address address, string promo_description, string logo)
        {
            Address = address;
            Promo_description = promo_description;
            Name = name;
            Logo = logo;
        }

        public RentACar()
        {
            Holdings = new List<Address>();
            Vehicles = new List<Vehicle>();
        }
    }
    public class Vehicle
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public string Info { get; set; }

        public Vehicle(Location location, string info)
        {
            Location = location;
            Info = info;
        }

        public Vehicle()
        {
        }
    }
}