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
        public Address Address { get; set; }
        public string Promo_description { get; set; }
        public int Average_Rating { get; set; }
        public virtual ICollection<Location> Destinations { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

        public AvioCompany()
        {
        }

        public AvioCompany(Address address, string promo_description, int prosecna_ocena)
        {
            Address = address;
            Promo_description = promo_description;
            Average_Rating = prosecna_ocena;
        }
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
        public string Flight_Duration { get; set; }
        public string Flight_Distance { get; set; }

        public Flight(Location from_Location, Location to_Location, Price price, DateTime flight_Departure_Time, DateTime flight_Arrival_Time, string flight_Duration, string flight_Distance)
        {
            From_Location = from_Location;
            To_Location = to_Location;
            Price = price;
            Flight_Departure_Time = flight_Departure_Time;
            Flight_Arrival_Time = flight_Arrival_Time;
            Flight_Duration = flight_Duration;
            Flight_Distance = flight_Distance;
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