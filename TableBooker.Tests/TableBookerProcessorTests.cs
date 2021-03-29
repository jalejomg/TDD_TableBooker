using System;
using Xunit;

namespace TableBooker
{
    public class TableBookerProcessorTests
    {
        //1st requiremet: The data entered must be returned
        [Fact]
        public void ReturnTableBookingResponseWithTheSameDataEntered()
        {
            //Create request model
            var tableBookingRequest = new TableBookingRequest
            {
                FirstName = "Tekus",
                LastName = "Arkbox",
                Email = "tekuzeros@tekus.co",
                ReservationDate = new DateTime(2021, 6, 15)
            };

            var _processor = new TableBookerProcessor();

            //Create response model
            TableBookingResponse result = _processor.BookTable();
        }
    }
}
