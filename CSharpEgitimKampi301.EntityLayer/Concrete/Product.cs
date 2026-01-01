using System.Collections.Generic;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public List<Order> Orders { get; set; }

        //[NotMapped]
        //public string CategoryName { get; set; }
    }
}
