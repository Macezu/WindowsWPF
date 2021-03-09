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
            var shift = new Shift("01:00-17:00", DateTime.Now);
            Console.WriteLine(shift.ClockedShift);
            Console.ReadLine();
        }
    }
}
