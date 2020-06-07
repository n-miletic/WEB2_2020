using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class AdminDbManager
    {
        public static void PromoteUser(string username, Role role)
        {
            using (var _context = new DiemServiceDB())
            {
                User found = _context.UserDbSet.Where(user => user.Username == username).FirstOrDefault();
                found.Role = role;
                switch (role)
                {
                    case Role.AdminAvio:
                        AdminAvio toAdd = _context.AdminAvioDbSet.Add(new AdminAvio());
                        _context.SaveChanges();
                        found.UlogaID = toAdd.Id; 
                        break;
                    case Role.AdminRentACar:
                        AdminRent adminRent = _context.AdminRentDbSet.Add(new AdminRent());
                        _context.SaveChanges();
                        found.UlogaID = adminRent.Id;
                        break;
                    default:
                        break;
                }
                _context.SaveChanges();
            }
        }

        public static void AddRentCompany(string username, RentACar rent)
        {
            using (var _context = new DiemServiceDB())
            {
                User found = _context.UserDbSet.Where(user => user.Username == username).FirstOrDefault();
                _context.AdminRentDbSet.Find(found.UlogaID).OwnedRentServices.Add(rent);
                _context.SaveChanges();
            }
        }

        public static void AddAvioCompany(string username, AvioCompany ac)
        {
            using (var _context = new DiemServiceDB())
            {
                User found = _context.UserDbSet.Where(user => user.Username == username).FirstOrDefault();
                _context.AdminAvioDbSet.Find(found.UlogaID).OwnedAvioCompanies.Add(ac);
                _context.SaveChanges();
            }
        }

    }
}