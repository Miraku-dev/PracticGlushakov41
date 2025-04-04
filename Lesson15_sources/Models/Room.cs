using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelBookingSystem.Models
{
    public class Room : INotifyPropertyChanged
    {
        private int _number;
        private string _type;
        private decimal _pricePerNight;

        public int Number
        {
            get => _number;
            set { _number = value; OnPropertyChanged(); }
        }

        public string Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(); }
        }

        public decimal PricePerNight
        {
            get => _pricePerNight;
            set { _pricePerNight = value; OnPropertyChanged(); }
        }

        public string NumberWithType => $"{Number} ({Type})";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}