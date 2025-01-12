using HotelBookingSystem.Extensions;

namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class DateExtensionsTests
    {
        [TestMethod]
        public void ConvertToDateTime_DateAsAString_ReturnANewDateTimeObject()
        {
            string date = "20240901";
            var expected = new DateTime(2024, 09, 01);

            var result = date.ConvertToDateTime();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertToDateTime_IncorrectDate_ThrowFormatException()
        {
            string date = "2024090901";
            Assert.ThrowsException<FormatException>(() => date.ConvertToDateTime());
        }
    }
}
