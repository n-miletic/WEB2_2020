using DiemService.Database;
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
    public class UsersController : ApiController
    {

        [HttpGet]
        [Route("User/Get")]
        public HttpResponseMessage GetUser([FromBody] string userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetUser(Int32.Parse(userId)));
        }

        [HttpPost]
        [Authorize]
        [Route("User/Edit")]
        public HttpResponseMessage EditUser(EditUserForm form)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.EditUser(form));
        }

        [HttpGet]
        [Authorize]
        [Route("User/GetLogged")]
        public HttpResponseMessage GetLoggedUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetLoggedUser(((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value));
        }
        
        [HttpGet]
        [Route("User/GetAll")]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetUsers());
        }

        [HttpGet]
        [Authorize]
        [Route("User/GetAll/Logged")]
        public HttpResponseMessage GetUsersLogged()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetUsers(((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value));
        }

        [HttpPost]
        [Route("User/AcceptRequest")]
        public HttpResponseMessage AcceptRequest(SignForm toUsername)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            UserDbManager.AcceptRequest(loggedUser.FindFirst("username").Value, toUsername.Username);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/SendRequest")]
        public HttpResponseMessage SendRequest(SignForm toUsername)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
           
            UserDbManager.SendRequest(loggedUser.FindFirst("username").Value, toUsername.Username);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("User/SignIn")]
        public HttpResponseMessage SignIn(SignForm credentials)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.LogIn(credentials.Username, credentials.Password));
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("User/Register")]
        public HttpResponseMessage Register([FromBody] TempUser userForm)
        {
            MailServiceManager.RegisterSendEmail(new TempUser(userForm));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("User/Activate/{activationID}")]
        public HttpResponseMessage ActivateUser([FromUri] string activationID)
        {
            MailServiceManager.RemoveExpiredLinks();
            MailServiceManager.ActivateUser(activationID);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/DeclineRequest")]
        public HttpResponseMessage DeclineRequest(SignForm toUsername)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            UserDbManager.DeclineRequest(loggedUser.FindFirst("username").Value, toUsername.Username);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("User/UnfriendRequest")]
        public HttpResponseMessage UnfriendRequest(SignForm toUsername)
        {
            ClaimsPrincipal loggedUser = (ClaimsPrincipal)HttpContext.Current.User;
            UserDbManager.UnfriendRequest(loggedUser.FindFirst("username").Value, toUsername.Username);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        [Route("User/GetHardcoreUsers")]
        public HttpResponseMessage GetHardcoreUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserDbManager.GetHardcoreUsers());
        }


    }
}
