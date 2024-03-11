using ClientEx.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEx.EmployeeGenerator
{
    public static class Employergenerator
    {

        private static Random random = new Random();

        public static EmployeeList GenerateLegalData()
        {
            EmployeeList employees = new EmployeeList();

            for (int i = 0; i < 5; i++)
            {
                string name = GenerateName();
                string email = GenerateEmail(name);
                string phone = GeneratePhone();
                double salary = GenerateSalary();
                employees.Add(new FullTimeEmployee(name, email, phone, salary));
            }

            for (int i = 0; i < 5; i++)
            {
                string name = GenerateName();
                string email = GenerateEmail(name);
                string phone = GeneratePhone();
                double hourlyRate = GenerateHourlyRate();
                employees.Add(new PartTimeEmployee(name, email, phone, hourlyRate));
            }

            return employees;
        }

        private static string GenerateName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Chris", "Emma", "Andrew", "Olivia" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson" };

            string firstName = firstNames[random.Next(firstNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];

            return $"{firstName} {lastName}";
        }

        private static string GenerateEmail(string name)
        {
            string[] domains = { "gmail.com", "yahoo.com", "outlook.com", "company.com", "example.com" };
            string domain = domains[random.Next(domains.Length)];
            string prefix = name.Replace(" ", "").ToLower();
            return $"{prefix}@{domain}";
        }

        private static string GeneratePhone()
        {
            return $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}";
        }

        private static double GenerateSalary()
        {
            return Math.Round(random.NextDouble() * 50000 + 30000, 2);
        }

        private static double GenerateHourlyRate()
        {
            return Math.Round(random.NextDouble() * 50 + 10, 2);
        }
    }
}
