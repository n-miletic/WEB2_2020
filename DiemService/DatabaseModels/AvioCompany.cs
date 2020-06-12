using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class AvioCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Promo_description { get; set; }
        public int Average_Rating { get; set; }
        public  ICollection<Location> Destinations { get; set; }
        public  ICollection<Flight> Flights { get; set; }
        public User Owner { get; set; }
        public string Logo { get; set; }
        public AvioCompany()
        {
            Destinations = new List<Location>();
            Flights = new List<Flight>();
        }

        public AvioCompany(string name, Address address, string promo_description,string logo)
        {
            Address = address;
            Promo_description = promo_description;
            Name = name;
            Logo = logo;
        }
    }
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }

        public Review(User user, int stars,string comment)
        {
            User = user;
            Stars = stars;
            Comment = comment;
        }

        public Review()
        {
        }
    }
    public enum FlightClass
    {
        NotSelected,
        Economy,
        Bussiness,
        FirstClass
    }
    public class Flight
    {
     
        public int Id { get; set; }
        public virtual Location From_Location { get; set; }
        public virtual Location To_Location { get; set; }
        public virtual ICollection<Location> Transits { get; set; }
        public Price Price { get; set; }
        public DateTime Flight_Departure_Time { get; set; }
        public DateTime Flight_Arrival_Time { get; set; }
        public ICollection<FlightReservation> Reservations { get; set; } 
        public string Flight_Duration { get; set; }
        public string Seats { get; set; }
        public string Flight_Distance { get; set; }
        public FlightClass FlightClass { get; set; }
        public int DiscountedPrice { get; set; }

        public AvioCompany Provider { get; set; }

        public Flight(Location from_Location, Location to_Location, Price price, DateTime flight_Departure_Time, DateTime flight_Arrival_Time, string flight_Duration, string flight_Distance,FlightClass flightClass,string seats,List<Location> transits)
        {
            From_Location = from_Location;
            To_Location = to_Location;
            Price = price;
            Flight_Departure_Time = flight_Departure_Time;
            Flight_Arrival_Time = flight_Arrival_Time;
            Flight_Duration = flight_Duration;
            Flight_Distance = flight_Distance;
            FlightClass = flightClass;
            Seats = seats;
            Transits = transits;
        }

        public Flight(Price price, DateTime flight_Departure_Time, DateTime flight_Arrival_Time,string flightDuration, string flight_Distance)
        {
            Price = price;
            Flight_Departure_Time = flight_Departure_Time;
            Flight_Arrival_Time = flight_Arrival_Time;
            Flight_Distance = flight_Distance;
            Flight_Duration = flightDuration;
        }

        public Flight()
        {
            Transits = new List<Location>();
            Reservations = new List<FlightReservation>();
        }
    }
    #region Address
    public class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Street_num { get; set; }
        public int Postal_code { get; set; }

        public Address(string state, string city, string street, string street_num, int postal_code)
        {
            State = state;
            City = city;
            Street = street;
            Street_num = street_num;
            Postal_code = postal_code;
        }

        public Address()
        {
        }
    }
    #endregion
    #region Location
    public class Location
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Location(string state, string city)
        {
            State = state;
            City = city;
        }
        public Location(string form)
        {
            State = form.Split(',')[1];
            City = form.Split(',')[2];
        }
        public Location()
        {
        }
    }
    #endregion
    #region Price
    public enum Currency
    {
        USD
    }
    [ComplexType]
    public class Price
    {
        public double Value { get; set; }
        public Currency Currency { get; set; }
        public Price(double v)
        {
            this.Value = v;
            Currency = Currency.USD;
        }

        public Price()
        {
        }
    }
    #endregion

}