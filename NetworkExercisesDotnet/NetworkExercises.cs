using NetworkExercisesDotnet;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkExercisesNS
{

    public class NetworkExercises
    {

        /// <summary>
        /// Establishes a connection to a target server using the provided ITcpClient interface.
        /// </summary>
        /// <remarks>
        /// To complete this exercise, you need to  use the provide <see cref="ITcpClient"> ITcpClient <see cref="ITcpClient"/> 
        /// object that is initialized. Use one of the provided Connect methods
        /// from the object to connect to the target server. You can choose
        /// the IP address and port to connect to.
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
        /// Use a Try/Catch block to catch and handle only this specific type of Exception.
        /// </remarks>
        /// <param name="tcpClient">The TcpClient instance to use for the connection.</param>
        public static void EstablishConnectionWithTcpClientException(ITcpClient tcpClient)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Get the NetworkStrem from the ITcpClien object.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will use the provided, initialized ITcpClient
        /// to call the GetStream method to retrieve an INetworkStream object.
        /// The ITcpClient object has already established a connection.
        /// </remarks>
        /// <param name="tcpClient">The TcpClient instance to use for the connection.</param>
        public static void GetNetworkStream(ITcpClient tcpClient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads data from the provided INetworkStream and returns it as a string.
        /// </summary>
        /// <remarks>
        /// In this exercise, you will utilize the Read method of the INetworkStream
        /// to retrieve data from the stream and return it as a string.
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
        /// In this method, you will use the Write method of the INetworkStream
        /// to send data to the stream.
        /// </remarks>
        /// <param name="stream">The INetworkStream to which data will be written.</param>
        public static void WriteToStream(INetworkStream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// String lsiten on incomming TcpConnections
        /// </summary>
        /// <remarks>
        /// In this exercise, you will utilize the Start method from the 
        /// ITcpListener object. 
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
        /// on connection. You assigemet is to accpet the connection and return
        /// the ITcpClient that is return by´the AcceptTcpClient method.
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
        /// In this exercise, the ITcpListener object will have started to
        /// listen on connection. Your assigement is to close the listern with
        /// the Stop method.
        /// </remarks>
        /// <param name="listener"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void CloseTcpListern(ITcpListener listener)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///  Read from the network stream that is closed
        /// </summary>
        /// <remarks>
        /// Someimes when you want to read from a stream the other computer
        /// may have closed the connection. This will lead to Read method throws
        /// a SocketException. Your assigement is try to read from the stream 
        /// and return True if able. If you get an a SocketException the funcktion
        /// shall return false. All other exxption shall not be catched.
        /// </remarks>
        /// <param name="networkStream"></param>
        /// <returns>If able to read returns true</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool ReadFromClosedConnection(INetworkStream networkStream)
        {
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("You need to run the tests to assert the exercises");
        }
    }
}