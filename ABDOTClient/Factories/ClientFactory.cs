using ABDOTClient.Networking;

namespace ABDOTClient.Factories{
    public sealed class ClientFactory{
        private static volatile Client client;
        private static object syncRoot = new object();


        public static Client GetClient(){
            if (client == null){
                lock (syncRoot){
                    if (client == null){
                        client = new Client();
                    }
                }
            }

            return client;
        }
    }
}