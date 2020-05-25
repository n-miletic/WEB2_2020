using DiemService.Database;
using DiemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Controllers
{
    public static  class FlightDbManager
    {
        public static List<Flight> GetAllFlights()
        {
            using (var _context = new DiemServiceDB())
            {
                _context.ThePurge();
                List<Flight> retVal = _context.FlightDbSet.ToList();
                return retVal;

            }
        }

        public static void AddFlight(FlightForm flight)
        {
            using (var _context = new DiemServiceDB())
            {
                Location to = new Location(flight.toLocation.Split(',')[1], flight.toLocation.Split(',')[0]);
                Location from = new Location(flight.fromLocation.Split(',')[1], flight.fromLocation.Split(',')[0]);
                Flight toAdd = flight.toFlight();
                toAdd.To_Location = _context.LocationDbSet.Add(to);
                toAdd.From_Location = _context.LocationDbSet.Add(from);
                _context.FlightDbSet.Add(toAdd);
                _context.SaveChanges();

            }
        }
    }
}