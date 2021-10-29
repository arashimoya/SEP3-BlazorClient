using System;

namespace Server{
    class RunServer{
        static void Main(string[] args){
            Console.WriteLine("Start server...");
            ClientConnection.Server server = new ClientConnection.Server();
            server.RunServer();

        }
    }
}