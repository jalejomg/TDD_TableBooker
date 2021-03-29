using Xunit;

namespace TableBooker
{
    public class TableBookerProcessorTests
    {
        //1st requiremet: The data entered must be returned
        [Fact]
        public void ReturnTableBookingResponseWithTheSameDataEntered()
        {
            var _processor = new TableBookerProcessor();

            //Create method to book a table
            _processor.BookTable();
        }
    }
}
