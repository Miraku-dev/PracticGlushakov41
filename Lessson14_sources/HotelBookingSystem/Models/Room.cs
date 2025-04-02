using HotelBookingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelBookingSystem.Models
{
    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Number { get; set; }
        public string Type { get; set; }
        public decimal PricePerNight { get; set; }

        public string NumberWithType => $"{Number} ({Type})";

        public string Status
        {
            get
            {
                var mainVM = Application.Current.MainWindow?.DataContext as MainViewModel;
                if (mainVM == null) return "Статус неизвестен";

                return IsAvailable(DateTime.Today, DateTime.Today.AddDays(1), mainVM.Bookings)
                    ? "Доступен"
                    : "Занят";
            }
        }

        public bool IsAvailable(DateTime checkIn, DateTime checkOut, IEnumerable<Booking> bookings)
        {
            bool available = !bookings.Any(b =>
                b.RoomNumber == Number &&
                !(checkOut <= b.CheckInDate || checkIn >= b.CheckOutDate));

            OnPropertyChanged(nameof(Status));
            return available;
        }
    }
}