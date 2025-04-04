using HotelBookingSystem.Services;
using HotelBookingSystem.ViewModels;
using System;
using System.Windows;

namespace HotelBookingSystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bookingService = new BookingService();
            var mainVM = new MainViewModel(bookingService);

            var mainWindow = new MainWindow
            {
                DataContext = mainVM // Устанавливаем ViewModel здесь
            };

            mainWindow.Show();
        }
    }
}