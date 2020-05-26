using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class UserDbManager
    {
        public static User GetUser(int userid)
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.Find(userid);
            }
        }

        public static List<User> GetUsers()
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.ToList(); //exclude yourself in front end
            }
        }

        public static void AcceptRequest(int myid, int personid)
        {
            using (var _context = new DiemServiceDB())
            {
                User toAdd = _context.UserDbSet.Find(personid);
                _context.UserDbSet.Find(myid).FriendRequests.Remove(toAdd);
                _context.UserDbSet.Find(myid).Friends.Add(toAdd);
                _context.SaveChanges();
            }
        }

        public static void DeclineRequest(int myid, int personid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.UserDbSet.Find(myid).FriendRequests.Remove(_context.UserDbSet.Find(personid));
                _context.SaveChanges();
            }
        }

        public static void AddFlightReservation(int myid,int flightid)
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

        public static void CancelVehicleReservation(int myid,int vehicleid)
        {
            using (var _context = new DiemServiceDB())
            {
                _context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).VehicleReservations.Remove(_context.VehicleDbSet.Find(vehicleid));
                _context.SaveChanges();
            }
        }

    }
}