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
using Microsoft.AspNetCore.Mvc;

namespace Server.ClientConnection
{
    public class Server : IServer
    {
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private TcpListener listener = new TcpListener(ip, 5000);
        private static readonly HttpClient client = new HttpClient();

        public async Task RunServer()
        {
            Console.WriteLine("Runs"); 
            
            listener.Start();
            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                new Thread(async () =>
                {
                    NetworkStream stream = tcpClient.GetStream();
                    //byte[] size = new byte[1024];
                    byte[] fromClient = new byte[2000];
                    int bytesRead = stream.Read(fromClient, 0, fromClient.Length);
                    string objectAsJson = Encoding.ASCII.GetString(fromClient, 0, bytesRead);
                    await PostUser(objectAsJson);
                }).Start();
            }
        }

        static async Task PostUser(string user)
        {
            Console.WriteLine("Post method runs");
            StringContent content = new StringContent(
                user,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/register", content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
        }
    }
}