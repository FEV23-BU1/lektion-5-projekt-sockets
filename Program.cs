namespace Sockets;

using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        StartClient();
    }

    public static void StartServer()
    {
        // ...
    }

    public static void StartClient()
    {
        IPHostEntry ipHostEntry = Dns.GetHostEntry("jsonplaceholder.typicode.com");
        IPAddress ipAddress = ipHostEntry.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 80);

        Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        socket.Connect(ipEndPoint);

        string request =
            "GET /todos HTTP/1.1\nConnection: close\nHost: jsonplaceholder.typicode.com\n\n";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(request);
        socket.Send(buffer);

        byte[] incoming = new byte[10000];
        int read = socket.Receive(incoming);
        string response = System.Text.Encoding.UTF8.GetString(incoming, 0, read);
        Console.WriteLine($"Response: {response}");

        socket.Close();
    }
}
