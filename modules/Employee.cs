using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientEx.validations;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientEx.modules
{
    public abstract class Employee : IComparable<Employee>
    {
        private string _name;
        private string _email;
        private string _phone;
        private readonly Guid _id;

        public string Name 
        {
            get => _name;
            set => _name = ValidationsForEmployee.IsValidName(value) ? value : throw new ArgumentException("Non-legal name");
        }
        public string Email
        {
            get => _email;
            set => _email = ValidationsForEmployee.IsValidEmail(value) ? value : throw new ArgumentException("Non-legal email");
        }
        public string Phone
        {
            get => _phone;
            set => _phone = ValidationsForEmployee.IsValidPhone(value) ? value : throw new ArgumentException("Non-legal phone number");
        }
        public Guid Id
        {
            get => _id;
        }

        public static int _idCounter = 0;

        public Employee(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;

            _id = Guid.NewGuid();
        }

        public override string ToString()
        {
            StringBuilder data = new StringBuilder();

            data.Append($"ID: {_id} || ");
            data.Append($"Name: {Name} || ");
            data.Append($"Email: {Email}  || ");
            data.Append($"Phone: {Phone} || ");

            return data.ToString();
        }

        public int CompareTo(Employee? other)
        {
            if ( other == null )
                throw new ArgumentNullException("You try to compare the employee to null refernce one");

            return Name.CompareTo( other.Name );
        }
    }
}
