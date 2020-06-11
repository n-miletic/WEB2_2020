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
    public class ReviewController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route("User/LeaveReview")]
        public HttpResponseMessage AddReview(ReviewForm reviewForm)
        {
            ReviewDbManager.AddReview(reviewForm);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [Route("User/EditReview")]
        public HttpResponseMessage EditReview(ReviewForm reviewForm)
        {
            ReviewDbManager.EditReview(reviewForm);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
