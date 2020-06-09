using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class RentACar
    {
        public int Id { get; set; }
        public string RentACarName { get; set; }
        public Address Address { get; set; }
        public string Promo_description { get; set; }
        public double AverageRating { get; set; }
        public List<Address> Holdings { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public RentACar(string name, Address address, string promo_description)
        {
            RentACarName = name;
            Address = address;
            Promo_description = promo_description;
            Holdings = new List<Address>();
        }

        public RentACar()
        {
        }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public double AverageRating { get; set; }
        public double Price { get; set; }
        public string Information { get; set; }

        public Vehicle(Location location, string info, double price)
        {
            Location = location;
            Information = info;
            Price = price;
        }

        public Vehicle()
        {
        }
    }
}