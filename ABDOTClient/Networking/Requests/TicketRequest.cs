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

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
           
            string query = @"mutation ($column : Int!, $row : Int!, $playId : Long!, $employeeId : Long!) {
    createTicket(ticket: {column : $column, row : $row, playId : $playId, employeeId : $employeeId}) {
    id,
    row,
    column,
    play {
      id
    },
    employee {
      id
    } 
    }
  }";
            
            // Might get changed
            var variables = new
            {
                playId = ticket.Play.Id,
                employeeId = ticket.Employee.Id,
                row = ticket.Row,
                column = ticket.Column
            };

            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQLResponse = new GraphQLResponse<CreateTicketRoot>();

            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                throw;
            }

            return graphQLResponse.Data.createTicket;
        }

        public async Task<Ticket> EditTicket(Ticket ticket)
        {
            string query = @" mutation ($id : Long!, $column : Int!, $row : Int!, $playId : Long!, $employeeId : Long!) {
    editTicket(ticket: {id : $id, column : $column, row : $row, playId : $playId, employeeId : $employeeId}) {
    id,
    row,
    column,
    play {
      id
    }
    employee {
      id
    } 
    }
  }";
            
            
            var variables = new
            {
                id = ticket.Id,
                playId = ticket.Play.Id,
                employeeId = ticket.Employee.Id,
                row = ticket.Row,
                column = ticket.Column
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<EditTicketRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                throw;
            }

            
            return graphQLResponse.Data.editTicket;  
        }

        public async Task<bool> DeleteTicket(int id)
        {
            string query = @"  mutation ($ticketId : Long!) {
    deleteTicket(ticketId : $ticketId)
  }";
            
            
            var variables = new
            {
                ticketId = id
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<DeleteTicketRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteTicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                throw;
            }
            
            return graphQLResponse.Data.deleteTicket;
        }

        public async Task<Ticket> GetTicket(int ticketId)
        {
            string query = @"query ($id : Int!) {
  ticket (id : $id) {
    id,
    row,
    column,
    play {
      id
    }
    employee {
      id
    } 
  }
}";
            
            
            var variables = new
            {
                id = ticketId
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);

            var graphQLResponse = new GraphQLResponse<TicketRoot>();
            try
            { 
                graphQLResponse = await graphQlClient.SendQueryAsync<TicketRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                
                throw;
            }

            return graphQLResponse.Data.ticket;
        }

        public async Task<IList<Ticket>> GetAllTickets()
        {
            string query = @"query {
 tickets {
   id,
   row,
   column,
   employee {
     id
   }
   play{
     id,
     movie {
       id,
       title
     }
   }
    } 
  }";
        
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            var graphQLResponse = new GraphQLResponse<TicketsRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendQueryAsync<TicketsRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                
                throw;
            }

            return graphQLResponse.Data.tickets;
        }
        
    }
}