using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    internal class Employee
    {
        public string id;
        public string name;
        public string address;
        public string phone;
        public long sin;
        public string date_of_birth;
        public string department;

        //contructors
        public Employee() { }
        public Employee(string id, string name, string address, string phone, long sin, string date_of_birth, string department)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.date_of_birth = date_of_birth;
            this.department = department;
        }

        //getters
        public string getID()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getAddress()
        {
            return address;
        }
        public string getPhone()
        {
            return phone;
        }
        public long getSin()
        {
            return sin;
        }
        public string getDateOfBirth()
        {
            return date_of_birth;
        }
        public string getDepartment()
        {
            return department;
        }

        //setters
        public void setID(string new_id)
        {
            id = new_id;
        }
        public void setName(string new_name)
        {
            name = new_name;
        }
        public void setAddress(string new_address)
        {
            address = new_address;
        }
        public void setPhone(string new_phone)
        {
            phone = new_phone;
        }
        public void setSin(long new_sin)
        {
            sin = new_sin;
        }
        public void setDateOfBirth(string new_date_of_birth)
        {
            date_of_birth = new_date_of_birth;
        }
        public void setDepartment(string new_department)
        {
            department = new_department;
        }
        
        //to string
        public string ToString()
        {
            return "";
        }
    }
}
