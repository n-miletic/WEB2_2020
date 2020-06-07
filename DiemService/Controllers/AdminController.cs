using DiemService.Forms;
using DiemService.ManageMeLikeOneOfYourDbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace DiemService.Controllers
{

    [RoutePrefix("DiemApi")]
    public class AdminController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route("Admin/PromoteUser")]
        public HttpResponseMessage PromoteUser(PromoteForm promote)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            //check if admin
            AdminDbManager.PromoteUser(promote.username, promote.role);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("Admin/AddRentCompany")]
        public HttpResponseMessage AddRent(AddRentForm promote)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            //check if admin
            AdminDbManager.AddRentCompany(promote.username, promote.toAdd);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("Admin/AddAvioCompany")]
        public HttpResponseMessage AddAvioCompany(AddAvioForm promote)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            //check if admin
            AdminDbManager.AddAvioCompany(promote.username, promote.toAdd);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
