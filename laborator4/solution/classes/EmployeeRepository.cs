using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace classes
{
    public class EmployeeRepository
    {
        private DbContext context;

        public EmployeeRepository(DbContext tempContext)
        {
            this.context = tempContext;
        }

        public void Create(Employee employee)
        {
            context.Set<Employee>().Add(employee);
            context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            context.Set<Employee>().Update(employee);
            context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            context.Set<Employee>().Remove(employee);
            context.SaveChanges();
        }

        public Employee GetById(int employeeId)
        {
            return context.Set<Employee>().Where(c => c.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return context.Set<Employee>().ToList();
        }

    }
}
