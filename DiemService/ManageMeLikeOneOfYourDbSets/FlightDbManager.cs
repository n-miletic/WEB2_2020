using DiemService.Database;
using DiemService.Forms;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Security.Claims;

namespace DiemService.Controllers
{
    public static  class FlightDbManager
    {
        public static List<Flight> SearchFlights(SearchFlightForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                List<Flight> retVal = new List<Flight>();
                if (form.Flight_Arrival_Time == null || form.Flight_Departure_Time == null || form.From_Location == null || form.To_Location == null)
                    throw new Exception("BAD QUERY VERY BAD QUERY");
                retVal = _context.FlightDbSet.Include(x => x.From_Location).Include(x => x.To_Location).Include(x => x.Transits).Include(x=>x.Provider)
                                             .Where(x => x.To_Location.State == form.To_Location 
                                                 && x.From_Location.State == form.From_Location 
                                                 && DbFunctions.TruncateTime(x.Flight_Arrival_Time) == form.Flight_Arrival_Time.Date
                                                 && DbFunctions.TruncateTime(x.Flight_Departure_Time) == form.Flight_Departure_Time.Date)
                                             .ToList();
                if (form.Free_seats != 0)
                   retVal =  retVal.Where(u => u.Seats.Count(x => x == '0') > form.Free_seats).ToList();
                if (form.Flight_class != 0)
                    retVal = retVal.Where(u => u.FlightClass == form.Flight_class).ToList();

                return retVal;
            }
        }
        public static List<Flight> GetAllFlights()
        {
            using (var _context = new DiemServiceDB())
            {
                //_context.ThePurge();
                List<Flight> retVal = _context.FlightDbSet.Include(x => x.From_Location)
                                                           .Include(x => x.To_Location)
                                                           .Include(x => x.Transits)
                                                           .Include(x=>x.Provider)
                                                           .ToList();
                    
                return retVal;

            }
        }

        public static void AddFlight(FlightForm flight,int avioId)
        {
            using (var _context = new DiemServiceDB())
            {
                if (flight.FlightClass == 0 || flight.seats == 0 || flight.Flight_Arrival_Time == null || flight.Flight_Departure_Time == null || flight.fromLocation == null || flight.toLocation == null || flight.price == null ||
                    flight.Flight_Departure_Time < DateTime.Now || 
                    flight.Flight_Departure_Time.Date > flight.Flight_Arrival_Time.Date
                    )
                {
                    throw new Exception("BAD QEURY");
                }
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User loggedUser = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                AvioCompany found = _context.AvioCompanyDbSet.Where(u => u.Id == avioId).Include(x => x.Owner).FirstOrDefault();
                if (loggedUser.Role != Role.Admin && loggedUser.Username != found.Owner.Username)
                    return;
                Flight toAdd = flight.toFlight();
                toAdd.To_Location = _context.LocationDbSet.Add(toAdd.To_Location);
                toAdd.From_Location = _context.LocationDbSet.Add(toAdd.From_Location);
                toAdd.Provider = found;
                found.Flights.Add(_context.FlightDbSet.Add(toAdd));
                _context.SaveChanges();

            }
        }

        public static void AvioAddFlight(FlightForm flight)
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