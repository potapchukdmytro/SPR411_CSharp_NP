using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _01_TCP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse("10.10.26.100");
            int port = 5000;
            IPEndPoint ipEnd = new IPEndPoint(ip, port);

            server.Connect(ipEnd);

            //// Receive message 
            //byte[] buffer = new byte[1024];
            //// Hi client -> len = 9
            //while (true)
            //{
            //    int len = server.Receive(buffer); // int len - к-сть отриманих символів

            //    string serverMessage = Encoding.UTF8.GetString(buffer, 0, len);
            //    Console.WriteLine(serverMessage);
            //}

            while (true)
            {
                // Send message for client
                string message = Console.ReadLine();
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                server.Send(messageBytes);
            }
        }
    }
}
