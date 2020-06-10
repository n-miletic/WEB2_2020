using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class ReservationForm
    {
        public int Passport { get; set; }
        public int FlightId { get; set; }
        public int Seat { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string InvitedUsername { get; set; }
    }
}