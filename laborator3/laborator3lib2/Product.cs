using System;

namespace laborator3lib2
{
    public class Product
    {
        private int Id;
        private string ProductName;
        private string ProductDescription;
        private DateTime StartDate;
        private DateTime EndDate;
        private int Price;


        public Product(int numberOfValidDays)
        {
            if (numberOfValidDays > 0)
            {
                this.ProductName = "Valid product";
            }
            else
            {
                this.ProductName = "Not a valid product";
            }
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now.AddDays(numberOfValidDays);
        }

        public DateTime GetStartDate()
        {
            return this.StartDate;
        }

        public DateTime GetEndDate()
        {
            return this.EndDate;
        }

        public string GetProductName()
        {
            return this.ProductName;
        }

        public bool isValid()
        {
            return DateTime.Compare(this.StartDate, this.EndDate) < 0;
        }

        public int GetPrice()
        {
            return this.Price;
        }
    }
}
