using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Object> GetProductsWithCategory();
    }
}
