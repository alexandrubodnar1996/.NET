using System;
using System.Collections.Generic;
using System.Linq;

namespace laborator3lib2
{
    public class ProductRepository
    {
        List<Product> products;
        IEnumerable<Product> iProducts;

        public ProductRepository()
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

        public int RetrieveActiveProducts()
        {

            IEnumerable<Product> prods = products.Where(p => DateTime.Compare(p.GetStartDate(), p.GetEndDate()) < 0);


            int numberOfActiveProds = prods.Count();
            return numberOfActiveProds;
        }

        public int RetrieveInactiveProducts()
        {

            IEnumerable<Product> prods = products.Where(p => DateTime.Compare(p.GetStartDate(), p.GetEndDate()) > 0);
            int numberOfActiveProds = prods.Count();
            return numberOfActiveProds;
        }

        public IEnumerable<Product> RetriveAllOrderByPriceDescending()
        {

            IEnumerable<Product> prods = products.OrderByDescending(p => p.GetPrice());
            return prods;
        }

        public IEnumerable<Product> RetriveAllOrderByPriceAscending()
        {

            IEnumerable<Product> prods = products.OrderBy(p => p.GetPrice());

            return prods;
        }

        public IEnumerable<Product> RetriveAllSubStringName(string tempName)
        {

            IEnumerable<Product> prods = products.Where(p => p.GetProductName().Contains(tempName));

            return prods;
        }

        public IEnumerable<Product> RetriveAllByStartEndDate(DateTime tempDay)
        {

            IEnumerable<Product> prods = products.Where(p => DateTime.Compare(p.GetStartDate(), tempDay) < 0 &&
                                                        DateTime.Compare(tempDay, p.GetEndDate()) < 0);

            return prods;
        }
    }
}
