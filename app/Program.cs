using BircheMmoServer;
using Microsoft.Extensions.Configuration;

// Build Configuration from appsettings.{environment}.json
IConfigurationRoot configuration = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory() + "/settings")
  .AddJsonFile("appsettings." + Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT") + ".json")
  .Build();

// Bind Configuration to Config instances
TcpServerConfig tcpServerConfig = new();
configuration.GetSection("TcpServerConfig").Bind(tcpServerConfig);

TcpServer server = new(tcpServerConfig);
server.Start();