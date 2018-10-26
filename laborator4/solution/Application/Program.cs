using System;
using classes;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext()) 
            {
                var customerRepo = new CustomerRepository(db);
                var employeeRepo = new EmployeeRepository(db);

                //int id, string fName, string lName, DateTime sDate, DateTime? eDate
                //string name, string address, string phoneNumber, string email

                Employee e = new Employee(1, "Alex", "Bodnar", DateTime.Now, DateTime.Now.AddDays(2));
                Customer c = new Customer("customerName", "Romania, Iasi", "0722453775", "name@gmail.com");

                customerRepo.Create(c);
                employeeRepo.Create(e);

                Console.WriteLine(customerRepo.GetById(1).Name);
            }
        }
    }
}
