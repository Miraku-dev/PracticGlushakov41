using HotelBookingSystem.Commands;
using HotelBookingSystem.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingSystem.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Booking> Bookings { get; } = new ObservableCollection<Booking>();
        public ObservableCollection<Room> Rooms { get; } = new ObservableCollection<Room>();

        public ICommand BookRoomCommand { get; }
        public ICommand EditBookingCommand { get; }
        public ICommand CancelBookingCommand { get; }

        public MainViewModel()
        {
            InitializeTestData();

            BookRoomCommand = new RelayCommand(_ => BookRoom());
            EditBookingCommand = new RelayCommand(_ => EditBooking(), _ => Bookings.Count > 0);
            CancelBookingCommand = new RelayCommand(param => CancelBooking(param), _ => Bookings.Count > 0);
        }

        private void InitializeTestData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Rooms.Add(new Room
                {
                    Number = i,
                    Type = i % 2 == 0 ? "Standard" : "Deluxe",
                    PricePerNight = i % 2 == 0 ? 100 : 150
                });
            }
        }

        private void BookRoom()
        {
            var bookingWindow = new BookingWindow(this);
            bookingWindow.Owner = Application.Current.MainWindow;
            bookingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bookingWindow.ShowDialog();
        }

        private void EditBooking()
        {
            MessageBox.Show("Окно редактирования брони", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelBooking(object parameter)
        {
            if (parameter is Booking booking)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите отменить бронь №{booking.Id}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Bookings.Remove(booking);
                    MessageBox.Show("Бронь отменена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите бронь для отмены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}