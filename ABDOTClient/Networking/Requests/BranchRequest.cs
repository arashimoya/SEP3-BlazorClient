using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests.Interfaces;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking.Requests
{
    public class BranchRequest : IBranchRequest
    {
        private IList<Branch> Branches;
        private GraphQLHttpClient graphQlClient;
        public BranchRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            Branches = new List<Branch>();
            // if (!Branches.Any()) Seed();
        }
        //these are for testing the site --Adam
        public async Task<bool> CreateBranch(Branch branch)
        {
            
            // int max = Branches.Max(b => b.Id);
            // //branch.Id = (++max);
            // Branches.Add(branch);
            // return true;
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
            var getAllbranches = new GraphQLRequest
            {
                Query = @"
                   Branches{
                        id,
                        street,
                        city,
                        postcode,
                        country,
                        halls{{
                         id
                        }},
                        employees{
                        id}
                   }                    
                        "
            };
            var graphQlResponse = new GraphQLResponse<List<Branch>>();
            try
            {
                graphQlResponse = await graphQlClient.SendQueryAsync<List<Branch>>(getAllbranches);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            foreach (Branch branch in graphQlResponse.Data)
            {
                Console.WriteLine(branch.ToString());
            }
            return graphQlResponse.Data;
        }

        private void Seed()
        {
            Branches = new List<Branch>
            {
                new Branch()
                {
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
                    City = "Sonderborg",
                    Employees = new List<Employee>(),
                    Halls = new List<Hall>()
                    {
                        new Hall(2),
                        new Hall(3),
                    },
                },
            };
        }
    }
}