using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Model
{
    public class Booking
    {
        public long bookingId { get; set; }
        public Nullable<long> roomid { get; set; }
        public string statusOfBooking { get; set; }
        public string bookingDate { get; set; }
        public Nullable<long> hotelid { get; set; }
        public Nullable<int> isActive { get; set; }
    }
}
