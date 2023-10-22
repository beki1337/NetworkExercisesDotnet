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
        public void PerformConnection()
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
            Assert.IsTrue(methodWasCalled);
            Assert.AreEqual(1, numberCalled, "The Connect method should only be called once to enforce proper behavior");

        }



        [TestMethod]
        public void CheckCorrecket_Connection()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();
            string? capturedStringIpAddressArg = null;
            int capturedIntPortArg = 0;
            IPAddress capturedIpAddressArg = null;
            IPEndPoint capturedIPEndPointArg = null;
            IPAddress[] capturedIpAddressArrayArg = null;
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



        }


        [TestMethod]
        public void Connect_ThrowsSocketError()
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
            NetworkExercises.EstablishConnectionWithTcpClientException(tcpClientMock.Object);
            //Assert
            bool methodWasCalled = tcpClientMock.Invocations.Any(invocation => invocation.Method.Name == "Connect");
            int numberCalleds = tcpClientMock.Invocations.Count(invocation => invocation.Method.Name == "Connect");
            Assert.IsTrue(methodWasCalled);
            Assert.AreEqual(1, numberCalleds, "The method should only called once");

        }

        [TestMethod]
        public void Connect_ThrowsExpeions()
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
            Assert.ThrowsException<Exception>(() => NetworkExercises.EstablishConnectionWithTcpClientException(tcpClientMock.Object));
        }


        [TestMethod]
        public void Get_NetworkStrem()
        {
            //Arrange
            var tcpClientMock = new Mock<ITcpClient>();
            var networkStreamMock = new Mock<INetworkStream>();
            tcpClientMock.Setup(x => x.GetStream()).Returns(networkStreamMock.Object);

            //Act 

            NetworkExercises.GetNetworkStream(tcpClientMock.Object);
            //Assert

            tcpClientMock.Verify(tc => tc.GetStream(), Times.Once);

        }





        [TestMethod]
        public void ReadMessage()
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

            string testString = NetworkExercises.ReadfromStrem(networkStreamMock.Object);
            //Assert

            Assert.AreEqual(inputString, testString);


        }


        [TestMethod]
        public void SendMessage()
        {
            //Arrange
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
            Assert.AreEqual("Hello world", testString);
        }


        [TestMethod]
        public void StartListning()
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
        public void AccepetTcpClient()
        {
            //Arrange
            var tcpListnerMock = new Mock<ITcpListener>();
            var tcpClientMock = new Mock<ITcpClient>();

            tcpListnerMock.Setup(x => x.AcceptTcpClient()).Returns(tcpClientMock.Object);
            //Act
            ITcpClient tcpList = NetworkExercises.AcceptClinets(tcpListnerMock.Object);
            //Assert
            Assert.AreEqual(tcpList, tcpClientMock.Object);
        }

        [TestMethod]
        public void Stop()
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
        public void ReadConnectionClosed()
        {
            // Arrange
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new SocketException());

            // Act
            bool answer = NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object);
            // Assert
            Assert.IsTrue(!answer);
        }


        [TestMethod]
        public void ReadConnectionOtherError()
        {
            // Arrange
            var networkStreamMock = new Mock<INetworkStream>();
            networkStreamMock.Setup(x => x.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            // Act and Assert
            Assert.ThrowsException<Exception>(() => NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object));
        }

        [TestMethod]
        public void ReadfromOpenConnection()
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

            bool answer = NetworkExercises.ReadFromClosedConnection(networkStreamMock.Object);
            //Assert

            Assert.IsTrue(answer);

        }


    }
}