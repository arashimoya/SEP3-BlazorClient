using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
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

        public Task<bool> CreateBranch(Branch branch)
        {
            return ClientFactory.GetClient().CreateBranch(branch);
        }

        public Task<bool> EditBranch(Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBranch(int branchId)
        {
            throw new System.NotImplementedException();
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
            
        }
    }
}