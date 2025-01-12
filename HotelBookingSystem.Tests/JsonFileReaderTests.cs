using HotelBookingSystem.Models;
using System.Reflection;

namespace HotelBookingSystem.Tests
{
    [TestClass]
    public class JsonFileReaderTests
    {
        [TestMethod]
        public void Read_LoadDataFromTheHotelsJsonFile_ReturnADeserializedObject()
        {
            var expected = new List<Hotel>
            {
                new Hotel
                {
                    Id = "H1",
                    Name = "Hotel California",
                    RoomTypes = new List<RoomType>
                    {
                        new RoomType
                        {
                            Code = "SGL",
                            Description = "Single Room",
                            Amenities = ["WiFi", "TV"],
                            Features = ["Non-Smoking"],
                        },
                        new RoomType
                        {
                            Code = "DBL",
                            Description = "Double Room",
                            Amenities = ["WiFi", "TV", "Minibar"],
                            Features = ["Non-Smoking", "Sea View"],
                        }
                    },
                    Rooms = new List<Room>()
                    {
                        new Room { RoomType = "SGL", RoomId = 101 },
                        new Room { RoomType = "SGL", RoomId = 102 },
                        new Room { RoomType = "DBL", RoomId = 201 },
                        new Room { RoomType = "DBL", RoomId = 202 }
                    }
                }
            };

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Directory.Exists(path))
            {
                var result = JsonFileReader.Read<List<Hotel>>(Path.Combine(path, @"App_Data\hotels.json"));

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == expected.Count);
                Assert.IsTrue(result[0].Name == expected[0].Name);
                Assert.IsTrue(result.First().Rooms.Count == expected.First().Rooms.Count);
            }
        }

        [TestMethod]
        public void Read_LoadDataFromTheBookingsJsonFile_ReturnADeserializedObject()
        {
            var expected = new List<Booking>
            {
                new Booking { HotelId = "H1", Arrival = "20240901", Departure = "20240903", RoomType = "DBL", RoomRate = "Prepaid" },
                new Booking { HotelId = "H1", Arrival = "20240902", Departure = "20240905", RoomType = "SGL", RoomRate = "Standard" }
            };

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Directory.Exists(path))
            {
                var result = JsonFileReader.Read<List<Booking>>(Path.Combine(path, @"App_Data\bookings.json"));

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == expected.Count);
            }
        }
    }
}
