using ClientEx.comparableModules;
using ClientEx.EmployeeGenerator;
using ClientEx.modules;
using ClientEx.EmployeeGenerator;

namespace ClientEx.Ui
{
    public static class Ui
    {

        #region Ui needed think
        // ANSI escape codes for colors
        private const string Reset = "\x1b[0m";
        private const string Bright = "\x1b[1m";
        private const string Cyan = "\x1b[36m";
        private const string Green = "\x1b[32m";
        private const string Yellow = "\x1b[33m";
        private const string Blue = "\x1b[34m";
        private const string Red = "\x1b[31m";


        private enum MenuOption
        {
            PrintAllEmployees,
            SortByName,
            SortById,
            AddFullTimeEmployee, // Added option to add FullTimeEmployee
            AddPartTimeEmployee, // Added option to add PartTimeEmployee
            Exit
        }
        #endregion

        /// <summary>
        /// Start the ui menu
        /// </summary>
        public static void StartUi()
        {
            EmployeeList employeeList;
            employeeList = FileHandler.FileHandler.LoadFromJson();

            if (employeeList == null ) 
            {
                employeeList = EmployeeGenerator.Employergenerator.GenerateLegalData();
                FileHandler.FileHandler.SaveToJson(employeeList);
            }
            
            MenuOption selectedOption = MenuOption.PrintAllEmployees;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                PrintMenu(selectedOption);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (MenuOption)(((int)selectedOption - 1 + 6) % 6); // Adjusted for 6 options
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (MenuOption)(((int)selectedOption + 1) % 6); // Adjusted for 6 options
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        HandleMenuSelection(selectedOption, employeeList);
                        if (selectedOption == MenuOption.Exit)
                            exit = true;
                        break;
                }
            }
        }

        #region EmployeeList add and print
        /// <summary>
        /// Print the Employee list in a beatifull way
        /// </summary>
        /// <param name="employees"></param>
        private static void PrintEmployeeList(EmployeeList employees)
        {
            Console.WriteLine($"┌───────────────────────────────────────────┬───────────────────┬──────────────────────────────────────┬────────────────┐");
            Console.WriteLine($"│ {"Id",-40}   {"Name",-19}   {"Email",-35}   {"Phone",-15}  ");
            Console.WriteLine($"├───────────────────────────────────────────┼───────────────────┼──────────────────────────────────────┼────────────────┤");

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"│ {Cyan}{employee.Id,-40}{Reset}   {Green}{employee.Name,-19}{Reset}   {Blue}{employee.Email,-35}{Reset}   {Yellow}{employee.Phone,-15}{Reset}  ");
                Console.WriteLine($"├───────────────────────────────────────────┼───────────────────┼──────────────────────────────────────┼────────────────┤");
            }

            Console.WriteLine($"└───────────────────────────────────────────┴───────────────────┴──────────────────────────────────────┴────────────────┘");

        }
        #endregion

        #region Menu
        /// <summary>
        /// Show the menu with the chooses
        /// </summary>
        /// <param name="selectedOption"></param>
        private static void PrintMenu(MenuOption selectedOption)
        {
            Console.WriteLine($"{Bright}Employee Management System{Reset}");
            Console.WriteLine($"{Cyan}-------------------------{Reset}");
            Console.WriteLine(selectedOption == MenuOption.PrintAllEmployees ? $"{Yellow}{Bright}-> {Reset}Print all employees{Reset}" : "Print all employees");
            Console.WriteLine(selectedOption == MenuOption.SortByName ? $"{Yellow}{Bright}-> {Reset}Sort by name and print all employees{Reset}" : "Sort by name and print all employees");
            Console.WriteLine(selectedOption == MenuOption.SortById ? $"{Yellow}{Bright}-> {Reset}Sort by ID and print all employees{Reset}" : "Sort by ID and print all employees");
            Console.WriteLine(selectedOption == MenuOption.AddFullTimeEmployee ? $"{Yellow}{Bright}-> {Reset}Add FullTimeEmployee{Reset}" : "Add FullTimeEmployee");
            Console.WriteLine(selectedOption == MenuOption.AddPartTimeEmployee ? $"{Yellow}{Bright}-> {Reset}Add PartTimeEmployee{Reset}" : "Add PartTimeEmployee");
            Console.WriteLine(selectedOption == MenuOption.Exit ? $"{Yellow}{Bright}-> {Reset}Exit{Reset}" : "Exit");

        }

        /// <summary>
        /// Handle all the menu interactions
        /// </summary>
        /// <param name="selectedOption"></param>
        /// <param name="employeeList"></param>
        private static void HandleMenuSelection(MenuOption selectedOption, EmployeeList employeeList)
        {
            switch (selectedOption)
            {
                case MenuOption.PrintAllEmployees:
                    Console.WriteLine($"{Bright}Printing all employees:{Reset}");
                    PrintEmployeeList(employeeList);
                    break;
                case MenuOption.SortByName:
                    Console.WriteLine($"{Bright}Sorting by name and printing all employees:{Reset}");
                    employeeList.Sort(new EmployeeCompare(ComparerMethod.BuName));
                    PrintEmployeeList(employeeList);
                    break;
                case MenuOption.SortById:
                    Console.WriteLine($"{Bright}Sorting by ID and printing all employees:{Reset}");
                    employeeList.Sort(new EmployeeCompare(ComparerMethod.ById));
                    PrintEmployeeList(employeeList);
                    break;
                case MenuOption.AddFullTimeEmployee: // Added case for adding FullTimeEmployee
                    AddFullTimeEmployee(employeeList);
                    break;
                case MenuOption.AddPartTimeEmployee: // Added case for adding PartTimeEmployee
                    AddPartTimeEmployee(employeeList);
                    break;
                case MenuOption.Exit:
                    Console.WriteLine($"{Red}Exiting...{Reset}");
                    break;
            }

            if (selectedOption != MenuOption.Exit)
            {
                Console.WriteLine($"\n{Yellow}Press any key to continue...{Reset}");
                Console.ReadKey();
            }
        }
        #endregion


        #region Employee add 

        private static void AddFullTimeEmployee(EmployeeList employeeList)
        {
            Console.WriteLine($"{Bright}Adding FullTimeEmployee:{Reset}");
            Console.Write($"{Green}Enter employee name: {Reset}");
            string name = Console.ReadLine();
            Console.Write($"{Green}Enter employee email: {Reset}");
            string email = Console.ReadLine();
            Console.Write($"{Green}Enter employee phone: {Reset}");
            string phone = Console.ReadLine();
            Console.Write($"{Green}Enter employee salary: {Reset}");
           
            try
            {
                double salary = double.Parse(Console.ReadLine());
                employeeList.Add(new FullTimeEmployee(name, email, phone, salary));
                Console.WriteLine($"{Bright}{Yellow}FullTimeEmployee added successfully!{Reset}");
                FileHandler.FileHandler.SaveToJson(employeeList);
            }
            catch
            {
                Console.WriteLine($"{Bright}{Red}One or more field not correct,FullTimeEmployee add failed!{Reset}");
            }
            
        }

        private static void AddPartTimeEmployee(EmployeeList employeeList)
        {
            Console.WriteLine($"{Bright}Adding PartTimeEmployee:{Reset}");
            Console.Write($"{Green}Enter employee name: {Reset}");
            string name = Console.ReadLine();
            Console.Write($"{Green}Enter employee email: {Reset}");
            string email = Console.ReadLine();
            Console.Write($"{Green}Enter employee phone: {Reset}");
            string phone = Console.ReadLine();
            Console.Write($"{Green}Enter employee hourly rate: {Reset}");

            try
            {
                double hourlyRate = double.Parse(Console.ReadLine());
                employeeList.Add(new PartTimeEmployee(name, email, phone, hourlyRate));
                Console.WriteLine($"{Bright}{Yellow}PartTimeEmployee added successfully!{Reset}");
                FileHandler.FileHandler.SaveToJson(employeeList);
            }
            catch
            {
                Console.WriteLine($"{Bright}{Red}One or more field not correct, PartTimeEmployee add failed!{Reset}");
            }
        }

        #endregion
    }
}
