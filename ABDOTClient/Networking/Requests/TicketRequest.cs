using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking.Requests
{
    public class TicketRequest : ITicketRequest
    {
        private class TicketsRoot
        {
            public List<Ticket> tickets { get; set; }

            public TicketsRoot()
            {
                tickets = new List<Ticket>();
            }
        }

        private class TicketRoot
        {
            public Ticket ticket { get; set; }
        }

        private class DeleteTicketRoot
        {
            public bool deleteTicket { get; set; }
        }

        private class CreateTicketRoot
        {
            public Ticket createTicket { get; set; }
        }

        private class EditTicketRoot
        {
            public Ticket editTicket { get; set; }
        }

        private GraphQLHttpClient graphQlClient;
        private IList<Ticket> Tickets;

        public TicketRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql",
                new NewtonsoftJsonSerializer());
            Tickets = new List<Ticket>();
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            string query = @"";
            
            // Might get changed
            var variables = new
            {
                play = ticket.Play,
                user = ticket.User,
                employee = ticket.Employee,
                row = ticket.row,
                column = ticket.column
            };

            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQLResponse = new GraphQLResponse<CreateTicketRoot>();

            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return graphQLResponse.Data.createTicket;
        }

        public async Task<Ticket> EditTicketAsync(Ticket ticket)
        {
            string query = @"";
            
            // Might get changed
            var variables = new
            {
                id = ticket.Id,
                play = ticket.Play,
                user = ticket.User,
                employee = ticket.Employee,
                row = ticket.row,
                column = ticket.column
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<EditTicketRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // Console.WriteLine(graphQLResponse.Data.editTicket.Id);
            return graphQLResponse.Data.editTicket;  
        }

        public async Task<bool> DeleteTicketAsync(int ticketId)
        {
            string query = @"";
            
            // Might get changed
            var variables = new
            {
                id = ticketId
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<DeleteTicketRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return graphQLResponse.Data.deleteTicket;
        }

        public async Task<Ticket> GetTicketAsync(int ticketId)
        {
            string query = @"";
            
            // Might get changed
            var variables = new
            {
                id = ticketId
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = await graphQlClient.SendQueryAsync<TicketRoot>(graphQLRequest);

            return graphQLResponse.Data.ticket;
        }

        public async Task<IList<Ticket>> GetAllTicketsAsync()
        {
            string query = @"";
        
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            var graphQLResponse = await graphQlClient.SendQueryAsync<TicketsRoot>(graphQLRequest);

            return graphQLResponse.Data.tickets;
        }
        
    }
}