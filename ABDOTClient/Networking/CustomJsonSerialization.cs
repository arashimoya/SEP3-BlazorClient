using System;
using System.Text.Json;

namespace ABDOTClient.Networking {
    public static class CustomJsonSerialization {
        private static readonly JsonSerializerOptions deserialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };

        private static readonly JsonSerializerOptions serialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static string Serialise(object instance) {
            var serializedObject = JsonSerializer.Serialize(instance, serialise);
            int start = serializedObject.IndexOf('"');
            int end = serializedObject.IndexOf(',');
            return serializedObject.Remove(start, end);
        }

        public static object Deserialise(string response) {
            return JsonSerializer.Deserialize<object>(response, deserialise);
        }
    }
}