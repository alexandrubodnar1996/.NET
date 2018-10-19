using System;
using System.Collections.Generic;
using System.Linq;

namespace laborator3
{
    public class ProductRepository
    {
        List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
            products.Add(new Product(2));
            products.Add(new Product(3));
            products.Add(new Product(1));
            products.Add(new Product(5));
            products.Add(new Product(-2));
            products.Add(new Product(-10));
        }

        public List<Product> getAllProducts(){
            return this.products;
        }

        public int RetrieveActiveProducts(){

            IEnumerable<Product> prods = from prod in products
                                  where DateTime.Compare(prod.GetStartDate(), prod.GetEndDate()) < 0
                                  select prod;
            int numberOfActiveProds = prods.Count();
            return numberOfActiveProds;
        }

        public int RetrieveInactiveProducts()
        {

            IEnumerable<Product> prods = from prod in products
                                         where DateTime.Compare(prod.GetStartDate(), prod.GetEndDate()) > 0
                                         select prod;
            int numberOfActiveProds = prods.Count();
            return numberOfActiveProds;
        }

        public IEnumerable<Product> RetriveAllOrderByPriceDescending()
        {

            IEnumerable<Product> prods = from prod in products
                                         
                                         orderby prod.GetPrice() descending
                                                       select prod;

            return prods;
        }

        public IEnumerable<Product> RetriveAllOrderByPriceAscending()
        {

            IEnumerable<Product> prods = from prod in products

                                         orderby prod.GetPrice() ascending
                                         select prod;

            return prods;
        }

        public IEnumerable<Product> RetriveAllSubStringName(string tempName){

            IEnumerable<Product> prods = from prod in products
                    where prod.GetProductName().Contains(tempName)
                                         select prod;

            return prods;
        }

        public IEnumerable<Product> RetriveAllByStartEndDate(DateTime tempDay)
        {

            IEnumerable<Product> prods = from prod in products
                    where DateTime.Compare(prod.GetStartDate(), tempDay) < 0
                                  && DateTime.Compare(tempDay, prod.GetEndDate()) < 0  
                                         select prod;

            return prods;
        }
    }
}
