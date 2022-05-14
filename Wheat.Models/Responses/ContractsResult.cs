using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheat.Models.Entities;

namespace Wheat.Models.Responses
{
    public class ContractsResult
    {
        public IEnumerable<Dictionary<string, IEnumerable<Dictionary<int, SellContract>>>> MySellContracts { get; set; }
        public IEnumerable<Dictionary<string, IEnumerable<Dictionary<int, SellContract>>>> MyAcquiredContracts { get; set; }
    }
}
