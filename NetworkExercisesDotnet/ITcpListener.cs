using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkExercisesDotnet
{
    /// <summary>
    /// Defines methods for connecting to a remote server and obtaining a 
    /// network stream for data transfer, serving as a wrapper for the 
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-7.0#examples">
    /// C# .NET TcpListener class</see>.
    /// </summary>
    public interface ITcpListener
    {
        /// <summary>
        /// Starts listening for incoming connection requests.
        /// </summary>
        void Start();

        /// <summary>
        /// Accepts an incoming TCP client connection.
        /// </summary>
        /// <returns>An ITcpClient instance representing the accepted client connection.</returns>
        ITcpClient AcceptTcpClient();

        /// <summary>
        /// Stops listening for incoming connection requests.
        /// </summary>
        void Stop();
    }
}
