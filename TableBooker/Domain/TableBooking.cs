namespace TableBooker.Domain
{
    public class TableBooking : TableBookingBase
    {
        public int Id { get; set; }
        public int TableId { get; internal set; }
    }
}
