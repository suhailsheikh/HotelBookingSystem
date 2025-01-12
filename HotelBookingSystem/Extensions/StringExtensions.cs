namespace HotelBookingSystem.Extensions
{
    /// <summary>
    /// The StringExtensions class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes the enclosing brackets from a string.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>A new string without the enclosing brackets.</returns>
        public static string RemoveEnclosingBrackets(this string str)
        {
            return str.Substring(str.IndexOf('(') + 1, str.IndexOf(')') - str.IndexOf('(') - 1);
        }
    }
}
