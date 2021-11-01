using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ABDOTClient.Model;

namespace ABDOTClient.Networking{
    public class Client{
        private TcpClient client;
        private NetworkStream stream;

        public void RunClient(){
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            
        }

        public bool RegisterUser(User user){
            string userAsJson = JsonSerializer.Serialize(user);
            byte[] toServer = Encoding.ASCII.GetBytes(userAsJson);
            stream.Write(toServer, 0, toServer.Length);

            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            stream.Close();
            client.Close();
            if (response.Equals("true")){
                return true;
            }
            else return false;
        }
    }
}