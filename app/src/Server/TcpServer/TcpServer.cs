using System.Net;
using System.Net.Sockets;

namespace BircheMmoServer;

public class TcpServer : IServer
{
  private readonly TcpServerConfig config;

  private TcpListener? listener;
  private List<User> connectedUsers = new();
  public TcpServer(TcpServerConfig config)
  {
    this.config = config;
  }

  public void Start()
  {
    listener = new TcpListener(config.IpAddress, config.Port);
    listener.Start();
    Console.WriteLine($"Tcp Listener now listening on port {config.Port}.");

    while (true)
    {
      TcpClient client = listener.AcceptTcpClient();
      Console.WriteLine("Client connected.");

      User user = new()
      {
        TcpClient = client,
        NetworkStream = client.GetStream()
      };

      connectedUsers.Add(user);
    }
  }
}