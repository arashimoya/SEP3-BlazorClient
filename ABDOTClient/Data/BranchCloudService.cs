using System.Collections.Generic;
using System.Linq;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class BranchCloudService : IBranchService
    {
        public IList<Branch> Branches;
        
        public BranchCloudService()
        {
            Branches = new List<Branch>();
            Seed();
        }

        public IList<Branch> GetAll()
        {
            return Branches;
        }
        
        public Branch Get(int branchId)
        {
            Branch toReturn = Branches.FirstOrDefault(b => b.Id == branchId);
            return toReturn;
        }

        public Hall GetHall(int hallId)
        {
            Hall toReturn = Get(1).Halls.FirstOrDefault(h=>h.Id == hallId);
            return toReturn;
        }
        private void Seed()
        {
            Branch[] branchArray =
            {
                new Branch
                {
                    City = "Aarhus",
                    Halls = new List<Hall>
                    {
                        new Hall
                        {
                            Id = 1,
                            Seats = new List<Seat>
                            {
                                new Seat
                                {
                                    Row = 1,
                                    Column = 1,
                                    Id = 11,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 2,
                                    Id = 12,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 3,
                                    Id = 13,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 4,
                                    Id = 14,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 5,
                                    Id = 15,
                                },
                            }
                        },
                        new Hall
                        {
                            Id = 2,
                            Seats = new List<Seat>
                            {
                                new Seat
                                {
                                    Row = 1,
                                    Column = 1,
                                    Id = 11,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 2,
                                    Id = 12,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 3,
                                    Id = 13,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 4,
                                    Id = 14,
                                },
                                new Seat
                                {
                                    Row = 1,
                                    Column = 5,
                                    Id = 15,
                                },
                            }
                        }
                    }
                }
            };
            Branches = branchArray.ToList();
        }
    }
}