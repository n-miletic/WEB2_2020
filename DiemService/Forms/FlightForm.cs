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
        
        public string price { get; set; }
        
        public Flight toFlight()
        {

            Location to = new Location(toLocation.Split(',')[1], toLocation.Split(',')[0]);
            Location from = new Location(fromLocation.Split(',')[1],fromLocation.Split(',')[0]);
            return new Flight(from,to,new Price(Double.Parse(price)), Flight_Departure_Time, Flight_Arrival_Time, (Flight_Arrival_Time - Flight_Departure_Time).ToString(), "");
        }
    }
}