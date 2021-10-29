using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ABDOTClient.Model;

namespace ABDOTClient.Persistence
{
    public class ServerContext
    {
        private readonly string usersFile = "users.json";
        public IList<User> Users { get; set; }

        public void SaveTestChanges()
        {
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputfile = new StreamWriter(usersFile, false))
            {
                outputfile.Write(jsonUsers);
            }

        }
    }
}