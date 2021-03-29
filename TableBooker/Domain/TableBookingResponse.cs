using System.Collections.Generic;

namespace TableBooker.Domain
{
    public class TableBookingResponse : TableBookingBase
    {
        public int? TableBookingId { get; set; }
        public DeskBookingResultCode Code { get; set; }

    }
}