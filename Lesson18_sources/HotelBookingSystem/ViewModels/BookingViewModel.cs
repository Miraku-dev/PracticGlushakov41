using CommunityToolkit.Mvvm.Input;

namespace HotelBookingSystem.ViewModels;

using System.Collections.ObjectModel;
using System.Windows.Input;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;

public class BookingViewModel : BaseViewModel
{
    private readonly IRepository<Booking> _bookingRepo;
    private readonly IRepository<Room> _roomRepo;

    public ObservableCollection<Booking> Bookings => _bookings;

    public ObservableCollection<Room> AvailableRooms { get; } = new();

    public ICommand LoadBookingsCommand { get; }
    public ICommand LoadAvailableRoomsCommand { get; }
    public ICommand BookRoomCommand { get; }
    public ICommand CancelBookingCommand { get; }

    public BookingViewModel(IRepository<Booking> bookingRepo, IRepository<Room> roomRepo, Booking selectedBooking, Room selectedRoom, string guestName)
    {
        _bookingRepo = bookingRepo;
        _roomRepo = roomRepo;
        _selectedBooking = selectedBooking;
        _selectedRoom = selectedRoom;
        _guestName = guestName;

        LoadBookingsCommand = new AsyncRelayCommand(LoadBookings);
        LoadAvailableRoomsCommand = new AsyncRelayCommand(LoadAvailableRooms);
        BookRoomCommand = new AsyncRelayCommand(BookRoom);
        CancelBookingCommand = new AsyncRelayCommand(CancelBooking);
    }

    private async Task LoadBookings()
    {
        var bookings = await _bookingRepo.GetAllAsync();
        Bookings.Clear();
        foreach (var booking in bookings) Bookings.Add(booking);
    }

    private async Task LoadAvailableRooms()
    {
        var rooms = await _roomRepo.GetAllAsync();
        AvailableRooms.Clear();
        foreach (var room in rooms.Where(r => r.IsAvailable)) AvailableRooms.Add(room);
    }

    private async Task BookRoom()
    {
        if (SelectedRoom != null && !string.IsNullOrEmpty(GuestName))
        {
            var booking = new Booking
            {
                RoomId = SelectedRoom.Id,
                GuestName = GuestName,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate
            };

            await _bookingRepo.AddAsync(booking);

            SelectedRoom.IsAvailable = false;
            await _roomRepo.UpdateAsync(SelectedRoom);

            await _bookingRepo.SaveAsync();
            await LoadBookings();
            await LoadAvailableRooms();
        }
    }

    private async Task CancelBooking()
    {
        if (SelectedBooking != null)
        {
            SelectedBooking.Room.IsAvailable = true;
            await _roomRepo.UpdateAsync(SelectedBooking.Room);
            await _bookingRepo.DeleteAsync(SelectedBooking);
            await _bookingRepo.SaveAsync();
            await LoadBookings();
            await LoadAvailableRooms();
        }
    }

    private Booking _selectedBooking;

    public Booking SelectedBooking
    {
        get => _selectedBooking;
        set
        {
            _selectedBooking = value;
            OnPropertyChanged();
        }
    }

    private Room _selectedRoom;

    public Room SelectedRoom
    {
        get => _selectedRoom;
        set
        {
            _selectedRoom = value;
            OnPropertyChanged();
        }
    }

    private string _guestName;

    public string GuestName
    {
        get => _guestName;
        set
        {
            _guestName = value;
            OnPropertyChanged();
        }
    }

    private DateTime _checkInDate = DateTime.Now;

    public DateTime CheckInDate
    {
        get => _checkInDate;
        set
        {
            _checkInDate = value;
            OnPropertyChanged();
        }
    }

    private DateTime _checkOutDate = DateTime.Now.AddDays(1);
    private readonly ObservableCollection<Booking> _bookings = new();

    public BookingViewModel(BookingRepository bookingRepository, RoomRepository bookingRepo)
    {
        throw new NotImplementedException();
    }

    public DateTime CheckOutDate
    {
        get => _checkOutDate;
        set
        {
            _checkOutDate = value;
            OnPropertyChanged();
        }
    }
}