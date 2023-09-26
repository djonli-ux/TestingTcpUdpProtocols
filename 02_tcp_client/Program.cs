using System.Net;
using System.Net.Sockets;
using System.Text;

const string serverIp = "127.0.0.1";  
const int port = 8080;


try
{
    using TcpClient tcpClient = new TcpClient();
    tcpClient.Connect(serverIp, port);

    using NetworkStream ns = tcpClient.GetStream();
    using StreamReader reader = new StreamReader(ns);
    using StreamWriter writer = new StreamWriter(ns);

    writer.WriteLine("Hello from client");
    writer.Flush();

    string? response = reader.ReadLine();
    Console.WriteLine($">>> {response}");

    tcpClient.Close();
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}

Console.ReadLine();

