using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class RentACar
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Promo_description { get; set; }
        public int Average_Rating { get; set; }
        public List<Address> Holdings { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public RentACar(Address address, string promo_description, int average_Rating)
        {
            Address = address;
            Promo_description = promo_description;
            Average_Rating = average_Rating;
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