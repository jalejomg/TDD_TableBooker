using TableBooker.Domain;

namespace TableBooker.Repositories
{
    public interface ITableBookingRespository
    {
        public void Save(TableBooking tableBooking);
    }
}
