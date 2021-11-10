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
using ABDOTClient.Model;
using LoginComponent;
using Microsoft.AspNetCore.Mvc;

namespace Server.ClientConnection{
    public class Server : IServer{
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private TcpListener listener = new(ip, 5000);
        private static readonly HttpClient client = new HttpClient();

        public async Task RunServer(){
            Console.WriteLine("Server runs");

            listener.Start();
            while (true){
                TcpClient tcpClient = listener.AcceptTcpClient();
                new Thread(async () => {
                    NetworkStream stream = tcpClient.GetStream();
                    //size
                    byte[] sizeFromServer = new byte[1024];
                    await stream.ReadAsync(sizeFromServer, 0, sizeFromServer.Length);
                    int sizeFromServerRead = BitConverter.ToInt32(sizeFromServer);

                    //type 
                    byte[] typeFromServer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(typeFromServer, 0, typeFromServer.Length);
                    string typeFromServerRead = Encoding.ASCII.GetString(typeFromServer, 0, bytesRead);

                    //response
                    byte[] objectFromClient = new byte[sizeFromServerRead];
                    await stream.ReadAsync(objectFromClient, 0, sizeFromServerRead);
                    string objectFromClientRead = Encoding.ASCII.GetString(objectFromClient, 0, sizeFromServerRead);


                    switch (typeFromServerRead){
                        case ("register"):
                            await PostUser(objectFromClientRead);
                            break;
                        case ("login"):
                            await Login();
                            break;
                    }
                }).Start();
            }
        }

        static async Task<bool> PostUser(string user){
            Console.WriteLine("Post method runs");
            StringContent content = new StringContent(
                user,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/register", content);
            if (!response.IsSuccessStatusCode){
                Console.WriteLine("Error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
            return true;
        }
    }
}