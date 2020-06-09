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
    public class RentCompanyController : ApiController
    {
        [HttpGet]
        [Route("GetRentCompany")]
        public HttpResponseMessage GetAviocompany(IdForm idForm)
        {
            return Request.CreateResponse(HttpStatusCode.OK, RentCompanyDbManager.GetById(Int32.Parse(idForm.Id)));
        }
    }
}
