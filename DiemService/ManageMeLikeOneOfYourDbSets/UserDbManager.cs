using DiemService.Authorization;
using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
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

        public static User GetLoggedUser(string username)
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.Where(user => user.Username == username).FirstOrDefault();
            }
        }



        public static List<User> GetUsers()
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.ToList(); 
            }
        }

        public static List<User> GetUsers(string loggedUsername)
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.UserDbSet.Where(u => u.Username != loggedUsername).ToList();
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

        public static UserGift LogIn(string username,string password)
        {
            using(var _context = new DiemServiceDB())
            {
                User logIn = _context.UserDbSet.Where(s => s.Username == username).FirstOrDefault();
                if ( logIn != null)
                {
                    if(logIn.Hash == password)
                    {
                        return new UserGift(TokenManager.GetToken(logIn),logIn);
                    }
                }
                throw new Exception("wrong password or user doenst exist");
            }
        }

        public static void SendRequest(string from, string to)
        {
            using(var _context = new DiemServiceDB())
            {
                User fromUser = _context.UserDbSet.Where(s => s.Username == from).FirstOrDefault();
                User toUser = _context.UserDbSet.Where(s => s.Username == to).FirstOrDefault();
                toUser.FriendRequests.Add(fromUser);
            }
        }


    }
}