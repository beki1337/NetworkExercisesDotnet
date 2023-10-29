using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkExercisesDotnet
{
    /// <summary>
    /// Defines methods for reading and writing data to a network stream, 
    /// serving as a wrapper for the C# .NET NetworkStream class.
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream?view=net-7.0#methods">C# .NET NetworkStream class</see>
    /// </summary>
    public interface INetworkStream
    {
        /// <summary>
        /// Reads data from the network stream into the provided byte array.
        /// </summary>
        /// <param name="buffer">The byte array into which data will be read.</param>
        /// <param name="offset">The zero-based byte offset in the buffer at which to begin storing the data.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// Writes data from the provided byte array to the network stream.
        /// </summary>
        /// <param name="buffer">The byte array containing the data to be written to the stream.</param>
        /// <param name="offset">The zero-based byte offset in the buffer from which to start writing data.</param>
        /// <param name="count">The number of bytes to write to the stream.</param>
        void Write(byte[] buffer, int offset, int count);
    }
}
