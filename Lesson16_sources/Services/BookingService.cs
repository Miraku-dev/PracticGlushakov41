using System.Threading.Tasks;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.Services
{
    public class BookingService
    {
        private readonly DataService _dataService;

        public BookingService(DataService dataService)
        {
            _dataService = dataService;
        }

        public async Task BookRoom(BookingViewModel bookingViewModel)
        {
            await Task.Delay(3000); // Имитация задержки
            var booking = new BookingModel
            {
                FullName = bookingViewModel.FullName,
                CheckInDate = bookingViewModel.CheckInDate,
                CheckOutDate = bookingViewModel.CheckOutDate,
                RoomNumber = bookingViewModel.RoomNumber
            };
            _dataService.SaveBooking(booking);
        }
    }
}