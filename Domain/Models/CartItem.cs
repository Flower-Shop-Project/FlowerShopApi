using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CartItem : BaseEntity
    {
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}