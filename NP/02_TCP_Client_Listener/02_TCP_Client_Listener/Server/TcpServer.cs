using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public enum Command
    {
        weather = 1,
        time,
        random
    }

    public class TcpServer
    {
        private Dictionary<Command, string> commands;

        public TcpServer()
        {
            commands = new Dictionary<Command, string>();
            commands.Add(Command.time, "time");
            commands.Add(Command.weather, "weather");
            commands.Add(Command.random, "random");
        }

        public async Task StartAsync(int port)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("26.251.103.65"), port);
            listener.Start();
            Console.WriteLine($"Server started on port {port}");

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                Task.Run(() => HandleClientAsync(client));
            }
        }

        public async Task HandleClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            try
            {
                var clientEP = client.Client.RemoteEndPoint;
                Console.WriteLine($"Client connected {clientEP}");

                byte[] buffer = new byte[1024];

                while (true)
                {
                    int len = await stream.ReadAsync(buffer);
                    string request = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.WriteLine($"Client {clientEP} send request - {request}");

                    var command = GetCommand(request);
                    string response = string.Empty;

                    switch (command)
                    {
                        case Command.weather:
                            response = "0°C";
                            break;
                        case Command.random:
                            response = new Random().Next(0, 200).ToString();
                            break;
                        case Command.time:
                            response = DateTime.Now.ToShortTimeString();

                            break;
                    }
                    byte[] bytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(bytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream.Dispose();
            }
        }

        Command GetCommand(string value)
        {
            foreach (var command in commands)
            {
                if (command.Value == value)
                {
                    return command.Key;
                }
            }
            return Command.time;
        }
    }
}
