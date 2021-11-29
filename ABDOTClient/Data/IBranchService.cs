using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IBranchService
    {
        Task<bool> CreateBranch(Branch branch);
     
        Task<bool> EditBranch(Branch branch);
     
        Task<bool> DeleteBranch(int branchId);
        
        Branch Get(int branchId);
        
        Hall GetHall(int hallId);

        IList<Branch> GetAll();
    }
}