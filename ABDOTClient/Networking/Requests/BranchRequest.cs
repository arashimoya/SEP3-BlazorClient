using System;
using System.Collections.Generic;
using System.Data;
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
        //With the root classes, make sure that you name the field inside according to what
        //is actually inside the Data{} that graphQL returns, so for example in CreateBranchRoot the branch that comes for graphQL is called createBranch{} not just branch{} (see inside)
        private class BranchesRoot
        {
            public List<Branch> branches { get; set; }

            public BranchesRoot()
            {
                branches = new List<Branch>();
            }
        }

        private class BranchRoot
        {
            public Branch branch { get; set; }
        }

        private class DeleteRoot
        {
            public bool deleteBranch { get; set; }
        }
        

        private class CreateBranchRoot
        {
            //this has to be createBranch because thats how it comes from graphQL, same for edit branch...just query from banana cake and you will see what to put here
            public Branch createBranch { get; set; }
        }

        private class EditBranchRoot
        {
            //same here, also u can see how im calling this later when im printing/returning it
            public Branch editBranch { get; set; }
        }

        private IList<Branch> Branches;
        private GraphQLHttpClient graphQlClient;
        public BranchRequest()
        {
            //make sure to put this in every class u make for this otherwise u will be very sad :(
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            Branches = new List<Branch>();
            if (!Branches.Any()) Seed();
        }
        public async Task<Branch> CreateBranch(Branch branch)
        {
            //best way to test everything is to put print just before return and call the method with all required arguments from client constructor #certified
            
            
            // i noticed that when we first made the interfaces on client we set some create and edit methods to return BOOL, these should return the created/edited branch instead
            // and compare it versus null to find out if it was created, so u will have to follow the chain and change the return type, its not too big of a deal
            // later we can see if its possible to retrieve the HTTP status code from the response from graphQL, but i dont think so
            
            // also delete methods accept the whole object/branch for some reason, they should just accept the branch.id, so u should follow the chain there aswell and change it, also not a very big deal
            // as rider suggest u this by itself when u hit build :)
            
            
            
            // set query
            // best to write this in banana cake and test it and then just copy it here, especially if u use variables
            // also pay attention to the syntax of these variables when there is object (in edit and create), it took me some time to figure out but if u follow this u will be good
            
            //also pay very very close attention to how the arguments are named in the graphQL project, in AddBranch, EditBranch classes etc, including capitalisation and types, because otherwise it wont work
            //u will get internal server error / unexpected execution
            //sometimes its called Id, sometimes its called just branchId, sometimes its Int sometimes its Long -- not ideal but now its too late so just check it :C
            
            // too much texto didnt read 
            string query = @"
                        mutation ($city: String!, $street: String!, $postcode: String!, $country: String!) {
                          createBranch (branch: {city: $city, street: $street, country: $country, postcode: $postcode}){
                            city,
                            country,
                            street,
                            postcode,
                            employees{
                              firstName,
                              lastName
                            },
                            halls{
                              id,
                              hallSize
                            }
                          }
                        }          
                        ";
            
            //Set variables
            var variables = new
            {
                city = branch.City,
                street = branch.Street,
                postcode = branch.Postcode,
                country = branch.Country
            };
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<CreateBranchRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateBranchRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            return graphQLResponse.Data.createBranch;
        }

        public async Task<Branch> EditBranch(Branch branch)
        {
            string query = @"
                        mutation ($id : Long!, $city: String!, $street: String!, $postcode: String!, $country: String!) {
                          editBranch (branch: {id : $id, city: $city, street: $street, country: $country, postcode: $postcode}){
                            id,
                            city,
                            country,
                            street,
                            postcode,
                            employees{
                              firstName,
                              lastName
                            },
                            halls{
                              id,
                              hallSize
                            }
                          }
                        }          
                        ";
            
            //Set variables
            var variables = new
            {
                id = branch.Id,
                city = branch.City,
                street = branch.Street,
                postcode = branch.Postcode,
                country = branch.Country
            };
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<EditBranchRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditBranchRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            Console.WriteLine(graphQLResponse.Data.editBranch.City);
            return graphQLResponse.Data.editBranch;
        }

        public async Task<bool> DeleteBranch(long branchId)
        {
            //set query
            string query = @"
                        mutation ($id : Long!) {
                          deleteBranch (branchId: $id)
                        }           
                        ";
            
            //Set variables
            var variables = new
            {
                id = branchId
            };
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request
            var graphQLResponse = new GraphQLResponse<DeleteRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return
            return graphQLResponse.Data.deleteBranch;
        }

        public async Task<Branch> GetBranch(int BranchId)
        {
            //set query
            string query = @"
                        query ($id : Int!) {
                          branch (id: $id){
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
            
            //Set variables
            var variables = new
            {
                id = BranchId
            };
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<BranchRoot>(graphQLRequest);
            //Return
            return graphQLResponse.Data.branch;
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
            var graphQLResponse = await graphQlClient.SendQueryAsync<BranchesRoot>(graphQLRequest);
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
                        new Hall(1)
                        {
                            Id = 1,
                            Programme = new List<Play>()
                            {
                                new Play
                                {
                                    Id = 1,
                                    Movie = new Movie
                                    {
                                        Id = 1,
                                        Description = "The 1930s. A bankrupt director and a starving actress travel to the mysterious Skull Island to shoot a movie of their life, as New York is in a great crisis. ",
                                        Director = "Peter Jackson",
                                        Genre = "Adventure, Melodrama, Fantasy",
                                        Language = "English",
                                        LengthInMinutes = 200,
                                        Year = 2005,
                                        Title = "King Kong",
                                        PosterSrc = "/images/king_kong.jpg",
                                    },
                                    Date = DateTime.Now.AddDays(1),
                                    Hall = new Hall(1),
                                    Tickets = new List<Ticket>
                                    {
                        
                                    },
                                    TimeInMinutes = 200,
                                },
                            },
                            
                        },
                        new Hall(2)
                        {
                            Id = 2,
                            Programme = new List<Play>()
                            {
                                new Play
                                {
                                    Id = 2,
                                    Date = DateTime.Now,
                                    Hall = new Hall(2),
                                    Movie = new Movie
                                    {
                                        Id = 2,
                                        Title = "Forrest Gump",
                                        Director = "Robert Zemeckis",
                                        Genre = "Drama / Comedy",
                                        Year = 2004,
                                        Description = "The life story of Forrest, a boy with a low IQ with paralysis, who becomes a billionaire and a hero of the Vietnam War.",
                                        Language = "English",
                                        LengthInMinutes = 186,
                                        PosterSrc = "/images/forrest_gump.jpg",
                                    },
                                    Tickets = new List<Ticket>(),
                                    TimeInMinutes = 186,
                                },
                                
                            }
                        },
                    },
                },
                new Branch()
                {
                    Id = 2,
                    City = "Sonderborg",
                    Employees = new List<Employee>(),
                    Halls = new List<Hall>()
                    {
                        new Hall(2)
                        {
                            Id= 3,
                            Programme = new List<Play>()
                            {
                                new Play
                                {
                                    Id =3,
                                    Date = DateTime.Now,
                                    Hall = new Hall(3),
                                    Movie = new Movie
                                    {
                                        Id = 2,
                                        Description = "To get his home back, an ugly ogre with a talkative donkey sets off to free the beautiful princess.",
                                        Title = "Shrek",
                                        Director = "Andrew Adamson / Vicky Jenson",
                                        Genre = "Comedy, Animation, Family",
                                        Language = "English, Danish",
                                        LengthInMinutes = 90,
                                        Year = 2001,
                                        PosterSrc = "/images/shrek.jpg",
                                    },
                                    Tickets = new List<Ticket>(),
                                    TimeInMinutes = 90,
                                },
                            }
                        },
                        new Hall(3)
                        {
                            Id = 4,
                            Programme = new List<Play>()
                            {
                                new Play
                                {
                                    Id = 4,
                                    Date = DateTime.Now,
                                    Hall = new Hall(1),
                                    Movie = new Movie
                                    {
                                        Id = 3,
                                        Title = "Shawshank Redemption",
                                        // Cast = new List<Actor>(),
                                        Description =
                                            "Adaptation of a Stephen King short story. A banker who is wrongly sentenced to life imprisonment, tries to survive in a brutal prison world. ",
                                        Director = "Frank Darabont",
                                        Genre = "Drama",
                                        Language = "English",
                                        LengthInMinutes = 110,
                                        Year = 1994,
                                        PosterSrc = "/images/shawshank.jpg"
                                    },
                                    Tickets = new List<Ticket>(),
                                    TimeInMinutes = 110,
                                },
                            }
                        },
                    },
                },
            };
            
            BranchArray[0].Halls[0].Branch = BranchArray[0];
            BranchArray[0].Halls[0].Programme[0].Hall = BranchArray[0].Halls[0];
            BranchArray[0].Halls[0].Programme[0].Hall.Branch = BranchArray[0];
            
            BranchArray[0].Halls[1].Branch = BranchArray[0];
            BranchArray[0].Halls[1].Programme[0].Hall = BranchArray[0].Halls[1];
            BranchArray[0].Halls[1].Programme[0].Hall.Branch = BranchArray[0];
            
            
            BranchArray[1].Halls[0].Branch = BranchArray[1];
            BranchArray[1].Halls[0].Programme[0].Hall = BranchArray[1].Halls[0];
            BranchArray[1].Halls[0].Programme[0].Hall.Branch = BranchArray[0];
            
            BranchArray[1].Halls[1].Branch = BranchArray[1];
            BranchArray[1].Halls[1].Programme[0].Hall = BranchArray[1].Halls[1];
            BranchArray[1].Halls[1].Programme[0].Hall.Branch = BranchArray[1];
            
            

            Branches = BranchArray.ToList();


        }
    }
}