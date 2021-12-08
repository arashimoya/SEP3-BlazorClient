using GraphQL;

namespace ABDOTClient.Networking
{
    public static class GraphQLUtility
    {
        
        public static GraphQLRequest MakeGraphQLRequest(string query, string operationName, object variables)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName,
                Variables = variables
            };
            return request;
        }
        
        public static GraphQLRequest MakeGraphQLRequest(string query, string operationName)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName
            };
            return request;
        }
        
        public static GraphQLRequest MakeGraphQLRequest(string query, object variables)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query,
                Variables = variables
            };
            return request;
        }
        
        public static GraphQLRequest MakeGraphQLRequest(string query)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query
            };
            return request;
        }

        
    }
}