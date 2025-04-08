using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;

namespace HotelBookingSystem.ViewModels;

public class RoomViewModel : BaseViewModel
{
    private readonly IRepository<Room> _repo;

    public ObservableCollection<Room> Rooms { get; } = new();

    public ICommand LoadCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }

    public RoomViewModel(IRepository<Room> repo)
    {
        _repo = repo;
        
        LoadCommand = new AsyncRelayCommand(LoadRooms);
        AddCommand = new AsyncRelayCommand(AddRoom);
        UpdateCommand = new AsyncRelayCommand(UpdateRoom);
        DeleteCommand = new AsyncRelayCommand(DeleteRoom);
    }

    private async Task LoadRooms()
    {
        var rooms = await _repo.GetAllAsync();
        Rooms.Clear();
        foreach (var room in rooms) Rooms.Add(room);
    }

    private async Task AddRoom()
    {
        var room = new Room { Number = "New", Type = "Standard", PricePerNight = 100 };
        await _repo.AddAsync(room);
        await _repo.SaveAsync();
        await LoadRooms();
    }

    private async Task UpdateRoom()
    {
        await _repo.UpdateAsync(SelectedRoom);
        await _repo.SaveAsync();
        await LoadRooms();
    }

    private async Task DeleteRoom()
    {
        await _repo.DeleteAsync(SelectedRoom);
        await _repo.SaveAsync();
        await LoadRooms();
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
    
}