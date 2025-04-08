// Views/RoomsView.xaml.cs

using System.Net.Mime;
using System.Windows.Controls;
using HotelBookingSystem.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using HotelBookingSystem.ViewModels;
using HotelBookingSystem.Data;
using HotelBookingSystem.Repositories;

namespace HotelBookingSystem.Views
{
    // RoomsView.xaml.cs
    // RoomsView.xaml.cs
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();
            var dbContext = new HotelDbContext();
            DataContext = new RoomViewModel(new RoomRepository(dbContext));
        }
    }
}