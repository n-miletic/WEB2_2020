using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DiemService.Forms
{
    public class IdForm
    {
        public string Id { get; set; }
    }
    public class FlightForm
    {
        public string toLocation { get; set; }
        public string fromLocation { get; set; }
        public DateTime Flight_Departure_Time { get; set; }
        public DateTime Flight_Arrival_Time { get; set; }
        public FlightClass FlightClass { get; set; }
        
        public string price { get; set; }
        public int seats { get; set; }
        public List<string> transits { get; set; }
        
        public Flight toFlight()
        {

            Location to = new Location() { State = toLocation};
            Location from = new Location() { State = fromLocation};
            int[] Seats = new int[seats];
            for (int i = 0; i < seats; i++)
            {
                Seats[i] = 0;
            }
            string seatsString = string.Join("", Seats);
            List <Location> Transits = new List<Location>();
            if(transits != null)
            foreach (string item in transits)
            {
                Transits.Add(new Location() { State = item });
            }
            return new Flight(from, to, new Price(Double.Parse(price)), Flight_Departure_Time, Flight_Arrival_Time, (Flight_Arrival_Time - Flight_Departure_Time).ToString(), "", FlightClass,seatsString,Transits) ;
        }
    }
}