using HotelBookingSystem.Commands;
using HotelBookingSystem.Models;
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Booking> Bookings { get; } = new ObservableCollection<Booking>();
        public ObservableCollection<Room> Rooms { get; } = new ObservableCollection<Room>();

       private Booking _selectedBooking;
public Booking SelectedBooking
{
    get => _selectedBooking;
    set
    {
        _selectedBooking = value;
        OnPropertyChanged();
        CommandManager.InvalidateRequerySuggested();
    }
}
        public ICommand CancelBookingCommand { get; }

        public ICommand BookRoomCommand { get; }
        public ICommand EditBookingCommand { get; }
        public void UpdateRoomStatuses()
        {
            foreach (var room in Rooms)
            {
                room.OnPropertyChanged(nameof(Room.IsAvailable));
            }
        }

        public MainViewModel()
        {
            CancelBookingCommand = new RelayCommand(
                execute: CancelBooking,
                canExecute: _ => SelectedBooking != null
            );
            InitializeTestData();

            BookRoomCommand = new RelayCommand(_ => BookRoom());
            EditBookingCommand = new RelayCommand(_ => EditBooking(), _ => Bookings.Count > 0);
            CancelBookingCommand = new RelayCommand(param => CancelBooking(param), _ => Bookings.Count > 0);
            UpdateRoomStatuses();

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
            UpdateRoomStatuses();
        }

        private void BookRoom()
        {
            var bookingWindow = new BookingWindow(this);
            bookingWindow.Owner = Application.Current.MainWindow;
            bookingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bookingWindow.ShowDialog();
            UpdateRoomStatuses();

        }

        private void EditBooking()
        {
            MessageBox.Show("Окно редактирования брони", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
            UpdateRoomStatuses();
        }

        private void CancelBooking(object _)
        {
            if (SelectedBooking == null)
            {
                MessageBox.Show("Выберите бронь для отмены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Отменить бронь #{SelectedBooking.Id} для {SelectedBooking.GuestName}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Bookings.Remove(SelectedBooking);
                SelectedBooking = null; // Сброс выбора
                UpdateRoomStatuses(); // Обновляем статусы номеров
            }
        }
    }
}