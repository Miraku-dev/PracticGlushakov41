using HotelBookingSystem.Commands;
using HotelBookingSystem.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HotelBookingSystem.ViewModels
{
    public class BookingViewModel
    {
        private readonly MainViewModel _mainVM;

        public ObservableCollection<Room> AvailableRooms { get; }
        public Room SelectedRoom { get; set; }
        public string GuestName { get; set; }

        private DateTime _checkInDate = DateTime.Today;
        public DateTime CheckInDate
        {
            get => _checkInDate;
            set
            {
                _checkInDate = value;
                UpdateAvailableRooms();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private DateTime _checkOutDate = DateTime.Today.AddDays(1);
        public DateTime CheckOutDate
        {
            get => _checkOutDate;
            set
            {
                _checkOutDate = value;
                UpdateAvailableRooms();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice =>
            SelectedRoom != null && CheckOutDate > CheckInDate
                ? SelectedRoom.PricePerNight * (decimal)(CheckOutDate - CheckInDate).TotalDays
                : 0;

        public string RoomInfo => SelectedRoom != null
            ? $"Тип: {SelectedRoom.Type}\nЦена за ночь: {SelectedRoom.PricePerNight:C2}\nИтого: {TotalPrice:C2}"
            : "Выберите номер";

        public ICommand BookCommand { get; }
        public ICommand CancelCommand { get; }

        public BookingViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            AvailableRooms = new ObservableCollection<Room>();
            UpdateAvailableRooms();

            BookCommand = new RelayCommand(_ => BookRoom());
            CancelCommand = new RelayCommand(_ => CloseWindow());
        }
        public string BookingInfo
        {
            get
            {
                if (SelectedRoom == null)
                    return "Выберите номер для просмотра информации";

                return $"Номер: {SelectedRoom.Number}\n" +
                       $"Тип: {SelectedRoom.Type}\n" +
                       $"Цена за ночь: {SelectedRoom.PricePerNight:C2}\n" +
                       $"Количество ночей: {(CheckOutDate - CheckInDate).Days}\n" +
                       $"Общая стоимость: {TotalPrice:C2}";
            }
        }

        private void UpdateAvailableRooms()
        {
            AvailableRooms.Clear();
            foreach (var room in _mainVM.Rooms.Where(r =>
                r.IsAvailable(CheckInDate, CheckOutDate, _mainVM.Bookings)))
            {
                AvailableRooms.Add(room);
            }
        }

        private void BookRoom()
        {
            if (SelectedRoom == null)
            {
                MessageBox.Show("Выберите номер", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(GuestName))
            {
                MessageBox.Show("Введите имя гостя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CheckOutDate <= CheckInDate)
            {
                MessageBox.Show("Дата выезда должна быть позже даты заезда", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var booking = new Booking
            {
                Id = _mainVM.Bookings.Count + 1,
                GuestName = GuestName.Trim(),
                RoomNumber = SelectedRoom.Number,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate
            };

            _mainVM.Bookings.Add(booking);
            _mainVM.UpdateRoomStatuses();
            MessageBox.Show($"Номер {SelectedRoom.Number} успешно забронирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }

        public event EventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}