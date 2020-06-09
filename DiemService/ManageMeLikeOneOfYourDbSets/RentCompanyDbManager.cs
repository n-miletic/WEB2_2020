using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DiemService.Database;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class RentCompanyDbManager
    {
        public static RentACar GetById(int id)
        {
            using (var _context = new DiemServiceDB())
            {
                return _context.RentACarDbSet.Where(u => u.Id == id)
                                                .Include(x => x.Owner)
                                                .Include(y => y.Vehicles)
                                                .Include(z => z.Holdings)
                                                .FirstOrDefault();

            }
        }
    }
}