

using System.Net.Sockets;

const string? localHost = "127.0.0.1"; 

using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{



}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally 
{
    socket.Shutdown(SocketShutdown.Both);
    socket.Close();
}