using HotelBookingSystem;
using HotelBookingSystem.Models;
using System.Reflection;

Console.WriteLine("Welcome to the Hotel Booking System");
Console.WriteLine("-----------------------------------");

var data = LoadJson();
var processor = new BookingProcessor(data.hotels, data.bookings);

string command = string.Empty;

while (!string.IsNullOrWhiteSpace(command = Console.ReadLine()))
{
    if (command.StartsWith("Availability", StringComparison.CurrentCultureIgnoreCase))
    {
        processor.CheckAvailability(command);
    }
    else if (command.StartsWith("Search", StringComparison.CurrentCultureIgnoreCase))
    {
        processor.Search(command);
    }
}

static (List<Hotel> hotels, List<Booking> bookings) LoadJson()
{
    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    if (Directory.Exists(path))
    {
        var hotels = JsonFileReader.Read<List<Hotel>>(Path.Combine(path, @"App_Data\hotels.json"));
        var bookings = JsonFileReader.Read<List<Booking>>(Path.Combine(path, @"App_Data\bookings.json"));

        return (hotels, bookings);
    }

    return (new List<Hotel>(), new List<Booking>());
}