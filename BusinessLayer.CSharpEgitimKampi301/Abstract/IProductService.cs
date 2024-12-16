using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_CSharpEgitimKampi301.Concrete;

namespace BusinessLayer.CSharpEgitimKampi301.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<object > TGetProductsWithCategory();
    }
}
