using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server.ClientConnection {
    public class Server : IServer {
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private TcpListener listener = new(ip, 5000);
        private static readonly HttpClient client = new HttpClient();

        public async Task RunServer() {
            Console.WriteLine("Server runs");

            listener.Start();
            while (true) {
                TcpClient tcpClient = listener.AcceptTcpClient();
                new Thread(async () => {
                    NetworkStream stream = tcpClient.GetStream();
                    //size
                    byte[] sizeFromServer = new byte[1024];
                    stream.Read(sizeFromServer, 0, sizeFromServer.Length);
                    int sizeFromServerRead = BitConverter.ToInt32(sizeFromServer);

                    //readingObject
                    byte[] objectFromClient = new byte[sizeFromServerRead];
                    await stream.ReadAsync(objectFromClient, 0, sizeFromServerRead);
                    string objectFromClientRead = Encoding.ASCII.GetString(objectFromClient, 0, sizeFromServerRead);

                    //type 
                    byte[] typeFromServer = new byte[1024];
                    int bytesRead = stream.Read(typeFromServer, 0, typeFromServer.Length);
                    string typeFromServerRead = Encoding.ASCII.GetString(typeFromServer, 0, bytesRead);

                    await CallCorrectMethod(JsonSerializer.Deserialize<string>(typeFromServerRead),
                        objectFromClientRead, stream);
                }).Start();
            }
        }

        public async Task<bool> PostUser(string user, NetworkStream stream) {
            Console.WriteLine("Post method runs");
            // StringContent content = new StringContent(
            //     user,
            //     Encoding.UTF8,
            //     "application/json"
            // );
            // HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/register", content);
            // if (!response.IsSuccessStatusCode){
            //     Console.WriteLine("Error");
            //     throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            // }
            //
            // Console.WriteLine("success");
            Console.WriteLine("post method called with " + user);
            await ClientCallback(user, stream);
            return true;
        }

        static async Task<string> ValidateUser(string user) {
            Console.WriteLine("Validating user /server");
            StringContent content = new StringContent(
                user,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/login", content);
            if (!response.IsSuccessStatusCode) {
                Console.WriteLine("Server error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
            string userAsJson = await response.Content.ReadAsStringAsync();
            return userAsJson;
        }

        private async Task CallCorrectMethod(string type, string user, NetworkStream stream) {
            switch (type) {
                case ("register"):
                    await PostUser(user, stream);

                    break;
                case ("login"):
                    await ValidateUser(user);
                    break;
            }
        }

        private async Task ClientCallback(Object objectToClient, NetworkStream stream) {
            string objectToClientSerialized = JsonSerializer.Serialize(objectToClient);
            byte[] objectToClientInBytes = Encoding.ASCII.GetBytes(objectToClientSerialized);

            //size
            int size = Encoding.ASCII.GetByteCount(objectToClientSerialized);
            byte[] sizeToClientInBytes = BitConverter.GetBytes(size);

            try {
                await stream.WriteAsync(sizeToClientInBytes, 0, sizeToClientInBytes.Length);
                await stream.WriteAsync(objectToClientInBytes, 0, objectToClientSerialized.Length);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}