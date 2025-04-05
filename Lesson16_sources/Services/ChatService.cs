using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.Services
{
    public class ChatService
    {
        public void StartListening(HotelViewModel viewModel)
        {
            Task.Run(async () =>
            {
                using (var server = new NamedPipeServerStream("HotelChatPipe", PipeDirection.InOut))
                {
                    await server.WaitForConnectionAsync();
                    using (var reader = new StreamReader(server, Encoding.UTF8))
                    {
                        while (true)
                        {
                            var message = await reader.ReadLineAsync();
                            if (message != null)
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                    viewModel.ChatMessage = $"Админ: {message}");
                            }
                        }
                    }
                }
            });
        }

        public void SendMessage(string message)
        {
            Task.Run(async () =>
            {
                using (var client = new NamedPipeClientStream(".", "HotelChatPipe", PipeDirection.InOut))
                {
                    await client.ConnectAsync();
                    using (var writer = new StreamWriter(client, Encoding.UTF8) { AutoFlush = true })
                    {
                        await writer.WriteLineAsync(message);
                    }
                }
            });
        }
    }
}