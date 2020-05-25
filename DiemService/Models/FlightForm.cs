using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DiemService.Models
{
    public class FlightForm
    {
        public string toLocation { get; set; }
        public string fromLocation { get; set; }
        public DateTime Flight_Departure_Time { get; set; }
        public DateTime Flight_Arrival_Time { get; set; }
        public string vreme { get; set; }
        public string cena { get; set; }
        public string duzina_putovanja { get; set; }
        public Flight toFlight()
        {
            

            return new Flight(new Price(Double.Parse(cena)), Flight_Departure_Time, Flight_Arrival_Time, (Flight_Arrival_Time - Flight_Departure_Time).ToString(), "");
        }
    }
}