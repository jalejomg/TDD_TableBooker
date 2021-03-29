using System;

namespace TableBooker
{
    public class TableBookerProcessor
    {
        public TableBookerProcessor()
        {
        }
        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            return new TableBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ReservationDate = request.ReservationDate
            };
        }
    }
}