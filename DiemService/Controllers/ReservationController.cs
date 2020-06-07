using DiemService.ManageMeLikeOneOfYourDbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DiemService.Controllers
{
    [RoutePrefix("DiemApi")]
    public class ReservationController : ApiController
    {
        [HttpPost]
        [Route("User/AddFlightReservation")]
        public HttpResponseMessage AddFlightReservation([FromBody]string myid, string flightid)
        {
            ReservationDbManager.AddFlightReservation(Int32.Parse(myid), Int32.Parse(flightid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/CancelFlightReservation")] // moras i za vehicle add/cancel 
        public HttpResponseMessage CancelFlightReservation([FromBody]string myid, string flightid)
        {
            ReservationDbManager.CancelFlightReservation(Int32.Parse(myid), Int32.Parse(flightid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/AddVehicleReservation")]
        public HttpResponseMessage AddVehicleReservation([FromBody]string myid, string vehicleid)
        {
            ReservationDbManager.AddVehicleReservation(Int32.Parse(myid), Int32.Parse(vehicleid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/CancelVehicleReservation")]
        public HttpResponseMessage CancelVehicleReservation([FromBody]string myid, string vehicleid)
        {
            ReservationDbManager.CancelVehicleReservation(Int32.Parse(myid), Int32.Parse(vehicleid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
