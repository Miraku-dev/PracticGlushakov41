using System.Configuration;
using System.Data;
using System.Windows;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repositories;
using HotelBookingSystem.ViewModels;
using HotelBookingSystem.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace HotelBookingSystem
{
    // App.xaml.cs
    public partial class App : Application
    {
        public App()
        {
            // Без DI-контейнера
        }
    
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
    
            // Применение миграций
            await ApplyMigrationsAsync();
    
            // Показ главного окна
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private async Task ApplyMigrationsAsync()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}