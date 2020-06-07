using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public class ReservationDbManager
    {
        public static void AddFlightReservation(int myid, int flightid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).FlightReservations.Add(_context.FlightDbSet.Find(flightid));
                _context.SaveChanges();
            }
        }

        public static void CancelFlightReservation(int myid, int flightid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).FlightReservations.Remove(_context.FlightDbSet.Find(flightid));
                _context.SaveChanges();
            }
        }

        public static void AddVehicleReservation(int myid, int vehicleid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).VehicleReservations.Add(_context.VehicleDbSet.Find(vehicleid));
                _context.SaveChanges();
            }
        }

        public static void CancelVehicleReservation(int myid, int vehicleid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).VehicleReservations.Remove(_context.VehicleDbSet.Find(vehicleid));
                _context.SaveChanges();
            }
        }
    }
}