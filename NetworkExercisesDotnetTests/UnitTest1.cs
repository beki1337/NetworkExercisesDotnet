using NetworkExercisesDotnet;
using NetworkExercisesNS;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Moq;

namespace NetworkExercisesDotnetTests
{
    [TestClass]
    public class NetworkExercisesTests
    {

        /// <summary>
        /// Verifies that the 'EstablishConnectionWithTcpClient' method correctly triggers the 'Connect' method
        /// on an ITcpClient object, ensuring that it is called only once to enforce proper behavior.
        /// </summary>
        [TestMethod]
        public void EstablishConnectionWithTcpClient()
        {
            // Arrange
            var tcpClientMock = new Mock<ITcpClient>();
            tcpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress>(), It.IsAny<int>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPEndPoint>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress[]>(), It.IsAny<int>()));

            // Act
            NetworkExercises.EstablishConnectionWithTcpClient(tcpClientMock.Object);

            // Assert
            bool methodWasCalled = tcpClientMock.Invocations.Any(invocation => invocation.Method.Name == "Connect");
            int numberCalled = tcpClientMock.Invocations.Count(invocation => invocation.Method.Name == "Connect");
            Assert.IsTrue(methodWasCalled, "The Connect method was not called from the TcpClient object");
            Assert.AreEqual(1, numberCalled, $"The Connect method should only be called once to enforce proper behavior now it was called {numberCalled} times");

        }



        [TestMethod]
        public void CheckCorrecket_Connection()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();
            string? capturedStringIpAddressArg = null;
            int capturedIntPortArg = 0;
            IPAddress? capturedIpAddressArg = null;
            IPEndPoint? capturedIPEndPointArg = null;
            IPAddress[]? capturedIpAddressArrayArg = null;
            int capturedIntArrayArg = 0;

            tcpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>()))
                .Callback((string str, int num) =>
                {
                    capturedStringIpAddressArg = str;
                    capturedIntPortArg = num;
                });

            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress>(), It.IsAny<int>()))
                .Callback((IPAddress ipAddress, int port) =>
                {
                    capturedIpAddressArg = ipAddress;
                    capturedIntPortArg = port;
                });

            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPEndPoint>()))
                .Callback((IPEndPoint endPoint) =>
                {
                    capturedIPEndPointArg = endPoint;
                });


            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress[]>(), It.IsAny<int>()))
                .Callback((IPAddress[] ipAddressArray, int num) =>
                {
                    capturedIpAddressArrayArg = ipAddressArray;
                    capturedIntArrayArg = num;
                });



            //Act
            NetworkExercises.EstablishConnectionWithTcpClient(tcpClientMock.Object);
            //Assert
            if(capturedStringIpAddressArg != null)
            {
                Assert.AreEqual(capturedStringIpAddressArg, "127.0.0.1",
                    $"The TCP client should connect to IP address 127.0.0.1, but it's connecting to {capturedStringIpAddressArg}");
                Assert.AreEqual(capturedIntPortArg, 6667, 
                    $"The TCP client should connect to port 6667, but it's trying to connect to {capturedIntPortArg}");
               
            }
            else if (capturedIpAddressArg != null) {
               bool same = Equals(capturedIpAddressArg, IPAddress.Parse("127.0.0.1"));
               Assert.IsTrue(same,
                   $"The TCP client should connect to IP address 127.0.0.1, but it's connecting to {capturedIpAddressArg}");
               Assert.AreEqual(capturedIntPortArg, 6667,
                   $"The TCP client should connect to port 6667, but it's trying to connect to {capturedIntPortArg}");
            } 
            else if (capturedIPEndPointArg != null)
            {
                
                IPAddress capturedIpAddrres = capturedIPEndPointArg.Address;
                int capturedPort = capturedIPEndPointArg.Port;
                bool sameIpAddres = Equals(capturedIpAddrres, IPAddress.Parse("127.0.0.1"));
                Assert.IsTrue(sameIpAddres,
                  $"The TCP client should connect to IP address {IPAddress.Parse("127.0.0.1")}, but it's connecting to {capturedIpAddrres}");
                Assert.AreEqual(capturedPort, 6667,
                    $"The TCP client should connect to port 6667, but it's trying to connect to {capturedPort}");

            }
            

        }


        [TestMethod]
        public void EstablishConnectionWithTcpClient_ThrowsSocketExceptionWhenConnecting()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();

            // Set up the Connect method to throw a SocketException
            tcpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>()))
                .Throws(new SocketException());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress>(), It.IsAny<int>()))
                .Throws(new SocketException());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPEndPoint>()))
                .Throws(new SocketException());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress[]>(), It.IsAny<int>()))
                .Throws(new SocketException());

            //Act
            bool isSocketException = NetworkExercises.EstablishConnectionWithTcpClientException(tcpClientMock.Object);
            //Assert
            bool methodWasCalled = tcpClientMock.Invocations.Any(invocation => invocation.Method.Name == "Connect");
            int numberCalleds = tcpClientMock.Invocations.Count(invocation => invocation.Method.Name == "Connect");
            Assert.IsTrue(methodWasCalled);
            Assert.AreEqual(1, numberCalleds, "The method should only be called once");
            Assert.IsFalse(isSocketException,
                "The EstablishConnectionWithTcpClientException method was expected to return " +
                "false due to a SocketException, but it returned true instead. ");

        }

        [TestMethod]
        public void EstablishConnectionWithTcpClient_ThrowExceptionWhenConnecting()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();

            // Set up the Connect method to throw a SocketException
            tcpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>()))
                .Throws(new Exception());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress>(), It.IsAny<int>()))
                .Throws(new Exception());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPEndPoint>()))
                .Throws(new Exception());
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress[]>(), It.IsAny<int>()))
                .Throws(new Exception());

            //Act and Assert
            Assert.ThrowsException<Exception>(() => NetworkExercises.EstablishConnectionWithTcpClientException(tcpClientMock.Object),
                 "The method should only catch a SocketException, but it caught a different exception.");
        }



        [TestMethod]
        public void EstablishConnectionWithTcpClient_ThrowsNoExceptionWhenConnecting()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();

            // Set up the Connect method to throw a SocketException
            tcpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress>(), It.IsAny<int>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPEndPoint>()));
            tcpClientMock.Setup(x => x.Connect(It.IsAny<IPAddress[]>(), It.IsAny<int>()));

            //Act
            bool isSocketException = NetworkExercises.EstablishConnectionWithTcpClientException(tcpClientMock.Object);
            //Assert
            bool methodWasCalled = tcpClientMock.Invocations.Any(invocation => invocation.Method.Name == "Connect");
            int numberCalleds = tcpClientMock.Invocations.Count(invocation => invocation.Method.Name == "Connect");
            Assert.IsTrue(methodWasCalled);
            Assert.AreEqual(1, numberCalleds, "The method should only be called once");
            Assert.IsTrue(isSocketException,
                "The EstablishConnectionWithTcpClientException method was expected to return " +
                "true due to no Exception, but it returned false instead. ");

        }



        [TestMethod]
        public void GetNetworkStream_ReturnsNetworkStreamFromTcpClient()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();
            var networkStreamMock = new Mock<INetworkStream>();
            tcpClientMock.Setup(x => x.GetStream()).Returns(networkStreamMock.Object);

            //Act 

            INetworkStream returnedStream = NetworkExercises.GetNetworkStream(tcpClientMock.Object);
            //Assert

            tcpClientMock.Verify(tc => tc.GetStream(), Times.Once,
                "The get stream messages should only be called once");

            Assert.AreSame(networkStreamMock.Object, returnedStream, 
                "The returned NetworkStream is not the same as that is returnd from GetStream() method.");

        }


       [TestMethod]
        public void ReadMessageFromNetworkStream_ReturnsExpectedString()
        {
            //Arrange
            string inputString = "Hello World!";
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputString);
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback((byte[] Inputedbuffer, int InputedOffset, int InputedCount) =>
                {
                    int bytesRead = Math.Min(InputedCount, utf8Bytes.Length);
                    Array.Copy(utf8Bytes, 0, Inputedbuffer, 0, bytesRead);
                }).Returns(utf8Bytes.Length);
            //Act 

            string testString = NetworkExercises.ReadfromStrem(networkStreamMock.Object);
            //Assert

            Assert.AreEqual(inputString, testString, 
                $"The Stream returned the expected message: \"{inputString}\", but you returned: \"{testString}\"");


        }


        [TestMethod]
        public void SendMessageToNetworkStream_WritesExpectedString()
        {
            //Arrange
            string message = "Hello World!";
            byte[] inputedBuffer = new byte[1024];
            int inputedOffset = 0;
            int inputedBytesLenght = 0;
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback((byte[] buffer, int offset, int count) => {
                    inputedBuffer = buffer;
                    inputedOffset = offset;
                    inputedBytesLenght = count;

                });
            //Act
            NetworkExercises.WriteToStream(networkStreamMock.Object);

            //Assert
            string testString = Encoding.UTF8.GetString(inputedBuffer, inputedOffset, inputedBytesLenght);
            Assert.AreEqual(message, testString,
                $"The Write method expected to get: \"{message}\", but received: \"{testString}\"");
        }


        [TestMethod]
        public void StartListening_StartsTcpListener()
        {
            //Arrange
            var tcpListnerMock = new Mock<ITcpListener>();
            tcpListnerMock.Setup(x => x.Start());
            //Act
            NetworkExercises.StartListing(tcpListnerMock.Object);
            //Assert
            tcpListnerMock.Verify(x => x.Start(), Times.Once);

        }

       [TestMethod]
        public void AcceptTcpClient_ReturnsAcceptedTcpClient()
        {
            //Arrange
            var tcpListnerMock = new Mock<ITcpListener>();
            var tcpClientMock = new Mock<ITcpClient>();

            tcpListnerMock.Setup(x => x.AcceptTcpClient()).Returns(tcpClientMock.Object);
            //Act
            ITcpClient tcpList = NetworkExercises.AcceptClinets(tcpListnerMock.Object);
            //Assert
            Assert.AreEqual(tcpList, tcpClientMock.Object, $"The returned TcpClient is not the same as that is returnd from AcceptTcpClient() method.");
        }

        [TestMethod]
        public void CloseTcpListener_StopsListening()
        {
            // Arrange
            var tcpListnerMock = new Mock<ITcpListener>();
            tcpListnerMock.Setup(x => x.Stop());
            // Act
            NetworkExercises.CloseTcpListern(tcpListnerMock.Object);
            // Assert
            tcpListnerMock.Verify(x => x.Stop(), Times.Once);
        }

        [TestMethod]
        public void ReadFromClosedConnection_ReturnsFalseOnSocketException()
        {
            // Arrange
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new SocketException());

            // Act
            bool readFromSocket = NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object);
            // Assert

            Assert.IsFalse(readFromSocket,
                "The ReadFromClosedConnection method was expected to return false due to a SocketException, but it returned true instead.");
        }


        [TestMethod]
        public void ReadFromConnectionThrowsExceptionOnOtherError()
        {
            // Arrange
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            // Act and Assert
            Assert.ThrowsException<Exception>(() => NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object),
                "The method should only catch a SocketException, but it caught a different exception.");
        }

        [TestMethod]
        public void ReadFromOpenConnection_ReturnsTrueOnSuccessfulRead()
        {
            //Arrange
            string inputString = "Hello world";
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputString);
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback((byte[] Inputedbuffer, int InputedOffset, int InputedCount) =>
                {
                    int bytesRead = Math.Min(InputedCount, utf8Bytes.Length);
                    Array.Copy(utf8Bytes, 0, Inputedbuffer, 0, bytesRead);
                }).Returns(utf8Bytes.Length);
            //Act 

            bool readFromSocket = NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object);
            //Assert

            Assert.IsTrue(readFromSocket, 
                "The ReadFromClosedConnection method was expected to return true , but it returned false instead.");

        }


    }
}