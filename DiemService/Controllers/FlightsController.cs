using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static EntityDemo.CodeFirstTry1;

namespace DiemService.Controllers
{
    [RoutePrefix("DiemApi")]
    public class FlightsController : ApiController
    {
        [HttpGet]
        [Route("Flights")]
        public HttpResponseMessage GetFlights()
        {
            List<Let> letovi = new List<Let>();
            using (var _context = new LetoviDBContext())
            {
                letovi = _context.GetAllFlights();
            }
            return Request.CreateResponse(HttpStatusCode.OK, letovi);
        }
    }
}
