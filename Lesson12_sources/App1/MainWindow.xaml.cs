using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HotelBooking
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            RoomsGrid.ItemsSource = new List<Room>
            {
                new Room(101, "Стандарт", 2500, true),
                new Room(201, "Люкс", 5000, true),
                new Room(301, "Президентский", 15000, false)
            };
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameInput.Text))
            {
                ErrorText.Text = "Введите ФИО";
                return;
            }

            if (CheckInDate.SelectedDate == null || CheckOutDate.SelectedDate == null)
            {
                ErrorText.Text = "Выберите даты заезда и выезда";
                return;
            }

            if (CheckOutDate.SelectedDate <= CheckInDate.SelectedDate)
            {
                ErrorText.Text = "Дата выезда должна быть позже даты заезда";
                return;
            }

            MessageBox.Show($"Бронирование подтверждено для {NameInput.Text}\n" +
                          $"Даты: {CheckInDate.SelectedDate:dd.MM.yyyy} - {CheckOutDate.SelectedDate:dd.MM.yyyy}");
        }

        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Room
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int number, string type, decimal price, bool isAvailable)
        {
            Number = number;
            Type = type;
            Price = price;
            IsAvailable = isAvailable;
        }
    }
}