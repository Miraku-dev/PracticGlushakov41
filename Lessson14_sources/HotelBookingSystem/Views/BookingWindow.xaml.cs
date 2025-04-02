using HotelBookingSystem.ViewModels;
using System.Windows;

namespace HotelBookingSystem
{
    public partial class BookingWindow : Window
    {
        public BookingWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            DataContext = new BookingViewModel(mainViewModel);
        }

    }
}