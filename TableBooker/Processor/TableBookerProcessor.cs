using System;
using TableBooker.Domain;

namespace TableBooker.Processor
{
    public class TableBookerProcessor
    {
        public TableBookerProcessor()
        {
        }
        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

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