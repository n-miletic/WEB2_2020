using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using DiemService.Forms;
using System.Security.Claims;
using System.Text;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class AvioCompanyDbManager
    {
        public static AvioCompany GetById(int id)
        {
            using (var _context = new DiemServiceDB())
            {
                AvioCompany retVal = _context.AvioCompanyDbSet.Where(u => u.Id == id)
                                                .Include(x => x.Owner)
                                                .Include(y => y.Flights)
                                                .Include(y => y.Flights.Select(x => x.To_Location))
                                                .Include(y => y.Flights.Select(x => x.From_Location))
                                                .Include(y => y.Flights.Select(x => x.Provider))
                                                .Include(y => y.Flights.Select(x => x.Transits))
                                                .Include(y => y.Flights.Select(x => x.Reservations))
                                                .Include("Flights.Reservations.Review")
                                                 .Include("Flights.Reservations.Review.User")
                                                .Include(z=> z.Destinations)
                                                .Include(i=> i.Address)
                                                .FirstOrDefault();
                Byte[] img = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/" + retVal.Logo);
                retVal.Logo = Convert.ToBase64String(img);
                return retVal;

            }
        }

        public static void EditAvio(AvioCompanyEditForm form,int id)
        {
            if(form != null)
            using (var _context = new DiemServiceDB())
            {

                AvioCompany retVal = _context.AvioCompanyDbSet.Where(u => u.Id == id)
                                                .Include(x => x.Owner)
                                                .Include(y => y.Flights)
                                                .Include(z => z.Destinations)
                                                .Include(i => i.Address)
                                                .FirstOrDefault();
                    string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                    User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                    if (found.Role != Role.Admin && found.Username != retVal.Owner.Username)
                        return;
                    if (form.Name != null)
                        retVal.Name = form.Name;
                    if (form.Promo_description != null)
                        retVal.Promo_description = form.Promo_description;
                    if (form.Address != null)
                        retVal.Address.State = form.Address;
                    _context.SaveChanges();
            }
        }
        public static void AddSpecialOffer(AddOfferForm form)
        {
            if (form == null || form.seatsToDiscount == null || form.slashedPrice == 0 || form.flightId == 0)
                throw new Exception("BAD QUERY");
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                Flight flight = _context.FlightDbSet.Where(u => u.Id == form.flightId).Include(u => u.Provider).Include(u => u.Provider.Owner).FirstOrDefault();
                if (flight == null)
                    throw new Exception("BAD QUERY");
                if(found.Username != flight.Provider.Owner.Username || flight.Price.Value < form.slashedPrice)
                    throw new Exception("BAD QUERY");

                StringBuilder sb = new StringBuilder(flight.Seats);
                foreach (int item in form.seatsToDiscount)
                {
                    if (sb[item] == '1')
                        throw new Exception("SEAT ALREADY TAKEN");
                    sb[item] = '5';
                }
                
                flight.Seats = sb.ToString();
                flight.DiscountedPrice = form.slashedPrice;
                _context.SaveChanges();


            }
        }
  

    }
}