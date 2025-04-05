using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HotelBookingSystem.Commands;
using HotelBookingSystem.Services;

namespace HotelBookingSystem.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private readonly DataService _dataService;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _dataService = new DataService();
            LoginCommand = new RelayCommand<object>(Login);
            RegisterCommand = new RelayCommand<object>(Register);
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var user = _dataService.AuthenticateUser(Username, passwordBox.Password);
            if (user != null)
            {
                (Application.Current.MainWindow as Window).DialogResult = true;
                (Application.Current.MainWindow as Window).Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void Register(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            _dataService.RegisterUser(new UserModel { Username = Username, Password = passwordBox.Password });
            MessageBox.Show("Регистрация успешна! Теперь войдите.");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}