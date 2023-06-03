using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string selection = "";
            Console.WriteLine($"How do you wish to add employee data? Enter \"1\" or \"2\" below to make your selection.");

            while (selection != "1" && selection != "2")
            {
                if (selection != "")
                {
                    Console.WriteLine("Invalid selection. Enter \"1\" or \"2\" below to make your selection.");
                }
                Console.WriteLine("1. Automatically import employees");
                Console.WriteLine("2. Add employees manually");
                selection = Console.ReadLine() ?? "";
            }

            switch (selection)
            {
                case "1":
                    employees = await PeopleFetcher.GetFromApi();
                    break;
                case "2":
                    employees = PeopleFetcher.GetEmployees();
                    break;
                default:
                    Console.WriteLine("Oops! Something went wrong");
                    break;
            }

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}