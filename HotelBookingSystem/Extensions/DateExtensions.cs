using System.Globalization;

namespace HotelBookingSystem.Extensions
{
    /// <summary>
    /// The DateExtensions class.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Converts a string to a DateTime object.
        /// </summary>
        /// <param name="date">The date as a string (e.g. "20240901").</param>
        /// <returns>A new DateTime.</returns>
        public static DateTime ConvertToDateTime(this string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}
