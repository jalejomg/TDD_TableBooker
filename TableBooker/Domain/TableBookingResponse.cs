using System.Collections.Generic;

namespace TableBooker.Domain
{
    public class TableBookingResponse : TableBookingBase
    {
        public DeskBookingResultCode Code { get; set; }
    }
}