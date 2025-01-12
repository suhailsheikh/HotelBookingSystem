using HotelBookingSystem.Extensions;

namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void RemoveEnclosingBrackets_StringContainsBrackets_ReturnInputValuesInsideTheBrackets()
        {
            string input = "Availability(H1, 20240901, SGL)";
            string expected = "H1, 20240901, SGL";

            string result = input.RemoveEnclosingBrackets();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveEnclosingBrackets_StringDoesNotContainAnyBrackets_ThrowsArgumentOutOfRangeException()
        {
            string input = "H1, 20240901, SGL";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => input.RemoveEnclosingBrackets());
        }
    }
}
