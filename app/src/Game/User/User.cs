using System.Net.Sockets;

namespace BircheMmoServer;

public class User
{
  public TcpClient? TcpClient { get; set; }
  public NetworkStream? NetworkStream { get; set; }
}