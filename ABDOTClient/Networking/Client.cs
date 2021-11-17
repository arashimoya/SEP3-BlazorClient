using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class Client {
        private TcpClient client;
        private NetworkStream stream;

        public void RunClient() {
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            Console.WriteLine("client running");
        }

        private void ServerRequest(string typeToServer, Object objectToServer) {
            //object
            string objectToServerSerialized = JsonSerializer.Serialize(objectToServer);
            byte[] objectToServerInBytes = Encoding.ASCII.GetBytes(objectToServerSerialized);

            //size
            int size = Encoding.ASCII.GetByteCount(objectToServerSerialized);
            byte[] sizeToServerInBytes = BitConverter.GetBytes(size);

            //type
            string typeToServerSerialized = JsonSerializer.Serialize(typeToServer);
            byte[] typeToServerInBytes = Encoding.ASCII.GetBytes(typeToServerSerialized);
            Console.WriteLine(typeToServer);

            //send information to server
            stream.Write(sizeToServerInBytes, 0, sizeToServerInBytes.Length);
            stream.Write(objectToServerInBytes, 0, objectToServerInBytes.Length);
            stream.Write(typeToServerInBytes, 0, typeToServerInBytes.Length);
        }

        //Universal method for receiving callback from server always returns 
        //JSON string with object from the server
        private string ServerResponse() {
            var responseFromServerRead = "";
            try {
                //size
                var sizeFromServer = new byte[1024];
                stream.Read(sizeFromServer, 0, sizeFromServer.Length);
                var sizeFromServerRead = BitConverter.ToInt32(sizeFromServer);

                //response
                var responseFromServer = new byte[sizeFromServerRead];
                stream.Read(responseFromServer, 0, responseFromServer.Length);
                responseFromServerRead = Encoding.ASCII.GetString(responseFromServer, 0, responseFromServer.Length);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            client.Close();
            Console.WriteLine("Client closed");
            return responseFromServerRead;
        }

        public bool RegisterUser(string typeToServer, Object toServer) {
            ServerRequest(typeToServer, toServer);
            var response = ServerResponse();
            return JsonSerializer.Deserialize<bool>(response);
        }

        public User LoginUser(string typeToServer, Object toServer) {
            ServerRequest(typeToServer, toServer);
            var response = ServerResponse();
            var user = JsonSerializer.Deserialize<User>(response);
            return user;
        }
    }
}