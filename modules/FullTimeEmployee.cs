using ClientEx.validations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEx.modules
{
    public class FullTimeEmployee : Employee
    {
        private double _globalPaument;

        public double GlobalPayment 
        {
            get => _globalPaument; 
            set => _globalPaument = ValidationsForEmployee.IsValidGlobalRate(value.ToString()) ? value : throw new ArgumentException("Non-legal global pay"); 
        }

        [JsonConstructor]
        public FullTimeEmployee(string name, string email, string phone, double globalPayment) : base(name, email, phone)
        {
            GlobalPayment = globalPayment;
        }

        public override string ToString()
        {
            return base.ToString() + $"Global payment: {GlobalPayment}";
        }
    }
}
