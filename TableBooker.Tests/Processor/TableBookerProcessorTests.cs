using Moq;
using System;
using System.Collections.Generic;
using TableBooker.Domain;
using TableBooker.Repositories;
using Xunit;

namespace TableBooker.Processor
{
    public class TableBookerProcessorTests
    {
        private TableBookingRequest _request;
        private List<Table> _avaliableTables;
        private readonly TableBookerProcessor _processor;
        private Mock<ITableBookingRespository> _tableBookerRepositoyMock;
        private readonly Mock<ITableRepository> _tableRepositoryMock;

        public TableBookerProcessorTests()
        {
            _request = new TableBookingRequest
            {
                FirstName = "Tekus",
                LastName = "Arkbox",
                Email = "tekuzeros@tekus.co",
                ReservationDate = new DateTime(2021, 6, 15)
            };

            _avaliableTables = new List<Table> { new Table() };
            _tableBookerRepositoyMock = new Mock<ITableBookingRespository>();
            _tableRepositoryMock = new Mock<ITableRepository>();
            _tableRepositoryMock.Setup(repository => repository.GetAvaliableTables(_request.ReservationDate))
                .Returns(_avaliableTables);
            _processor = new TableBookerProcessor(_tableBookerRepositoyMock.Object, _tableRepositoryMock.Object);
        }

        //1st requiremet: The data entered must be returned
        [Fact]
        public void ReturnTableBookingResponseWithTheSameDataEntered()
        {
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
            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookTable(null));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }

        //3rd requirement: Must save the table booking
        [Fact]
        public void SaveTableBooking()
        {
            //Arrange
            TableBooking savedTableBooking = null;

            _tableBookerRepositoyMock.Setup(repository => repository.Save(It.IsAny<TableBooking>()))
                .Callback<TableBooking>(tableBooking =>
                {
                    savedTableBooking = tableBooking;
                });

            //Act
            _processor.BookTable(_request);

            _tableBookerRepositoyMock.Verify(repository => repository.Save(It.IsAny<TableBooking>()), Times.Once);

            //Assert
            Assert.NotNull(savedTableBooking);
            Assert.Equal(savedTableBooking.FirstName, _request.FirstName);
            Assert.Equal(savedTableBooking.LastName, _request.LastName);
            Assert.Equal(savedTableBooking.Email, _request.Email);
            Assert.Equal(savedTableBooking.ReservationDate, _request.ReservationDate);
        }

        //4th requirement: shouldn't save the reservation if there is no any table avaliable
        [Fact]
        public void DoNotSaveTableBookingIfThereIsNotAtLeastOneTableAvaliable()
        {
            _avaliableTables.Clear();

            _processor.BookTable(_request);

            _tableBookerRepositoyMock.Verify(repository => repository.Save(It.IsAny<TableBooking>()), Times.Never);
        }

        //5th requeriment: Return a code depending on the availability of the tables
        [Theory]
        [InlineData(TableBookingResultCode.Success, true)]
        [InlineData(TableBookingResultCode.NoTableAvaliable, false)]
        public void ReturnCodeDeppendingTheTablesAvailability(TableBookingResultCode expectedResultCode, bool isTableAvaliable)
        {
            if (!isTableAvaliable) _avaliableTables.Clear();

            var result = _processor.BookTable(_request);

            Assert.Equal(expectedResultCode, result.Code);
        }

        //6th requirement: Respons model has to include the Id TableBooking (reservation id)
        [Theory]
        [InlineData(5, true)]
        [InlineData(null, false)]
        public void ReturnTableBookingIdIFThereIsAnyTableAvaliable(int? expectedTableBookingId, bool isTableAvaliable)
        {
            if (!isTableAvaliable) _avaliableTables.Clear();
            else
            {
                _tableBookerRepositoyMock.Setup(repository => repository.Save(It.IsAny<TableBooking>()))
                    .Callback<TableBooking>(tableBooking =>
                    {
                        tableBooking.Id = expectedTableBookingId.Value;
                    });
            }

            var result = _processor.BookTable(_request);

            Assert.Equal(expectedTableBookingId, result.TableBookingId);
        }
    }
}
