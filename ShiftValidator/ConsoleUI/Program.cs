using System;
using HelperLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Shift shift;
            while (true)
            {
                Console.WriteLine("Hello employee please input your latest shift in HH:mm-HH:mm format");
                string employeeInput = Console.ReadLine();
                shift = new Shift(employeeInput, DateTime.Now);
                if (!(shift.ClockedShift is null)){break;}
                else{ Console.WriteLine("The Input given was not in valid form \n"); }
            }

            Console.WriteLine("Shift was saved");
            Console.WriteLine("Would you like to view your latest shift? Y/N");
            var answer = Console.ReadLine();
            var returningString = answer == "y" || answer == "Y" ? $"Your last shift duration was: { (shift.getShift().ToString())} hours" :"Thank You";
            Console.WriteLine(returningString);
            Console.ReadLine();
        }
    }
}
