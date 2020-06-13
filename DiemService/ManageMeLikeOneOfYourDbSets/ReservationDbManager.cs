using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Data.Entity;
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
                if (found.Role != Role.RegisteredUser || found == null || form.FlightId == 0|| form.Seat == 0 || form.Passport == 0)
                    throw new Exception("BAD QUERY");
                
                Flight wanted = _context.FlightDbSet.Where(u => u.Id == form.FlightId).FirstOrDefault();
                StringBuilder sb = new StringBuilder(wanted.Seats);
                if (sb[form.Seat] != '0')
                    throw new Exception("ALREADY TAKEN OR BAD");
                sb[form.Seat] = '1';
                wanted.Seats = sb.ToString();
                FlightReservation fr = _context.FlightReservationDbSet.Add(new FlightReservation(found.Name, found.LastName, form.Seat, form.Passport, found, wanted));
                 _context.RegisteredUserDbSet.Where(u => u.Id == found.UlogaID).First().FlightReservations.Add(fr);
                MailServiceManager.SendReservationEmail(fr);
                wanted.Reservations.Add(fr);
                _context.SaveChanges();
            }
        }

        public static void AddFastFlightReservation(ReservationForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                if (found.Role != Role.RegisteredUser || found == null || form.FlightId == 0 /*|| form.Seat == 0*/ || form.Passport == 0)
                    throw new Exception("BAD QUERY");

                Flight wanted = _context.FlightDbSet.Where(u => u.Id == form.FlightId).FirstOrDefault();
                StringBuilder sb = new StringBuilder(wanted.Seats);
                if (sb[form.Seat] != '5')
                    throw new Exception("NOT AN OFFER");
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

        public static void AcceptReservation(int reservation_id)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User chased = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                FlightReservation wanted = _context.FlightReservationDbSet.Where(u => u.Id == reservation_id).Include(x=>x.Flight).Include(x=>x.User).Include(x=>x.Invited_By).FirstOrDefault();
                if (wanted == null || wanted.User.Username != caller)
                    throw new Exception("BAD QUERY");
                StringBuilder sb = new StringBuilder(wanted.Flight.Seats);
                if (sb[wanted.Seat_Reserved] == '1')
                    throw new Exception("ALREADY TAKEN OR BAD");
                sb[wanted.Seat_Reserved] = '1';
                wanted.Flight.Seats = sb.ToString();
                wanted.Invited_By = null;
                _context.SaveChanges();
            }
        }
        public static void CancelFlightReservation(int flightid)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                FlightReservation toCancel = _context.FlightReservationDbSet.Where(u => u.Id == flightid).Include(u => u.User).Include(u=> u.Flight).FirstOrDefault();
                if (toCancel.User.Username != caller)
                    throw new Exception("NOT AUTHORIZED");
                if (DateTime.Now.Date - toCancel.Flight.Flight_Departure_Time.Date < TimeSpan.FromDays(3))
                    throw new Exception("TOO LATE TO CANCEL");
                toCancel.Cancelled = true;
                StringBuilder sb = new StringBuilder(toCancel.Flight.Seats);
                sb[toCancel.Seat_Reserved] = '0';
                _context.SaveChanges();
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