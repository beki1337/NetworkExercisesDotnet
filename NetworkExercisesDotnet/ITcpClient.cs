using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetworkExercisesDotnet
{
    /// <summary>
    /// Defines methods for connecting to a remote server and obtaining a 
    /// network stream for data transfer, serving as a wrapper for the 
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient?view=net-7.0">
    /// C# .NET TcpClient class</see>.
    /// </summary>
    public interface ITcpClient
    {

        /// <summary>
        /// Connects to a remote server at the specified IP address and port.
        /// </summary>
        /// <param name="iPAddress">The IP address of the remote server.</param>
        /// <param name="port">The port on which to establish the connection.</param>
        void Connect(IPAddress iPAddress, int port);

        /// <summary>
        /// Connects to a remote server using an array of IP addresses and a port.
        /// </summary>
        /// <param name="iPAddress">An array of IP addresses to attempt connections.</param>
        /// <param name="port">The port on which to establish the connection.</param>
        void Connect(IPAddress[] iPAddress, int port);

        /// <summary>
        /// Connects to a remote server using an IPEndPoint instance.
        /// </summary>
        /// <param name="iPEndPoint">An IPEndPoint that specifies the remote server's address and port.</param>
        void Connect(IPEndPoint iPEndPoint);

        /// <summary>
        /// Connects to a remote server at the specified IP address and port.
        /// </summary>
        /// <param name="iPAddress">The IP address of the remote server as a string.</param>
        /// <param name="port">The port on which to establish the connection.</param>
        void Connect(string iPAddress, int port);

        /// <summary>
        /// Returns an INetworkStream for reading and writing data over the TCP connection.
        /// </summary>
        /// <returns>An INetworkStream instance for data transfer.</returns>
        INetworkStream GetStream();
    }
}
