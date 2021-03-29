using System;
using System.Linq;
using TableBooker.Domain;
using TableBooker.Repositories;

namespace TableBooker.Processor
{
    public class TableBookerProcessor
    {
        public ITableBookingRespository _tableBookingRespository { get; }
        public ITableRepository _tableRepository { get; }

        public TableBookerProcessor(ITableBookingRespository tableBookingRespository, ITableRepository tableRepository)
        {
            _tableBookingRespository = tableBookingRespository;
            _tableRepository = tableRepository;
        }

        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var avaliableTables = _tableRepository.GetAvaliableTables(request.ReservationDate);

            var response = Create<TableBookingResponse>(request);

            if (avaliableTables.FirstOrDefault() is Table table)
            {
                var deskBooking = Create<TableBooking>(request);
                deskBooking.TableId = table.Id;
                _tableBookingRespository.Save(deskBooking);
                response.Code = TableBookingResultCode.Success;
                response.TableBookingId = deskBooking.Id;
            }
            else
            {
                response.Code = TableBookingResultCode.NoTableAvaliable;
            }

            return response;
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