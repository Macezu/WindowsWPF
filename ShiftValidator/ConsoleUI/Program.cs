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

            var shift = new Shift("12:00-16:00");
            Console.WriteLine(shift.ClockedShift);
            System.Threading.Thread.Sleep(2500);
        }
    }
}
