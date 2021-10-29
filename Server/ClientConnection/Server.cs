using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.ClientConnection{
    public class Server : IServer{
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private TcpListener listener = new TcpListener(ip, 5000);
        private static readonly HttpClient client = new HttpClient();
        
        public async void RunServer(){
            listener.Start();
            while (true){
                TcpClient tcpClient = listener.AcceptTcpClient();
                new Thread(() => {
                    NetworkStream stream = tcpClient.GetStream();
                    //byte[] size = new byte[1024];
                    byte[] fromClient = new byte[2000];
                    int bytesRead = stream.Read(fromClient, 0, fromClient.Length);
                    string objectAsJson = Encoding.ASCII.GetString(fromClient, 0, bytesRead);
                    
                    
                }).Start();
            }
        }
        
        static async Task PostUser ()
        {
            StringContent content = new StringContent(
            user,
            Encoding.UTF8,
            "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/register", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            else
                Console.Write("Success");
        }
}