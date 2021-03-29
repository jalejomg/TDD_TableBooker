using System;
using TableBooker.Domain;
using Xunit;

namespace TableBooker.Processor
{
    public class TableBookerProcessorTests
    {
        private TableBookingRequest _request;
        private readonly TableBookerProcessor _processor;

        public TableBookerProcessorTests()
        {
            _request = new TableBookingRequest
            {
                FirstName = "Tekus",
                LastName = "Arkbox",
                Email = "tekuzeros@tekus.co",
                ReservationDate = new DateTime(2021, 6, 15)
            };
            _processor = new TableBookerProcessor();
        }

        //1st requiremet: The data entered must be returned
        [Fact]
        public void ReturnTableBookingResponseWithTheSameDataEntered()
        {
            //Arrange         
            var _processor = new TableBookerProcessor();

            //Act
            TableBookingResponse result = _processor.BookTable(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.FirstName, _request.FirstName);
            Assert.Equal(result.LastName, _request.LastName);
            Assert.Equal(result.Email, _request.Email);
            Assert.Equal(result.ReservationDate, _request.ReservationDate);
        }

        //2nd requirement: Must throws an exception if request is null
        [Fact]
        public void ThrowExeptionIfRerquestModelIsNull()
        {
            //Arrange
            _request = null;           

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookTable(_request));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }
    }
}
