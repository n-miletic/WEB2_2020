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
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("User/Get")]
        public HttpResponseMessage GetUser([FromBody] string userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetUser(Int32.Parse(userId)));
        }

        [HttpGet]
        [Route("User/GetAll")]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetUsers());
        }

        [HttpPost]
        [Route("User/AcceptRequest")]
        public HttpResponseMessage AcceptRequest([FromBody]string myid, string personid )
        {
            UserDbManager.AcceptRequest(Int32.Parse(myid), Int32.Parse(personid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/DeclineRequest")]
        public HttpResponseMessage DeclineRequest([FromBody]string myid, string personid)
        {
            UserDbManager.DeclineRequest(Int32.Parse(myid), Int32.Parse(personid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/AddFlightReservation")]
        public HttpResponseMessage AddFlightReservation([FromBody]string myid, string flightid)
        {
            UserDbManager.AddFlightReservation(Int32.Parse(myid), Int32.Parse(flightid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/CancelFlightReservation")] // moras i za vehicle add/cancel 
        public HttpResponseMessage CancelFlightReservation([FromBody]string myid, string flightid)
        {
            UserDbManager.CancelFlightReservation(Int32.Parse(myid), Int32.Parse(flightid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/AddVehicleReservation")]
        public HttpResponseMessage AddVehicleReservation([FromBody]string myid, string vehicleid)
        {
            UserDbManager.AddVehicleReservation(Int32.Parse(myid), Int32.Parse(vehicleid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/CancelVehicleReservation")]
        public HttpResponseMessage CancelVehicleReservation([FromBody]string myid, string vehicleid)
        {
            UserDbManager.CancelVehicleReservation(Int32.Parse(myid), Int32.Parse(vehicleid));
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
