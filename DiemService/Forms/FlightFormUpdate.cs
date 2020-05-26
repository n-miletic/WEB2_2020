using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class FlightFormUpdate
    {
        public string Id { get; set; }

        public string ToLocation { get; set; }
        public string FromLocation { get; set; }
        public DateTime Flight_Departure_Time { get; set; }
        public DateTime Flight_Arrival_Time { get; set; }
        
        public string Price { get; set; }
        

    }
}