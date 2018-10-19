using System;
using System.Collections.Generic;
using laborator3;

namespace tests
{
    public class ProductFactory
    {
        List<Product> products;
        IEnumerable<Product> iProducts;
        public ProductFactory()
        {
            products = new List<Product>();
            products.Add(new Product(2));
            products.Add(new Product(3));
            products.Add(new Product(1));
            products.Add(new Product(5));
            products.Add(new Product(-2));
            products.Add(new Product(-10));
            products.Add(new Product(20));
            products.Add(new Product(15));
            products.Add(new Product(25));
            products.Add(new Product(4));
        }

        public List<Product> getAllProducts()
        {
            return this.products;
        }
    }
}
