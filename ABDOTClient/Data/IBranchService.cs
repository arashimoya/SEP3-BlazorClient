using System.Collections.Generic;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IBranchService
    {
        Branch Get(int branchId);
        Hall GetHall(int hallId);

        IList<Branch> GetAll();
    }
}