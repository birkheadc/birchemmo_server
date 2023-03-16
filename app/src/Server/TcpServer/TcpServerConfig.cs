using System.Net;

namespace BircheMmoServer;

public record TcpServerConfig
{
  public IPAddress IpAddress { get; set; } = IPAddress.Any;
  public int Port { get; set; } = -1;
}