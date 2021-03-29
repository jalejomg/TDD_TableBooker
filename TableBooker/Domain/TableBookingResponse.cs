using System.Collections.Generic;

namespace TableBooker.Domain
{
    public class TableBookingResponse : TableBookingBase
    {
        public int? TableBookingId { get; set; }
        public TableBookingResultCode Code { get; set; }

    }
}