using System;

namespace classes
{
    public class Employee
    {
        public int Id { private set; get; }

        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public DateTime StartDate { private set; get; }
        public DateTime? EndDate { private set; get; }
        public bool IsActive { private set; get; }
        public double Salary { private set; get; }

        public Employee(int id, string fName, string lName, DateTime sDate, DateTime? eDate)
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.StartDate = DateTime.Now;
            this.EndDate = eDate;
        }

        public Employee(){

        }

    }


}
