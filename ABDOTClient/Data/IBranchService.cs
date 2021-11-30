using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IBranchService
    {
        Task<bool> CreateBranch(Branch branch);

        Task<bool> EditBranch(Branch branch);

        Task<bool> DeleteBranch(Branch branch);

        Task<Branch> GetBranch(int BranchId);

        Task<IList<Branch>> GetAllBranches();
    }
    
}