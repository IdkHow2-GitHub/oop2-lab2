using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    internal class PartTime : Employee
    {
        public double rate;
        public double hours;
        public PartTime() { }
        public PartTime(string id, string name, string address, string phone, long sin, string date_of_birth, string department, double rate, double hours)
        {
            //from Employee parent
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.date_of_birth = date_of_birth;
            this.department = department;
            //from PartTime child
            this.rate = rate;
            this.hours = hours;
        }
        //from PartTime child
        //getter
        public double getRate()
        {
            return rate;
        }
        public double getHours()
        {
            return hours;
        }
        //setter
        public void setRate(double new_rate)
        {
            rate = new_rate;
        }
        public void setHours(double new_hours)
        {
            hours = new_hours;
        }
        public double getPay()
        {
            double pay;
            pay = hours * rate;

            return pay;
        }
    }
}
