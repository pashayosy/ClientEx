using System.Text.RegularExpressions;

namespace ClientEx.validations
{
    public static class ValidationsForEmployee
    {
        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating email address
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidPhone(string phone)
        {
            // Regular expression pattern for validating phone number (North American format)
            string phonePattern = @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$";
            return !string.IsNullOrWhiteSpace(phone) && Regex.IsMatch(phone, phonePattern);
        }
        public static bool IsValidName(string name)
        {
            // Regular expression pattern for validating name (allows alphabets, spaces, hyphens, and apostrophes)
            string namePattern = @"^[a-zA-Z][a-zA-Z\s'-]*$";
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, namePattern);
        }

        public static bool IsValidHourlyRate(string hourlyRateStr)
        {
            // Validate if the input is a valid positive number
            return double.TryParse(hourlyRateStr, out double hourlyRate) && hourlyRate > 0;
        }

        public static bool IsValidGlobalRate(string globalRateStr)
        {
            // Validate if the input is a valid positive number
            return double.TryParse(globalRateStr, out double globalRate) && globalRate > 0;
        }
    }
}
