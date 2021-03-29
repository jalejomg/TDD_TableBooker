using System;

namespace TableBooker
{
    internal class TableBookerProcessor
    {
        public TableBookerProcessor()
        {
        }

        internal TableBookingResponse BookTable(TableBookingRequest request)
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