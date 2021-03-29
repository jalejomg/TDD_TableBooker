using System;

namespace TableBooker
{
    internal class TableBookingResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}