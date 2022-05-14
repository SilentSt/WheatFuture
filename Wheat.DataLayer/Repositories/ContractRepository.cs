using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wheat.DataLayer.DataBase;

using Wheat.DataLayer.Repositories.Interfaces;
using Wheat.Models.Entities;
using Wheat.Models.Responses;

namespace Wheat.DataLayer.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly WheatDbContext _context;
        public ContractRepository(WheatDbContext context)
        {
            _context=context;
        }
        public async Task<ContractsResult> GetMyContractsAsync(string userId)
        {
            await _context.Users.LoadAsync();
            await _context.SellContracts.LoadAsync();
            var user = await _context.Users.Include(nameof(WIdentityUser.SelfSellContracts)).Include(nameof(WIdentityUser.AcquiredSellContract)).FirstOrDefaultAsync(x=>x.Id==userId);
            if (user == null) throw new Exception("404");
            var sell = user.SelfSellContracts.GroupBy(x => x.PurchaserId??"").Select(x => new Dictionary<string,IEnumerable<Dictionary<int,SellContract>>>
            {
                {x.Key, x.GroupBy(f => f.Price).Select(g=>new Dictionary<int,SellContract>(){{user.SelfSellContracts.Count(y=>y.Price==g.Key && x.Key==(y.PurchaserId ?? "")),g.First()}})}
            });
            var buy = user.AcquiredSellContract.GroupBy(x => x.SellerId).Select(x => new Dictionary<string, IEnumerable<Dictionary<int, SellContract>>>
            {
                {x.Key, x.GroupBy(f => f.Price).Select(g=>new Dictionary<int,SellContract>(){{ user.AcquiredSellContract.Count(y => y.Price == g.Key && y.SellerId == x.Key), g.First()}})}
            });

            return new ContractsResult{MySellContracts = sell, MyAcquiredContracts = buy};
        }

        public async Task CreateContractsAsync(string userId, int count, decimal price)
        {
            for(int i=0;i< count; i++)
            {
                var x= new SellContract {SellerId = userId, Price = price, Id = Guid.NewGuid().ToString()};
                await _context.SellContracts.AddAsync(x);
            }
            await _context.SaveChangesAsync();
        }
    }
}
