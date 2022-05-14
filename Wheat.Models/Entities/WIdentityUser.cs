
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Wheat.Models.Entities
{
    public class WIdentityUser : IdentityUser
    {
        public string Code { get; set; }

        [ForeignKey(nameof(SellContract.SellerId))]
        public virtual ICollection<SellContract> SelfSellContracts { get; set; }
        [ForeignKey(nameof(SellContract.PurchaserId))]
        public virtual ICollection<SellContract> AcquiredSellContract { get; set; }
    }
}
