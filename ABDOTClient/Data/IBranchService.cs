using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IBranchService
    {
        Task<Branch> CreateBranch(Branch branch);

        Task<Branch> EditBranch(Branch branch);

        Task<bool> DeleteBranch(long branchId);

        Task<Branch> GetBranch(int BranchId);

        Task<IList<Branch>> GetAllBranches();
    }
    
}