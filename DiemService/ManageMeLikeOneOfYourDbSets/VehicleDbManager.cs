using DiemService.Database;
using DiemService.Forms;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class VehicleDbManager
    {
        public static ICollection<Vehicle> GetAllVehicles()
        {
            using (var context = new DiemServiceDB())
            {
                ICollection<Vehicle> result = context.VehicleDbSet.Include(temp => temp.Location)
                                                                  .Include(temp => temp.Information)
                                                                  .ToList();
                return result;
            }
        }

        public static void AddVehicle(VehicleForm vehicle)
        {
            using (var context = new DiemServiceDB())
            {
                Vehicle newVehicle = vehicle.NewVehicle();
                // Is this actually necessary
                newVehicle.Location = context.LocationDbSet.Add(newVehicle.Location);
                context.VehicleDbSet.Add(newVehicle);
                context.SaveChanges();
            }
        }
        
        public static void DeleteVehicle(int id)
        {
            using(var context = new DiemServiceDB())
            {
                context.VehicleDbSet.Remove(context.VehicleDbSet.Find(id));
                context.SaveChanges();
            }
        }
    }
}