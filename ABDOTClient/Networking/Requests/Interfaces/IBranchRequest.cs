using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests.Interfaces
{
    public interface IBranchRequest
    {
        Task<Branch> CreateBranch(Branch branch);

        Task<Branch> EditBranch(Branch branch);

        Task<bool> DeleteBranch(long branch);

        Task<Branch> GetBranch(int branchId);

        Task<IList<Branch>> GetAllBranches();
    }
}