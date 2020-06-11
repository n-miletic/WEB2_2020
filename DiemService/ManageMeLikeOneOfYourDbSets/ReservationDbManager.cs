using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public class ReservationDbManager
    {
        public static void AddFlightReservation(ReservationForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                if (found.Role != Role.RegisteredUser || found == null)
                    return;
                
                Flight wanted = _context.FlightDbSet.Where(u => u.Id == form.FlightId).FirstOrDefault();
                StringBuilder sb = new StringBuilder(wanted.Seats);
                sb[form.Seat] = '1';
                wanted.Seats = sb.ToString();
                FlightReservation fr = _context.FlightReservationDbSet.Add(new FlightReservation(found.Name, found.LastName, form.Seat, form.Passport, found, wanted));
                 _context.RegisteredUserDbSet.Where(u => u.Id == found.UlogaID).First().FlightReservations.Add(fr);
                MailServiceManager.SendReservationEmail(fr);
                wanted.Reservations.Add(fr);
                _context.SaveChanges();
            }
        }

        public static void AddRandomFlightReservation(ReservationForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                Flight wanted = _context.FlightDbSet.Where(u => u.Id == form.FlightId).FirstOrDefault();
                StringBuilder sb = new StringBuilder(wanted.Seats);
                sb[form.Seat] = '1';
                wanted.Seats = sb.ToString();
                FlightReservation fr = _context.FlightReservationDbSet.Add(new FlightReservation(form.Name, form.LastName, form.Seat, form.Passport, wanted));
                wanted.Reservations.Add(fr);
                _context.SaveChanges();
            }
        }

        public static void InviteUser(ReservationForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User instigator = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                User invited = _context.UserDbSet.Where(u => u.Username == form.InvitedUsername).FirstOrDefault();
                Flight wanted = _context.FlightDbSet.Where(u => u.Id == form.FlightId).FirstOrDefault();
                if (invited.Role != Role.RegisteredUser || invited == null)
                    return;
                FlightReservation fr = _context.FlightReservationDbSet.Add(new FlightReservation(invited.Name, invited.LastName, form.Seat, invited, wanted) { Invited_By = instigator});
                _context.RegisteredUserDbSet.Where(u => u.Id == invited.UlogaID).First().FlightReservations.Add(fr);
                MailServiceManager.SendInvitationEmail(fr);
                _context.SaveChanges();
            }
        }

        public static void AcceptReservation(int flight_id)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User chased = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                Flight wanted = _context.FlightDbSet.Where(u => u.Id == flight_id).FirstOrDefault();
                //flight id or reservation id?
            }
        }
        public static void CancelFlightReservation(int myid, int flightid)
        {
            using (var _context = new DiemServiceDB())
            {
                //_context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).FlightReservations.Remove(_context.FlightDbSet.Find(flightid));
                //_context.SaveChanges();
            }
        }

        public static void AddVehicleReservation(int myid, int vehicleid)
        {
            using (var _context = new DiemServiceDB())
            {
                //_context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).VehicleReservations.Add(_context.VehicleDbSet.Find(vehicleid));
                //_context.SaveChanges();
            }
        }

        public static void CancelVehicleReservation(int myid, int vehicleid)
        {
            using (var _context = new DiemServiceDB())
            {
                //_context.RegisteredUserDbSet.Find(_context.UserDbSet.Find(myid).UlogaID).VehicleReservations.Remove(_context.VehicleDbSet.Find(vehicleid));
                //_context.SaveChanges();
            }
        }
    }
}