using System;
using TableBooker.Domain;
using TableBooker.Repositories;

namespace TableBooker.Processor
{
    public class TableBookerProcessor
    {
        public ITableBookingRespository _tableBookingRespository { get; }
        public TableBookerProcessor(ITableBookingRespository tableBookingRespository)
        {
            _tableBookingRespository = tableBookingRespository;
        }

        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            _tableBookingRespository.Save(Create<TableBooking>(request));

            return Create<TableBookingResponse>(request);
        }

        private T Create<T>(TableBookingRequest request) where T : TableBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ReservationDate = request.ReservationDate
            };
        }
    }
}