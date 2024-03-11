using ClientEx.validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientEx.modules
{
    public class PartTimeEmployee : Employee
    {
        private double _paymentPerHour;

        public double PaymentPerHour 
        {
            get => _paymentPerHour;
            set => _paymentPerHour = ValidationsForEmployee.IsValidHourlyRate(value.ToString()) ? value : throw new ArgumentException("Non-legal hourly pay");
        }

        [JsonConstructor]
        public PartTimeEmployee(string name, string email, string phone, double paymentPerHour) : base(name, email, phone)
        {
            PaymentPerHour = paymentPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + $"Payment per hour: {PaymentPerHour}";
        }
    }
}
