using System.Text.Json;

namespace HotelBookingSystem
{
    /// <summary>
    /// The JsonFileReader class.
    /// </summary>
    public static class JsonFileReader
    {
        /// <summary>
        /// Reads the contents of the file and deserializes the object into an instance of the type specified. 
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="path">The file path.</param>
        /// <returns>A deserialized object.</returns>
        public static T Read<T>(string path)
        {
            string text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}
