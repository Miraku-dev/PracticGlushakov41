using HotelBookingSystem.Commands;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Booking> Bookings { get; } = new ObservableCollection<Booking>();
        public ObservableCollection<Room> Rooms { get; } = new ObservableCollection<Room>();

        private Booking _selectedBooking;
        private readonly BookingService _bookingService;
        public Booking SelectedBooking

        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                OnPropertyChanged();
            }
        }

        public ICommand BookRoomCommand { get; }
        public ICommand EditBookingCommand { get; }
        public ICommand CancelBookingCommand { get; }

        public MainViewModel(BookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            InitializeTestData();

            foreach (var booking in _bookingService.GetBookings())
            {
                Bookings.Add(booking);
            }

            BookRoomCommand = new RelayCommand(_ => BookRoom());
            EditBookingCommand = new RelayCommand(_ => EditBooking(), _ => SelectedBooking != null);
            CancelBookingCommand = new RelayCommand(_ => CancelBooking(), _ => SelectedBooking != null);
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
            bookingWindow.ShowDialog();
        }

        private void EditBooking()
        {
            if (SelectedBooking == null) return;

            var bookingWindow = new BookingWindow(this, SelectedBooking);
            bookingWindow.Owner = Application.Current.MainWindow;
            bookingWindow.ShowDialog();
        }

        private void CancelBooking()
        {
            if (SelectedBooking == null) return;

            var result = MessageBox.Show(
                $"Cancel booking #{SelectedBooking.Id}?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _bookingService.DeleteBooking(SelectedBooking.Id);
                Bookings.Remove(SelectedBooking);
                SelectedBooking = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}