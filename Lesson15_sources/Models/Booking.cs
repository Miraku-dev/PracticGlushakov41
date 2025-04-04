using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelBookingSystem.Models
{
    public class Booking : INotifyPropertyChanged
    {
        private int _id;
        private string _guestName;
        private int _roomNumber;
        private DateTime _checkInDate;
        private DateTime _checkOutDate;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string GuestName
        {
            get => _guestName;
            set { _guestName = value; OnPropertyChanged(); }
        }

        public int RoomNumber
        {
            get => _roomNumber;
            set { _roomNumber = value; OnPropertyChanged(); }
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}