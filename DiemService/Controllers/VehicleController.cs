using DiemService.Database;
using DiemService.Forms;
using DiemService.ManageMeLikeOneOfYourDbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DiemService.Controllers
{
    [RoutePrefix("DiemApi")]
    public class VehicleController : ApiController
    {
        [HttpGet]
        [Route("Vehicles")]
        public HttpResponseMessage GetAllVehicles()
        {
            ICollection<Vehicle> temp = VehicleDbManager.GetAllVehicles();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, temp);
        }

        [HttpPost]
        [Route("Vehicles/Add")]
        public HttpResponseMessage AddVehicle ([FromBody]VehicleForm vehicleForm)
        {
            VehicleDbManager.AddVehicle(vehicleForm);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Vehicle/Delete")]
        public HttpResponseMessage DeleteVehicle([FromBody] int id)
        {
            VehicleDbManager.DeleteVehicle(id);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}