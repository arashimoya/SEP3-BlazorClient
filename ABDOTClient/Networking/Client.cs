using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking{
    public class Client{
        private TcpClient client;
        private NetworkStream stream;

        public void RunClient(){
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            
        }

        private void ServerRequest(string typeToServer, Object objectToServer){
            

            //object
            string objectToServerSerialized = JsonSerializer.Serialize(objectToServer);
            byte[] objectToServerInBytes = Encoding.ASCII.GetBytes(objectToServerSerialized);

            //size
            int size = Encoding.ASCII.GetByteCount(objectToServerSerialized);
            byte[] sizeToServerInBytes = BitConverter.GetBytes(size);

            //type
            string typeToServerSerialized = JsonSerializer.Serialize(typeToServer);
            byte[] typeToServerInBytes = Encoding.ASCII.GetBytes(typeToServerSerialized);

            //send information to server
            stream.Write(sizeToServerInBytes, 0, sizeToServerInBytes.Length);
            stream.Write(typeToServerInBytes, 0, typeToServerInBytes.Length);
            stream.Write(objectToServerInBytes, 0, objectToServerInBytes.Length);
        }


        private async Task<string> ServerResponse(){
            
            //size
            byte[] sizeFromServer = new byte[1024];
            await stream.ReadAsync(sizeFromServer, 0, sizeFromServer.Length);
            int sizeFromServerRead = BitConverter.ToInt32(sizeFromServer);
            
            //response
            byte[] responseFromServer = new byte[sizeFromServerRead];
            await stream.ReadAsync(responseFromServer, 0, sizeFromServerRead);
            string responseFromServerRead = Encoding.ASCII.GetString(responseFromServer, 0, sizeFromServerRead);
            client.Close();
            return responseFromServerRead;
        }

        public async Task<bool> RegisterUser(string typeToServer, Object toServer){
            ServerRequest(typeToServer, toServer);
            string response = await ServerResponse();
            
            if (response.Equals("true")){
                return true;
            }
            return false;
        }

        public async Task<User> LoginUser(string typeToServer, Object toServer){
            ServerRequest(typeToServer, toServer);
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            stream.Close();
            client.Close();
            User user = JsonSerializer.Deserialize<User>(response);
            return user;
        }
    }
}