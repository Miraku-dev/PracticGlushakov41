using System.Windows;
using HotelBookingSystem.ViewModels;
using LoginViewModel = HotelBookingSystem.Models.LoginViewModel;

namespace HotelBookingSystem.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}