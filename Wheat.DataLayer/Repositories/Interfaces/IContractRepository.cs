using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheat.Models.Responses;

namespace Wheat.DataLayer.Repositories.Interfaces
{
    public interface IContractRepository
    {
        Task<ContractsResult> GetMyContractsAsync(string userId);
        Task CreateContractsAsync(string userId, int count, decimal price);
    }
}
