using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DiemService.Controllers
{
    public static  class FlightDbManager
    {
        public static List<Flight> GetAllFlights()
        {
            using (var _context = new DiemServiceDB())
            {
                //_context.ThePurge();
                List<Flight> retVal = _context.FlightDbSet.ToList();
                return retVal;

            }
        }

        public static void AddFlight(FlightForm flight)
        {
            using (var _context = new DiemServiceDB())
            {
                Flight toAdd = flight.toFlight();
                toAdd.To_Location = _context.LocationDbSet.Add(toAdd.To_Location);
                toAdd.From_Location = _context.LocationDbSet.Add(toAdd.From_Location);
                _context.FlightDbSet.Add(toAdd);
                _context.SaveChanges();

            }
        }

        public static void ModifyFlight(FlightFormUpdate modifyValues)
        {
        
            using (var _context = new DiemServiceDB())
            {
                Flight Modify = _context.FlightDbSet.Find(Int32.Parse(modifyValues.Id));
                
                if (Modify == null)
                    throw new Exception("Asked flight ID is not present in the database");
                if (!string.IsNullOrEmpty(modifyValues.Price))
                    Modify.Price = new Price(Double.Parse(modifyValues.Price));
                if (modifyValues.Flight_Arrival_Time != null)
                {
                    Modify.Flight_Arrival_Time = modifyValues.Flight_Arrival_Time;
                    Modify.Flight_Duration = (Modify.Flight_Arrival_Time - Modify.Flight_Departure_Time).ToString();// TRIGGER NAPRAVITI
                }
                if (modifyValues.Flight_Departure_Time != null)
                {
                    Modify.Flight_Departure_Time = modifyValues.Flight_Departure_Time;
                    Modify.Flight_Duration = (Modify.Flight_Arrival_Time - Modify.Flight_Departure_Time).ToString();// TRIGGER NAPRAVITI
                }
                if (!string.IsNullOrEmpty(modifyValues.FromLocation))
                    Modify.From_Location = _context.LocationDbSet.Add(new Location(modifyValues.FromLocation)); 
                if (!string.IsNullOrEmpty(modifyValues.ToLocation))
                    Modify.To_Location = _context.LocationDbSet.Add(new Location(modifyValues.ToLocation));
                _context.SaveChanges();

            }
        }

        public static void DeleteFlight(int ID )
        {
            using(var _context = new DiemServiceDB()) 
            {
                _context.FlightDbSet.Remove(_context.FlightDbSet.Find(ID));
                _context.SaveChanges();
            }
        }
    }
}