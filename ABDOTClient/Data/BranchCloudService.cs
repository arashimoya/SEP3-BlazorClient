using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class BranchCloudService : IBranchService
    {
        
        public Task<Branch> CreateBranch(Branch branch)
        {
            return ClientFactory.GetClient().CreateBranch(branch);
        }

        public Task<Branch> EditBranch(Branch branch)
        {
            return ClientFactory.GetClient().EditBranch(branch);
        }


        public async Task<bool> DeleteBranch(long branchId)
        {
            return await ClientFactory.GetClient().DeleteBranch(branchId);
        }

        public Task<Branch> GetBranch(int BranchId)
        {
            return ClientFactory.GetClient().GetBranch(BranchId);
        }

        public Task<IList<Branch>> GetAllBranches()
        {
            return ClientFactory.GetClient().GetAllBranches();
        }
    }
}