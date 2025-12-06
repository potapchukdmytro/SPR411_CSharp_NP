using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _01_TCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // localhost = 127.0.0.1
            IPAddress ip = IPAddress.Parse("10.10.26.100");
            int port = 5000;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);

            server.Bind(ipEnd);
            server.Listen(5); // 5 - к-сть клієнтів у черзі

            Console.WriteLine("Waiting clients");
            Socket client = server.Accept();
            Console.WriteLine($"Client {client.RemoteEndPoint} connected");


            //while (true)
            //{
            //    // Send message for client
            //    string message = Console.ReadLine();
            //    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            //    client.Send(messageBytes);
            //}


            // Receive message 
            byte[] buffer = new byte[1024];
            // Hi client -> len = 9
            while (true)
            {
                int len = client.Receive(buffer); // int len - к-сть отриманих символів

                string serverMessage = Encoding.UTF8.GetString(buffer, 0, len);
                Console.WriteLine(serverMessage);
            }
        }
    }
}
