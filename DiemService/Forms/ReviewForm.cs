using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class ReviewForm
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ReservationId { get; set; }
        public int ReviewId { get; set; }
    }
}