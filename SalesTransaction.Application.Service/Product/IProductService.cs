using System;
using System.Collections.Generic;
using System.Text;
using SalesTransaction.Application.Model.Product;

namespace SalesTransaction.Application.Service.Product
{
    public interface IProductService
    {
        dynamic GetAllProductDetail();
        bool AddProduct(MvProduct product);
    }
}
