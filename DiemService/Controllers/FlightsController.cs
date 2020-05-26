using DiemService.Database;
using DiemService.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DiemService.Controllers
{
    [RoutePrefix("DiemApi")]
    public class FlightsController : ApiController
    {

        [HttpGet]
        [Route("Flights")]
        public HttpResponseMessage GetFlights()
        {   
            return Request.CreateResponse(HttpStatusCode.OK, FlightDbManager.GetAllFlights());
        }

        [HttpPost]
        [Route("Flights/Add")]
        public HttpResponseMessage AddFlight([FromBody] FlightForm form)
        { 
            FlightDbManager.AddFlight(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("Flights/Update")]
        public HttpResponseMessage UpdateFlight([FromBody] FlightFormUpdate form)
        {
            FlightDbManager.ModifyFlight(form);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("Flights/Delete")]
        public HttpResponseMessage DeleteFlight([FromBody] int Id)
        {
            FlightDbManager.DeleteFlight(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
