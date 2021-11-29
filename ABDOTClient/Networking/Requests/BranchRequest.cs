using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests.Interfaces;

namespace ABDOTClient.Networking.Requests
{
    public class BranchRequest : IBranchRequest
    {
        public Task<bool> CreateBranch(Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditBranch(Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBranch(Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public Task<Branch> GetBranch(int branchId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Branch>> GetAllBranches()
        {
            throw new System.NotImplementedException();
        }
    }
}