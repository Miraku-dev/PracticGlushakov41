using System.Windows.Controls;
using HotelBookingSystem.Data;
using HotelBookingSystem.Repositories;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.Views;

public partial class BookingsView : UserControl
{
    public BookingsView()
    {
        InitializeComponent(); // Важно добавить эту строку
        
        var dbContext = new HotelDbContext();
        DataContext = new BookingViewModel(
            new BookingRepository(dbContext),
            new RoomRepository(dbContext)
        );
    }
}