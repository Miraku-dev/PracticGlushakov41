using HotelBookingSystem.Services;
using HotelBookingSystem.ViewModels;
using System;
using System.Windows;

namespace HotelBookingSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DataContext = new MainViewModel(new BookingService());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}