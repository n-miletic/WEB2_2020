using DiemService.Database;
using DiemService.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Data.Entity;
namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class ReviewDbManager
    {
        public static void AddReview(ReviewForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                FlightReservation wanted = _context.FlightReservationDbSet.Where(u => u.Id == form.ReservationId).Include(u => u.User).Include(u=> u.Flight).Include(u=>u.Review).FirstOrDefault();
                if (wanted == null)
                    throw new Exception("");
                if (wanted.User.Username != caller)
                    throw new Exception("");

                wanted.Review = _context.ReviewDbSet.Add(new Review(found, form.Rating, form.Comment));
                _context.SaveChanges();
            }
        }
        public static void EditReview(ReviewForm form)
        {
            using (var _context = new DiemServiceDB())
            {
                string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                Review found = _context.ReviewDbSet.Where(u => u.Id == form.ReviewId).Include(u=> u.User).FirstOrDefault();
                if (found == null || found.User.Username != caller)
                    throw new Exception("");
                found.Stars = form.Rating;
                found.Comment = form.Comment;
                _context.SaveChanges();

            }
        }
    }
}