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
            //Arrange
            var request = new TableBookingRequest
            {
                FirstName = "Tekus",
                LastName = "Arkbox",
                Email = "tekuzeros@tekus.co",
                ReservationDate = new DateTime(2021, 6, 15)
            };

            var _processor = new TableBookerProcessor();

            //Act
            TableBookingResponse result = _processor.BookTable(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.FirstName, request.FirstName);
            Assert.Equal(result.LastName, request.LastName);
            Assert.Equal(result.Email, request.Email);
            Assert.Equal(result.ReservationDate, request.ReservationDate);
        }
    }
}
