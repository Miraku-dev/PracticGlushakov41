using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HotelBookingSystem.Commands;

namespace HotelBookingSystem.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private DateTime _checkInDate = DateTime.Today;
        private DateTime _checkOutDate = DateTime.Today.AddDays(1);
        private readonly RoomModel _room;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }
        public DateTime CheckInDate
        {
            get => _checkInDate;
            set { _checkInDate = value; OnPropertyChanged(); }
        }
        public DateTime CheckOutDate
        {
            get => _checkOutDate;
            set { _checkOutDate = value; OnPropertyChanged(); }
        }
        public int RoomNumber => _room.RoomNumber;

        public ICommand BookCommand { get; }

        public BookingViewModel(RoomModel room, string fullName)
        {
            _room = room;
            _fullName = fullName;
            BookCommand = new RelayCommand(BookRoom);
        }

        public BookingViewModel(RoomModel room)
        {
            throw new NotImplementedException();
        }

        private void BookRoom()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                MessageBox.Show("ФИО не может быть пустым.");
                return;
            }
            if (CheckInDate >= CheckOutDate)
            {
                MessageBox.Show("Дата заезда должна быть раньше даты выезда.");
                return;
            }
            MessageBox.Show("Бронирование успешно!");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}