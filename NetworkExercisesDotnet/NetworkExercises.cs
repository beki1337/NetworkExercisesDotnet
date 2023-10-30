using NetworkExercisesDotnet;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkExercisesNS
{
    /// <summary>
    /// This class contains exercises for C# .NET TCP socket programming.
    /// </summary>
    public class NetworkExercises
    {

        /// <summary>
        /// Establishes a connection to a target server using the provided ITcpClient interface.
        /// </summary>
        /// <remarks>
        /// To complete this exercise, you need to  use the provide ITcpClient 
        /// object that is initialized. Use one of the provided Connect methods
        /// from the ITcpClient object to connect to the target server. You 
        /// shall use the IP address 127.0.0.1 and the port 6667.
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient?view=net-7.0#methods
        /// </remarks>
        /// <param name="tcpClient">The TcpClient instance to use for the connection.</param>
        public static void EstablishConnectionWithTcpClient(ITcpClient tcpClient)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Catch SocketException thrown by the Connect method.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will use the provided initialized ITcpClient
        /// object to connect to a target server. You can choose the IP address and port.
        /// When the target computer refuses the connection, a SocketException is thrown.
        /// Use a Try/Catch block to catch and handle only the SocketException. The
        /// method shall return true if no Exception is thrown and false if a SocketException
        /// is thrown.
        /// </remarks>
        /// <param name="tcpClient">The TcpClient instance to use for the connection.</param>
        public static bool EstablishConnectionWithTcpClientException(ITcpClient tcpClient)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Listen for incoming TCP connections.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will use the Start method of the ITcpListener 
        /// object. The TcpListener object has already been initialized with 
        /// an IP address and port. Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-7.0#examples
        /// </remarks>
        /// <param name="listener"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void StartListing(ITcpListener listener)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Accepet incoming TcpConnection and returns the ITcpClient
        /// </summary>
        /// <remarks>
        /// In this exercise, the ITcpListener object will have started to listen
        /// for connections. Your assignment is to accept the connection and return
        /// the ITcpClient that is returned by the AcceptTcpClient method.
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-7.0#examples
        /// </remarks>
        /// <param name="listener"></param>
        /// <returns>The ITcpClient that is retrived from the AcceptTcpClient method</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ITcpClient AcceptClinets(ITcpListener listener)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Close the TcpListern
        /// </summary>
        /// <remarks>
        /// In this exercise, the ITcpListener object will have started
        /// listening for connections. Your assignment is to close the
        /// listener using the Stop method. 
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener?view=net-7.0#examples
        /// </remarks>
        /// <param name="listener"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void CloseTcpListern(ITcpListener listener)
        {
            throw new NotImplementedException   ();
        }


        /// <summary>
        /// Get the NetworkStrem from the ITcpClient object.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will use the provided, initialized ITcpClient
        /// to call the GetStream method to retrieve an INetworkStream object. 
        /// After the the INetworkStream object shall be returnd.
        /// The ITcpClient object has already established a connection.
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient.getstream?view=net-7.0#system-net-sockets-tcpclient-getstream
        /// </remarks>
        /// <param name="tcpClient">The TcpClient instance to use for the connection.</param>
        public static INetworkStream GetNetworkStream(ITcpClient tcpClient)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Reads data from the provided INetworkStream and returns it as a string.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will utilize the Read method of the INetworkStream
        /// to retrieve data from the stream and return it as a string. The message 
        /// is encode with Encoding.UTF8 method.
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream.read?view=net-7.0#system-net-sockets-networkstream-read(system-byte()-system-int32-system-int32)
        /// </remarks>
        /// <param name="stream">The INetworkStream to read data from.</param>
        /// <returns>The data read from the stream as a string.</returns>
        public static string ReadfromStrem(INetworkStream stream)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Writes data to the provided INetworkStream.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will use the Write method of the INetworkStream
        /// to send data to the stream. Use the Encoding.UTF8 method to encode
        /// the message
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream.write?view=net-7.0#system-net-sockets-networkstream-write(system-byte()-system-int32-system-int32)
        /// </remarks>
        /// <param name="stream">The INetworkStream to which data will be written.</param>
        public static void WriteToStream(INetworkStream stream)
        {
            throw new NotImplementedException();

        }


        /// <summary>
        ///  Read from the network stream that is closed
        /// </summary>
        /// <remarks>
        /// Sometimes when you want to read from a stream, but the other computer
        /// may have closed the connection. This will lead to the Read method throwing
        /// a SocketException. Your assignment is to try to read from the stream 
        /// and return True if able. If you get a SocketException, the method
        /// shall return false. All other exceptions shall not be caught.
        /// Here is a helpful link:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream?view=net-7.0#methods
        /// </remarks>
        /// <param name="networkStream"></param>
        /// <returns>If able to read returns true</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool ReadFromClosedConnection(INetworkStream networkStream)
        {
            throw new NotImplementedException();
        }


        /* Know when you have completed the exercise, you will have a basic
         * understanding of C# .NET Network Programming and should be able
         * to create a simple console application that asks a user if they 
         * want to start listening or connect to a specific IP address and 
         * port. Then, start the connection and begin sending and receiving
         * messages. Here are the general steps for the program:
         *      1. Ask the user for the IP address and port.
         *      2. Ask if the user wants to listen or connect.
         *      3. Establish a TCP connection.
         *      4. Send and receive messages.
         *  Some tips: You will need to have two console apps running. You can
         *  find more information at this link: 
         *  https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/sockets/tcp-classes
         */
        public static void Main(string[] args)
        {

            Console.WriteLine("You need to run the tests to assert the exercises." +
                "In the task you have File | Edit | View | Git | Project | Build | Debug | Test | ..." +
                "Press Test and the Run All Tests");
        }
    }
}