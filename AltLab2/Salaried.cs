using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    internal class Salaried : Employee
    {
        public double salary;
        public Salaried() { }
        public Salaried(string id, string name, string address, string phone, long sin, string date_of_birth, string department, double salary) 
        {
            //from Employee parent
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.date_of_birth = date_of_birth;
            this.department = department;
            //from Salaried child
            this.salary = salary;
        }
        //from Salaried child
        //getter
        public double getSalary()
        {
            return salary;
        }
        //setter
        public void setSalary(double new_salary)
        {
            salary = new_salary;
        }
        public double getPay()
        {
            return salary;
        }
    }
}
