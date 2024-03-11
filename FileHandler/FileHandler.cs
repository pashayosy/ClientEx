using ClientEx.modules;
using Newtonsoft.Json;

namespace ClientEx.FileHandler
{
    public static class FileHandler
    {
        private readonly static string fileName = Path.Combine(Directory.GetCurrentDirectory(), "EmployeeData.txt");

        public static void SaveToJson(EmployeeList employeeList)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                string json = JsonConvert.SerializeObject(employeeList, Formatting.Indented, settings);
                File.WriteAllText(fileName, json);
                Console.WriteLine("EmployeeList saved to JSON file successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error saving JSON file: {e.Message}");
            }
        }

        public static EmployeeList LoadFromJson()
        {
            EmployeeList employeeList = null;
            try
            {
                if (File.Exists(fileName))
                {
                    string json = File.ReadAllText(fileName);
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    employeeList = JsonConvert.DeserializeObject<EmployeeList>(json, settings);
                    Console.WriteLine("EmployeeList loaded from JSON file successfully.");
                }
                else
                {
                    Console.WriteLine("JSON file not found.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error loading JSON file: {e.Message}");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error deserializing JSON file: {e.Message}");
            }
            return employeeList;
        }
    }

}
