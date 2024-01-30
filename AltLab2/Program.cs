using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AltLab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>> Lab 2 (Retry)");
            Console.WriteLine("/////////////////");

            string[] employees = File.ReadAllLines("C:\\Users\\bsimm\\Desktop\\OOP2 VS\\AltLab2\\res\\employees.txt");
            string[] employee_data = { };
            double total_employees = 0;

            double highest_pay = 0;

            double salary_percent;
            double wage_percent;
            double part_time_percent;

            Salaried salaried = new Salaried();
            Wages wages = new Wages();
            PartTime part_time = new PartTime();

            ArrayList all_employees = new ArrayList();
            ArrayList salary_employees = new ArrayList();
            ArrayList wage_employees = new ArrayList();
            ArrayList part_time_employees = new ArrayList();

            void createEmployees()
            {
                foreach (string employee in employees)
                {
                    Console.WriteLine(employee);
                    //splitting into words
                    employee_data = employee.Split(':');
                }
                //only names and their employee type
                Console.WriteLine("\n\n--The Employees--");
                foreach (string employee in employees)
                {
                    //splitting into words
                    employee_data = employee.Split(':');
                    //create the employee
                    if (int.Parse(employee_data[0].Substring(0, 1)) <= 4)
                    {
                        salaried = new Salaried(employee_data[0], employee_data[1], employee_data[2], employee_data[3], long.Parse(employee_data[4]), employee_data[5], employee_data[6], double.Parse(employee_data[7]));
                        Console.WriteLine(salaried.getName() + " is on a Salary");
                        all_employees.Add(salaried);
                        salary_employees.Add(salaried);
                        total_employees++;
                    }
                    else if (int.Parse(employee_data[0].Substring(0, 1)) >= 5 && int.Parse(employee_data[0].Substring(0, 1)) <= 7)
                    {
                        wages = new Wages(employee_data[0], employee_data[1], employee_data[2], employee_data[3], long.Parse(employee_data[4]), employee_data[5], employee_data[6], double.Parse(employee_data[7]), double.Parse(employee_data[8]));
                        Console.WriteLine(wages.getName() + " is paid via Wage");
                        all_employees.Add(wages);
                        wage_employees.Add(wages);
                        total_employees++;
                    }
                    else
                    {
                        part_time = new PartTime(employee_data[0], employee_data[1], employee_data[2], employee_data[3], long.Parse(employee_data[4]), employee_data[5], employee_data[6], double.Parse(employee_data[7]), double.Parse(employee_data[7]));
                        Console.WriteLine(part_time.getName() + " is paid as Part-Timer");
                        all_employees.Add(part_time);
                        part_time_employees.Add(part_time);
                        total_employees++;
                    }
                }
            }
            //the entire employee's data
            
            
            double calculateAveragePay()
            {
                double sum = 0;
                double average = 0;
                foreach (Salaried emp in salary_employees)
                {
                    sum += emp.getPay();
                }
                foreach (Wages emp in wage_employees)
                {
                    sum += emp.getPay();
                }
                foreach (PartTime emp in part_time_employees)
                {
                    sum += emp.getPay();
                }
                /*for (int i = 0; i < salary_employees.Count; i++)
                {
                    double salary_pay = double.Parse(employee_data[7]);
                    sum += salaried.getSalary();
                }
                for (int i = 0; i < wage_employees.Count; i++)
                {
                    sum += wages.getPay();
                }
                for (int i = 0; i < part_time_employees.Count; i++)
                {
                    sum += part_time.getPay();
                }*/
                average = sum / all_employees.Count;
                Console.WriteLine("\n--Average Weekly Pay--");
                Console.WriteLine(Math.Round(average,2));
                return average;
            }
            string calculateHighestPayWage()
            {
                string highest_pay_wage;
                string text = "";

                for (int i = 0; i < wage_employees.Count; i++)
                {
                    if (wages.getPay() > highest_pay)
                    highest_pay = wages.getPay();
                    highest_pay_wage = wages.getName();
                    text = $"\nThe highest paid Wage employee is {highest_pay_wage} with ${highest_pay}";
                }
                Console.WriteLine(text);
                return text;
            }
            string calculateLowestSalary()
            {
                string highest_salary_employee;
                double hightest_salary = 0;
                string text = "";

                string lowestPayEmp = "";

                // TODO: Implement the necessary code to get the employee with lowest payment
                double lowestPay = Double.MaxValue;
                for (int i = 0; i < salary_employees.Count; i++)
                {
                    if (salaried.getSalary() < lowestPay)
                    {
                        lowestPay = salaried.getSalary();
                        lowestPayEmp = salaried.getName();
                        text = $"\nThe lowest paid Salary employee is {lowestPayEmp} with ${lowestPay}";
                    }
                }
                // ...........................................
                Console.WriteLine(text);
                return lowestPayEmp;

                //first fine highest salary
                /*for (int i = 0; i < wage_employees.Count; i++)
                {
                    if (salaried.getSalary() > hightest_salary)
                        hightest_salary = salaried.getSalary();
                        highest_salary_employee = salaried.getName();
                }
                //to then compare and find lowest salary
                string lowest_salary_employee;
                double lowest_salary = hightest_salary - 1;

                for (int i = 0; i < salary_employees.Count; i++)
                {
                    if (lowest_salary < hightest_salary)
                        lowest_salary = salaried.getSalary();
                        lowest_salary_employee = salaried.getName();
                        text = $"\nThe lowest paid Salary employee is {lowest_salary_employee} with ${lowest_salary}";
                }
                Console.WriteLine(text);
                return text;*/
                /*double lowest_pay = 999999999;
                string lowest_pay_salary;
                string text = "";

                for (int i = 0; i < salary_employees.Count; i++)
                {
                    if (salaried.getSalary() < lowest_pay)
                        lowest_pay = salaried.getSalary();
                    lowest_pay_salary = salaried.getName();
                    text = $"\nThe lowest paid Salary employee is {lowest_pay_salary} with ${lowest_pay}";
                }
                Console.WriteLine(text);
                return text;*/
            }
            void percentageOfEmployees()
            {
                salary_percent = (salary_employees.Count / total_employees) * 100;
                wage_percent = (wage_employees.Count / total_employees) * 100;
                part_time_percent = (part_time_employees.Count / total_employees) * 100;

                Console.WriteLine("\n--Percentage of Employees--");
                Console.WriteLine($"Salary: {Math.Round(salary_percent, 2)}%");
                Console.WriteLine($"Wage: {Math.Round(wage_percent, 2)}%");
                Console.WriteLine($"Part-Time: {Math.Round(part_time_percent, 2)}%");
            }
            
            createEmployees();//4a              v
            calculateAveragePay();//4b          v
            calculateHighestPayWage();//4c      v
            calculateLowestSalary();//4d        v
            percentageOfEmployees();//4e        v
        }
    }
}
