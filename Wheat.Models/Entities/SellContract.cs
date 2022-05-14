using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheat.Models.Entities
{
    public class SellContract
    {
        public string Id { get; set; }
        public string SellerId { get; set; }
        public string? PurchaserId { get; set; }
        public decimal Price { get; set; }
    }
}
