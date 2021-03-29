using Xunit;

namespace TableBooker
{
    public class TableBookerProcessorTests
    {
        //1st requiremet: The data entered must be returned
        [Fact]
        public void ReturnTableBookingResponseWithTheSameDataEntered()
        {
            //Create class to process table reservation requests
            var _processor = new TableBookerProcessor();
        }
    }
}
