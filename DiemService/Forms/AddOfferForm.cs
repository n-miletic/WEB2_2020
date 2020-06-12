using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class AddOfferForm
    {
        public List<int> seatsToDiscount { get; set; }
        public int slashedPrice { get; set; }
        public int flightId { get; set; }
    }
}