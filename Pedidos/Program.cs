using Restaurante.Entities;
using Restaurante.Enums;
using System;
using System.Globalization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the department's name: ");
            string dptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data: ");
            Console.Write("Enter the Worker's name: ");
            string workerName = Console.ReadLine();
            Console.Write("Enter the Worker's Level (Junior/MidLevel/Senior):");
            WorkerLevel workerLevel = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Base salary: ");
            double workerSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(dptName);
            Worker worker = new Worker(workerName,workerLevel, workerSalary, department);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{n} contract data:");
                Console.Write("Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePH = double.Parse(Console.ReadLine());
                Console.Write("Duraton: ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePH,duration);
                worker.AddContract(contract);
                
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Name: "+ worker.Name);
            Console.WriteLine("Department: "+ worker.Department.Name);
            Console.WriteLine("Income for "+monthAndYear+": "+ worker.Income(year, month));

        }
    }
}