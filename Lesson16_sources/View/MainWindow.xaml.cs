using System.Windows;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() != true)
            {
                Close();
                return;
            }
            DataContext = new HotelViewModel();
        }
    }
}