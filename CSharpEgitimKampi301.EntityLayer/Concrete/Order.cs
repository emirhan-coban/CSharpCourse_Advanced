using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
