﻿using ShoppingAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLLibrary
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProduct();
        Product DeleteProductById(int id);
        Product UpdateProduct(Product product);       
        bool UpdateProductPriceById(int id, double newPrice);
        bool UpdateProductQuantityById(int id, int newQuantity);

    }
}
