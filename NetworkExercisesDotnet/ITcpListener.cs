using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkExercisesDotnet
{
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
