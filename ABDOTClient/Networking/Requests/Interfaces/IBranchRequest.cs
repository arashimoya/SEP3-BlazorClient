using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests.Interfaces
{
    public interface IBranchRequest
    {
        Task<bool> CreateBranch(Branch branch);

        Task<bool> EditBranch(Branch branch);

        Task<bool> DeleteBranch(Branch branch);

        Task<Branch> GetBranch(int branchId);

        Task<IList<Branch>> GetAllBranches();
    }
}