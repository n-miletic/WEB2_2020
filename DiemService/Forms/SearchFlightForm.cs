using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class SearchFlightForm
    {
        public string  From_Location { get; set; }
        public string  To_Location { get; set; }
        public DateTime Flight_Departure_Time { get; set; }
        public DateTime Flight_Arrival_Time { get; set; }
        public int Free_seats { get; set; }
        public FlightClass Flight_class{ get;set;}
        //front end duzina putovanja, cena, presedanja
    }
}