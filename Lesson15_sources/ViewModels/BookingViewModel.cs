using HotelBookingSystem.Commands;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingSystem.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainVM;
        private readonly Booking _editingBooking;
        private readonly BookingService _bookingService;
        private Room _selectedRoom;
        private string _guestName;
        private DateTime _checkInDate = DateTime.Today;
        private DateTime _checkOutDate = DateTime.Today.AddDays(1);
        private bool _isLoading;

        public ObservableCollection<Room> AvailableRooms { get; } = new ObservableCollection<Room>();

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(BookingInfo));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string GuestName
        {
            get => _guestName;
            set
            {
                _guestName = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public DateTime CheckInDate
        {
            get => _checkInDate;
            set
            {
                if (value >= DateTime.Today)
                {
                    _checkInDate = value;
                    OnPropertyChanged();
                    UpdateAvailableRooms();
                    OnPropertyChanged(nameof(TotalPrice));
                    OnPropertyChanged(nameof(BookingInfo));
                }
            }
        }

        public DateTime CheckOutDate
        {
            get => _checkOutDate;
            set
            {
                if (value > CheckInDate)
                {
                    _checkOutDate = value;
                    OnPropertyChanged();
                    UpdateAvailableRooms();
                    OnPropertyChanged(nameof(TotalPrice));
                    OnPropertyChanged(nameof(BookingInfo));
                }
            }
        }

        public decimal TotalPrice =>
            SelectedRoom != null && CheckOutDate > CheckInDate
                ? SelectedRoom.PricePerNight * (decimal)(CheckOutDate - CheckInDate).TotalDays
                : 0;

        public string BookingInfo => SelectedRoom != null
            ? $"Room: {SelectedRoom.Number}\nType: {SelectedRoom.Type}\nPrice per night: {SelectedRoom.PricePerNight:C2}\nTotal: {TotalPrice:C2}"
            : "Select a room";

        public ICommand BookCommand { get; }
        public ICommand CancelCommand { get; }

        public BookingViewModel(MainViewModel mainVM, Booking editingBooking = null)
        {
            _mainVM = mainVM ?? throw new ArgumentNullException(nameof(mainVM));
            _editingBooking = editingBooking;
            _bookingService = new BookingService();

            if (editingBooking != null)
            {
                GuestName = editingBooking.GuestName;
                CheckInDate = editingBooking.CheckInDate;
                CheckOutDate = editingBooking.CheckOutDate;
                SelectedRoom = _mainVM.Rooms.FirstOrDefault(r => r.Number == editingBooking.RoomNumber);
            }

            UpdateAvailableRooms();

            BookCommand = new RelayCommand(
                execute: _ => BookRoom(),
                canExecute: _ => !IsLoading && SelectedRoom != null && !string.IsNullOrWhiteSpace(GuestName));

            CancelCommand = new RelayCommand(_ => CloseWindow());
        }

        private void UpdateAvailableRooms()
        {
            AvailableRooms.Clear();
            foreach (var room in _mainVM.Rooms.Where(r =>
                !_mainVM.Bookings.Any(b =>
                    b.RoomNumber == r.Number &&
                    !(CheckOutDate <= b.CheckInDate || CheckInDate >= b.CheckOutDate))))
            {
                AvailableRooms.Add(room);
            }
        }

        private async void BookRoom()
        {
            try
            {
                IsLoading = true;

                Debug.WriteLine($"Starting booking process: Room={SelectedRoom?.Number}, Guest={GuestName}");

                var booking = new Booking
                {
                    Id = _editingBooking?.Id ?? 0,
                    GuestName = GuestName.Trim(),
                    RoomNumber = SelectedRoom.Number,
                    CheckInDate = CheckInDate,
                    CheckOutDate = CheckOutDate
                };

                await _bookingService.BookRoomAsync(booking);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (_editingBooking != null)
                    {
                        _mainVM.Bookings.Remove(_editingBooking);
                    }
                    _mainVM.Bookings.Add(booking);

                    MessageBox.Show($"Room {SelectedRoom.Number} booked successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    CloseWindow();
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Booking failed: {ex}");
                MessageBox.Show($"Booking failed: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void CloseWindow()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Application.Current.Windows
                    .OfType<Window>()
                    .FirstOrDefault(w => w.DataContext == this)?
                    .Close();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}