using HotelBookingSystem.Models;
using HotelBookingSystem.ViewModels;
using System.Windows;

namespace HotelBookingSystem
{
    public partial class BookingWindow : Window
    {
        public BookingWindow(MainViewModel mainViewModel, Booking editingBooking = null)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            DataContext = new BookingViewModel(mainViewModel, editingBooking);
        }
    }
}