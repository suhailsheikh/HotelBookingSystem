using HotelBookingSystem.Extensions;
using HotelBookingSystem.Models;

namespace HotelBookingSystem
{
    /// <summary>
    /// The Booking Processor class.
    /// </summary>
    public class BookingProcessor
    {
        private List<Hotel> Hotels { get; set; }
        private List<Booking> Bookings { get; set; }

        /// <summary>
        /// Initialises a new instance of <see cref="BookingProcessor"/>
        /// </summary>
        /// <param name="hotels">The list of hotels.</param>
        /// <param name="bookings">The list of bookings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BookingProcessor(List<Hotel> hotels, List<Booking> bookings)
        {
            Hotels = hotels ?? throw new ArgumentNullException(nameof(hotels));
            Bookings = bookings ?? throw new ArgumentNullException(nameof(bookings));
        }

        /// <summary>
        /// Checks the room availability.
        /// </summary>
        /// <param name="command">The command e.g. "Availability(H1, 20240901, SGL)"</param>
        public virtual void CheckAvailability(string command)
        {
            string input = command.RemoveEnclosingBrackets();
            string[] searchCriteria = input.Split([", "], StringSplitOptions.None);

            string hotelId = searchCriteria[0].ToUpper();
            string roomType = searchCriteria[2].ToUpper();

            string[] dateRange = searchCriteria[1].Split('-');
            DateTime startDate = dateRange[0].ConvertToDateTime();
            DateTime endDate = dateRange.Length == 2 ? dateRange[1].ConvertToDateTime() : startDate;

            var hotel = this.Hotels.FirstOrDefault(x => x.Id == hotelId);

            if (hotel is null)
            {
                Console.WriteLine("The hotel cannot be found.");
                return;
            }

            var availableRooms = hotel.Rooms.Count(x => x.RoomType == roomType);

            var bookedRooms = this.Bookings
                .Where(x => x.HotelId == hotelId && x.RoomType == roomType && !(x.DepartureDate < startDate || x.ArrivalDate > endDate))
                .Count();

            Console.WriteLine($"Rooms available: {availableRooms - bookedRooms}");
        }

        /// <summary>
        /// Search for available rooms.
        /// </summary>
        /// <param name="command">The command e.g. "Search(H1, 365, SGL)"</param>
        public void Search(string command)
        {
            string input = command.RemoveEnclosingBrackets();
            string[] searchCriteria = input.Split([", "], StringSplitOptions.None);

            string hotelId = searchCriteria[0].ToUpper();
            string roomType = searchCriteria[2].ToUpper();

            int.TryParse(searchCriteria[1], out int noOfDaysAhead);

            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(noOfDaysAhead);

            var hotel = this.Hotels.FirstOrDefault(x => x.Id == hotelId);

            if (hotel is null)
            {
                Console.WriteLine("The hotel cannot be found.");
                return;
            }

            var availabilityPeriods = new List<string>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var availableRooms = hotel.Rooms.Count(x => x.RoomType == roomType);

                var bookedRooms = this.Bookings
                    .Where(x => x.HotelId == hotelId && x.RoomType == roomType && !(x.DepartureDate < date || x.ArrivalDate > date))
                    .Count();

                var availability = availableRooms - bookedRooms;

                if (availability > 0)
                {
                    availabilityPeriods.Add($"({date:yyyyMMdd}, {availability})");
                }
            }

            Console.WriteLine(string.Join(", ", availabilityPeriods));
        }
    }
}
