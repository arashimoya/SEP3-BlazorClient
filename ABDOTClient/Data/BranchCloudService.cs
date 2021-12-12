using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class BranchCloudService : IBranchService
    {
        
        public async Task<Branch> CreateBranch(Branch branch)
        {
            return await ClientFactory.GetClient().CreateBranch(branch);
        }

        public async Task<Branch> EditBranch(Branch branch)
        {
            return await ClientFactory.GetClient().EditBranch(branch);
        }


        public async Task<bool> DeleteBranch(long branchId)
        {
            return await ClientFactory.GetClient().DeleteBranch(branchId);
        }

        public async Task<Branch> GetBranch(int BranchId)
        {
            return await ClientFactory.GetClient().GetBranch(BranchId);
        }

        public async Task<IList<Branch>> GetAllBranches()
        {
            return await ClientFactory.GetClient().GetAllBranches();
        }
    }
}