using System.Windows;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.View
{
    public partial class BookingWindow : Window
    {
        public BookingWindow(RoomModel room)
        {
            InitializeComponent();
            DataContext = new BookingViewModel(room);
        }

        private void BookCommand_Executed(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}