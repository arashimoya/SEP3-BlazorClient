using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Server.ClientConnection{
    public class Server : IServer{
        private static IPAddress ip = IPAddress.Parse("127.0.0.1");
        private TcpListener listener = new(ip, 5000);
        private static readonly HttpClient client = new HttpClient();

        public Task RunServer(){
            Console.WriteLine("Server runs");

            listener.Start();
            while (true){
                var tcpClient = listener.AcceptTcpClient();
                Console.WriteLine("while");
                new Thread(async () => {
                    Console.WriteLine("connection accepted");
                    await using var stream = tcpClient.GetStream();
                    //size
                    var sizeFromServer = new byte[1024];
                    stream.Read(sizeFromServer, 0, sizeFromServer.Length);
                    int sizeFromServerRead = BitConverter.ToInt32(sizeFromServer);
                    Console.WriteLine(sizeFromServerRead);


                    //readingObject
                    var objectFromClient = new byte[sizeFromServerRead];
                    await stream.ReadAsync(objectFromClient, 0, sizeFromServerRead);
                    var objectFromClientRead = Encoding.ASCII.GetString(objectFromClient, 0, sizeFromServerRead);
                    Console.WriteLine(objectFromClientRead);


                    //type 
                    var typeFromServer = new byte[1024];
                    int bytesRead = stream.Read(typeFromServer, 0, typeFromServer.Length);
                    var typeFromServerRead = Encoding.ASCII.GetString(typeFromServer, 0, bytesRead);
                    Console.WriteLine(typeFromServerRead);
                    await CallCorrectMethod(JsonSerializer.Deserialize<string>(typeFromServerRead),
                        objectFromClientRead, stream);
                }).Start();
            }
        }

        private async Task CallCorrectMethod(string type, string objectToServer, NetworkStream stream){
            switch (type){
                case ("register"):
                    await PostUser(objectToServer, stream);
                    break;
                case ("login"):
                    await ValidateUser(objectToServer, stream);
                    break;
                case ("addmovie"):
                    await AddMovie(objectToServer, stream);
                    break;
            }
        }

        private async Task ClientCallback(Object objectToClient, NetworkStream stream){
            var objectToClientSerialized = JsonSerializer.Serialize(objectToClient);
            var objectToClientInBytes = Encoding.ASCII.GetBytes(objectToClientSerialized);

            //size
            int size = Encoding.ASCII.GetByteCount(objectToClientSerialized);
            var sizeToClientInBytes = BitConverter.GetBytes(size);

            try{
                await stream.WriteAsync(sizeToClientInBytes, 0, sizeToClientInBytes.Length);
                await stream.WriteAsync(objectToClientInBytes, 0, objectToClientSerialized.Length);
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task PostUser(string user, NetworkStream stream){
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

            Console.WriteLine($"User {user} registered successfully");
            await ClientCallback(true, stream);
        }

        private async Task ValidateUser(string user, NetworkStream stream){
            Console.WriteLine("Validating user /server");
            StringContent content = new StringContent(
                user,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/users/login", content);
            if (!response.IsSuccessStatusCode){
                Console.WriteLine("Server error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
            string userAsJson = await response.Content.ReadAsStringAsync();
            await ClientCallback(userAsJson, stream);
        }

        private async Task AddMovie(string movie, NetworkStream stream){
            Console.WriteLine("adding movie /server method");
            
            StringContent content = new StringContent(
                movie,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/api/movies", content);
            if (response.StatusCode != HttpStatusCode.Created){
                Console.WriteLine("Server error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
            await ClientCallback(true, stream);
        }
    }
}