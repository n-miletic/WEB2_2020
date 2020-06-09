using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class VehicleForm
    {
        public string PickUpLocation { get; set; }
        public string Information { get; set; }
        public string Price { get; set; }

        public Vehicle NewVehicle()
        {
            Location pickUpLocation = new Location(PickUpLocation.Split(',')[1], PickUpLocation.Split(',')[0]);
            double.TryParse(Price, out double vehiclePrice);

            return new Vehicle(pickUpLocation, Information, vehiclePrice);
        }
    }
}