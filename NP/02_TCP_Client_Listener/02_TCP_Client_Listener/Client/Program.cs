using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    public enum Command
    {
        weather = 1,
        time,
        random
    }

    internal class Program
    {
        static Dictionary<Command, string> commands = new Dictionary<Command, string>();

        static async Task Main(string[] args)
        {
            commands.Add(Command.time, "time");
            commands.Add(Command.weather, "weather");
            commands.Add(Command.random, "random");

            try
            {
                TcpClient client = new TcpClient();
                await client.ConnectAsync(IPAddress.Parse("26.251.103.65"), 5000);

                var stream = client.GetStream();

                while(true)
                {
                    Console.WriteLine("1. Weather");
                    Console.WriteLine("2. Time");
                    Console.WriteLine("3. Random");
                    Console.WriteLine("0. Exit");
                    int input = 0;
                    bool res = false;
                    do
                    {
                        res = int.TryParse(Console.ReadLine(), out input);
                        if(input == 0)
                        {
                            break;
                        }
                    } while (input < 0 || input > 3 || !res);
                    Command command = (Command)input;

                    byte[] bytes = Encoding.UTF8.GetBytes(commands[command]);
                    await stream.WriteAsync(bytes);

                    byte[] buffer = new byte[1024];
                    int len = await stream.ReadAsync(buffer);

                    string response = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.WriteLine("Server response: " + response);
                }

                stream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
