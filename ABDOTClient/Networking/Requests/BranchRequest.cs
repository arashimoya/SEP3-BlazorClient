using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests.Interfaces;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ABDOTClient.Networking.Requests
{
    
    public class BranchRequest : IBranchRequest
    {
        
        private class BranchRoot
        {
            public List<Branch> branches { get; set; }

            public BranchRoot()
            {
                branches = new List<Branch>();
            }
        }

        private IList<Branch> Branches;
        private GraphQLHttpClient graphQlClient;
        public BranchRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            Branches = new List<Branch>();
            if (!Branches.Any()) Seed();
        }
        public async Task<bool> CreateBranch(Branch branch)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditBranch(Branch branch)
        {
            Branch toUpdate = Branches.FirstOrDefault(b => b.Id == branch.Id);
            if (toUpdate == null) return false;
            toUpdate.City = branch.City;
            toUpdate.Employees = branch.Employees;
            toUpdate.Halls = branch.Halls;
            return true;
            
        }

        public async Task<bool> DeleteBranch(Branch branch)
        {
            Branch toRemove = Branches.FirstOrDefault(b => b.Id == branch.Id);
            if (toRemove == null) return false;
            Branches.Remove(toRemove);
            return true;
        }

        public async Task<Branch> GetBranch(int BranchId)
        {
            return Branches.FirstOrDefault(b => b.Id == BranchId);
        }


        public async Task<IList<Branch>> GetAllBranches()
        {

            //Create content of the query
            string query = @"
                  query {  
                   branches{
                        id,
                        street,
                        city,
                        postcode,
                        country,
                        halls{
                         id,
                         hallSize
                        },
                        employees{
                        id,
                        firstName,
                        lastName,
                        email,
                        role,
                        cPR,
                        street,
                        city,
                        postcode,
                        country,
                        birthDate
                        }
                   }
                  }             
                        ";
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<BranchRoot>(graphQLRequest);
            //Print out result
            Console.WriteLine(graphQLResponse.Data.branches);
            foreach (Branch branch in graphQLResponse.Data.branches)
            {
                Console.WriteLine(branch.Street);
            }
            //Return
            //return graphQLResponse.Data.branches;
            return Branches;
        }

        private void Seed()
        {
            Branch[] BranchArray = 
            {
                new Branch()
                {
                    Id = 1,
                    City = "Aarhus",
                    Employees = new List<Employee>(),
                    Halls = new List<Hall>()
                    {
                        new Hall(1),
                        new Hall(2),
                    },
                },
                new Branch()
                {
                    Id = 2,
                    City = "Sonderborg",
                    Employees = new List<Employee>(),
                    Halls = new List<Hall>()
                    {
                        new Hall(2),
                        new Hall(3),
                    },
                },
            };
            BranchArray[0].Halls[0].Id = 1;
            BranchArray[0].Halls[0].Branch = BranchArray[0];
            BranchArray[0].Halls[1].Id = 2;
            BranchArray[0].Halls[1].Branch = BranchArray[0];
            
            BranchArray[1].Halls[0].Id = 3;
            BranchArray[1].Halls[0].Branch = BranchArray[1];
            BranchArray[1].Halls[1].Id = 4;
            BranchArray[1].Halls[1].Branch = BranchArray[1];

            Branches = BranchArray.ToList();


        }
    }
}