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
    public class AvioCompanyController : ApiController
    {
        [HttpGet]
        [Route("AvioCompany/Get/{avioId}")]
        public HttpResponseMessage GetAviocompany([FromUri] int avioId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AvioCompanyDbManager.GetById(avioId));
        }
        [HttpPost]
        [Authorize]
        [Route("AvioCompany/Edit/{avioId}")]
        public HttpResponseMessage EditAviocompany([FromUri] int avioId,AvioCompanyEditForm form)
        {

            AvioCompanyDbManager.EditAvio(form, avioId);
            return Request.CreateResponse(HttpStatusCode.OK );
        }
    }
}
