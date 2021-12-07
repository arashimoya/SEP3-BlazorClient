using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class BranchCloudService : IBranchService
    {
        
        public Task<bool> CreateBranch(Branch branch)
        {
            return ClientFactory.GetClient().CreateBranch(branch);
        }

        public Task<bool> EditBranch(Branch branch)
        {
            return ClientFactory.GetClient().EditBranch(branch);
        }

        public Task<bool> DeleteBranch(Branch branch)
        {
            return ClientFactory.GetClient().DeleteBranch(branch);
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