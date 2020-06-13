using DiemService.Forms;
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
        [Authorize]
        [Route("User/AddFlightReservation")]
        public HttpResponseMessage AddFlightReservation(ReservationForm form )
        {
            ReservationDbManager.AddFlightReservation(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/AddFastFlightReservation")]
        public HttpResponseMessage AddFastFlightReservation(ReservationForm form)
        {
            ReservationDbManager.AddFastFlightReservation(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/AddRandomFlightReservation")]
        public HttpResponseMessage AddRandomFlightReservation(ReservationForm form)
        {
            ReservationDbManager.AddRandomFlightReservation(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/InviteReservation")]
        public HttpResponseMessage InviteUser(ReservationForm form)
        {
            ReservationDbManager.InviteUser(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/CancelFlightReservation/{reservationId}")] // moras i za vehicle add/cancel 
        public HttpResponseMessage CancelFlightReservation([FromUri]int reservationId)
        {
            ReservationDbManager.CancelFlightReservation(reservationId);
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
