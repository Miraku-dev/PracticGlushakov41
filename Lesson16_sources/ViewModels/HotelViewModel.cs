using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelBookingSystem.Commands; // Предполагается, что RelayCommand здесь
using HotelBookingSystem.Services;
using HotelBookingSystem.View;

namespace HotelBookingSystem.ViewModels
{
    public class HotelViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<RoomModel> _rooms;
        private RoomModel _selectedRoom;
        private bool _isLoading;
        private string _chatMessage;
        private string _newMessage;
        private readonly BookingService _bookingService;
        private readonly DataService _dataService;
        private readonly ChatService _chatService;

        public ObservableCollection<RoomModel> Rooms
        {
            get => _rooms;
            set { _rooms = value; OnPropertyChanged(); }
        }

        public RoomModel SelectedRoom
        {
            get => _selectedRoom;
            set { _selectedRoom = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public string ChatMessage
        {
            get => _chatMessage;
            set { _chatMessage = value; OnPropertyChanged(); }
        }

        public string NewMessage
        {
            get => _newMessage;
            set { _newMessage = value; OnPropertyChanged(); }
        }

        public ICommand BookRoomCommand { get; }
        public ICommand EditBookingCommand { get; }
        public ICommand CancelBookingCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ViewRoomsCommand { get; }
        public ICommand SendMessageCommand { get; }

        public HotelViewModel()
        {
            _dataService = new DataService();
            _bookingService = new BookingService(_dataService);
            _chatService = new ChatService();
            Rooms = new ObservableCollection<RoomModel>(_dataService.LoadRooms());
            BookRoomCommand = new RelayCommand(async () => await BookRoom());
            EditBookingCommand = new RelayCommand(EditBooking, () => SelectedRoom != null);
            CancelBookingCommand = new RelayCommand(CancelBooking, () => SelectedRoom != null);
            SaveCommand = new RelayCommand(SaveData);
            ExitCommand = new RelayCommand(ExitApp);
            ViewRoomsCommand = new RelayCommand(ViewRooms);
            SendMessageCommand = new RelayCommand(SendMessage);
            _chatService.StartListening(this);
        }

        private async Task BookRoom()
        {
            if (SelectedRoom == null) return;
            var bookingWindow = new BookingWindow(SelectedRoom);
            if (bookingWindow.ShowDialog() == true)
            {
                IsLoading = true;
                await _bookingService.BookRoom((BookingViewModel)bookingWindow.DataContext);
                Rooms[Rooms.IndexOf(SelectedRoom)].Status = "Забронирован";
                IsLoading = false;
            }
        }

        private void EditBooking()
        {
            MessageBox.Show("Редактирование брони пока не реализовано.");
        }

        private void CancelBooking()
        {
            if (MessageBox.Show("Вы уверены, что хотите отменить бронь?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SelectedRoom.Status = "Свободен";
            }
        }

        private void SaveData()
        {
            _dataService.SaveRooms(Rooms);
            MessageBox.Show("Данные сохранены.");
        }

        private void ExitApp()
        {
            Application.Current.Shutdown();
        }

        private void ViewRooms()
        {
            Rooms = new ObservableCollection<RoomModel>(_dataService.LoadRooms());
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(NewMessage))
            {
                _chatService.SendMessage(NewMessage);
                ChatMessage = $"Вы: {NewMessage}";
                NewMessage = string.Empty;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}