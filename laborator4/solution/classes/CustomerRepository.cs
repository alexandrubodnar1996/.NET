using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace classes
{
    public class CustomerRepository : IRepository<Customer>
    {
        private DbContext context;

        public CustomerRepository(DbContext tempContext)
        {
            this.context = tempContext;
        }

        public void Create(Customer customer){
            context.Set<Customer>().Add(customer);
            context.SaveChanges();
        }

        public void Update(Customer customer){
            context.Set<Customer>().Update(customer);
            context.SaveChanges();
        }

        public void Delete(Customer customer){
            context.Set<Customer>().Remove(customer);
            context.SaveChanges();
        }

        public Customer GetById(int customerId){
            return context.Set<Customer>().Where(c => c.Id == customerId).FirstOrDefault();
        }

        public List<Customer> GetAll(){
            return context.Set<Customer>().ToList();
        }

        public Customer GetCustomerByEmail(string email){
            return context.Set<Customer>().Where(c => c.Email.Equals(email)).FirstOrDefault();
        } 

    }
}
