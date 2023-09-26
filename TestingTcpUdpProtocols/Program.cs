using System.Net;
using System.Net.Sockets;

const string serverIp = "127.0.0.1";   
const int port = 8080;

TcpListener? listener = null;

try
{
    listener = new TcpListener(IPAddress.Parse(serverIp), port);
    listener.Start();

    Console.WriteLine($"Server started at {serverIp}:{port}");

    TcpClient tcpClient = listener.AcceptTcpClient();           
    Console.WriteLine("Connection established!");

    using NetworkStream ns = tcpClient.GetStream();
    using StreamReader reader = new StreamReader(ns);
    using StreamWriter writer = new StreamWriter(ns);

    string? message = reader.ReadLine();
    Console.WriteLine($">>> {message}");

    string response = "Hello from server!";
    writer.WriteLine(response);
    writer.Flush();
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}
finally
{
    listener?.Stop();
}