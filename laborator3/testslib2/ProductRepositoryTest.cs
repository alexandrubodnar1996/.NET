using System;
using Xunit;
using System.Collections.Generic;
using laborator3lib2;


namespace testslib2
{
    public class ProductRepositoryTest
    {
        ProductRepository productRepository = new ProductRepository();

        [Fact]
        public void GivenAListOfProductsWhenValidProductsCountIs8ThenShouldReturnTrue()
        {
            int expected = 8;
            Assert.Equal(expected, productRepository.RetrieveActiveProducts());
        }

        [Fact]
        public void GivenAListOfProductsWhenValidProductsCountIsNot5ThenShouldReturnFalse()
        {
            int expected = 5;
            Assert.NotEqual(expected, productRepository.RetrieveActiveProducts());
        }

        [Fact]
        public void GivenAListOfProductsWhenInvalidProductsCountIs2ThenShouldReturnTrue()
        {
            int expected = 2;
            Assert.Equal(expected, productRepository.RetrieveInactiveProducts());
        }

        [Fact]
        public void GivenAListOfProductsWhenInvalidProductsCountIsNot2ThenShouldReturnFalse()
        {
            int expected = 5;
            Assert.NotEqual(expected, productRepository.RetrieveInactiveProducts());
        }


        [Fact]
        public void GivenAListOfProductsWhenOrderedDescendingByPriceThenShouldReturnTrue()
        {
            List<Product> products = productRepository.getAllProducts();
            List<Product> pdsFromRepo = new List<Product>();

            IEnumerable<Product> productsFromRepo = productRepository.RetriveAllOrderByPriceDescending();

            foreach (var p in productsFromRepo)
            {
                pdsFromRepo.Add(p);
            }

            Assert.Equal(products, pdsFromRepo);
        }

        [Fact]
        public void GivenAListOfProductsWhenOrderedAscendingByPriceThenShouldReturnTrue()
        {
            List<Product> products = productRepository.getAllProducts();
            List<Product> pdsFromRepo = new List<Product>();

            IEnumerable<Product> productsFromRepo = productRepository.RetriveAllOrderByPriceAscending();

            foreach (var p in productsFromRepo)
            {
                pdsFromRepo.Add(p);
            }

            Assert.Equal(products, pdsFromRepo);
        }

        [Fact]
        public void GivenAListAndATestNameWhenProductNameContainsTestNameThenShouldReturnTrue()
        {
            List<Product> products = productRepository.getAllProducts();
            string testName = "Valid";

            List<Product> pdsFromRepo = new List<Product>();
            IEnumerable<Product> iProducts = productRepository.RetriveAllSubStringName(testName);


            foreach (var p in iProducts)
            {
                pdsFromRepo.Add(p);
            }

            products = products.FindAll(p => p.GetProductName().Contains(testName));
            Assert.Equal(pdsFromRepo, products);
        }

        [Fact]
        public void GivenAListAndAStartAndEndDateIfEqualThenShouldReturnTrue()
        {
            List<Product> products = productRepository.getAllProducts();

            DateTime tempSDate = DateTime.Now.AddDays(1);

            List<Product> pdsFromRepo = new List<Product>();
            IEnumerable<Product> iProducts = productRepository.RetriveAllByStartEndDate(tempSDate);


            foreach (var p in iProducts)
            {
                pdsFromRepo.Add(p);
            }

            products = products.FindAll(p => DateTime.Compare(p.GetStartDate(), tempSDate) < 0 && DateTime.Compare(tempSDate, p.GetEndDate()) < 0);
            Assert.Equal(pdsFromRepo, products);
        }
    }
}
