using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HotelBookingSystem.Commands;
using HotelBookingSystem.View;

namespace HotelBookingSystem.Models;

public class LoginViewModel : INotifyPropertyChanged
{
    public string Username { get; set; }
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(ExecuteLoginCommand);
    }

    private void ExecuteLoginCommand()
    {
        throw new NotImplementedException();
    }

    private void ExecuteLoginCommand(object parameter)
    {
        var passwordBox = parameter as PasswordBox;
        if (AuthenticateUser(Username, passwordBox.Password)) // Your authentication logic
        {
            // Set DialogResult on the LoginWindow
            var loginWindow = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
            if (loginWindow != null)
            {
                loginWindow.DialogResult = true;
            }
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Replace with your authentication logic
        return username == "admin" && password == "password";
    }

    // INotifyPropertyChanged implementation omitted for brevity
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}