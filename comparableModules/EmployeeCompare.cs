using ClientEx.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEx.comparableModules
{
    public enum ComparerMethod
    {
        ById,
        BuName
    }

    public class EmployeeCompare : Comparer<Employee>
    {
        public ComparerMethod Method { get;}

        public EmployeeCompare(ComparerMethod method)
        {
            Method = method;
        }

        public override int Compare(Employee? x, Employee? y)
        {
            if (x != null && y != null)
            {
                switch(Method) 
                {
                    case ComparerMethod.ById:
                        return CompareById(x, y);
                    case ComparerMethod.BuName:
                        return CompareByName(x, y);
                    default: 
                        return x.CompareTo(y);
                }
            }
            throw new ArgumentNullException("You try to compare object that one(ore more that one) of theam is null");
        }

        private int CompareById(Employee x, Employee y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("You try to compare object that one(ore more that one) of theam is null");

            return x.Id.CompareTo(y.Id);
        }

        private int CompareByName(Employee x, Employee y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("You try to compare object that one(ore more that one) of theam is null");

            return x.Name.CompareTo(y.Name);
        }
    }
}
