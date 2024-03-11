using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEx.modules
{
    public class EmployeeList : IEnumerable<Employee>
    {
        private List<Employee> employees;

        public Employee this[int index]
        {
            get 
            { 
                if (employees.Count > index && index >= 0) 
                {
                    return employees[index];
                }
                throw new IndexOutOfRangeException("You try to GET employee with index that out of bound");
            }
            set 
            {
                if (employees.Count > index && index >= 0)
                {
                    employees[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("You try to SET employee with index that out of bound");
                }
                
            }
        }

        /// <summary>
        /// Init the Employee List
        /// </summary>
        public EmployeeList()
        {
            employees = new List<Employee>();
        }

        public EmployeeList(EmployeeList employees)
        {
            this.employees = new List<Employee>(employees);
        }

        [JsonConstructor]
        public EmployeeList(List<Employee> employees)
        {
            this.employees = new List<Employee>(employees);
        }

        public void Add(Employee employee) 
        {
            employees.Add(employee);
        }

        /// <summary>
        /// Remove Employee by the index where he at
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            employees.RemoveAt(index);
        }

        /// <summary>
        /// Remove the given employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Remove(Employee employee)
        {
            return employees.Remove(employee);
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach(Employee employee in employees)
            {
                yield return employee;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Sort()
        {
            employees.Sort();
        }

        public void Sort(IComparer<Employee> comparer)
        {
            employees.Sort(0, employees.Count, comparer);
        }

        public override string ToString()
        {
            StringBuilder emloyeesData = new StringBuilder();

            foreach(Employee employee in employees)
            {
                emloyeesData.AppendLine(employee.ToString() + "\n");
            }

            return emloyeesData.ToString();
        }
    }
}
