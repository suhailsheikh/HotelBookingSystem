namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class BookingProcessorTests
    {
        [TestMethod]
        public void BookingProcessor_NullParameters_ThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BookingProcessor(null, null));
        }
    }
}
