using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class Shift
    {
        private string _clockedShift;
        private DateTime _dateTime { get; set; }

        public string ClockedShift
        {
            get => _clockedShift;
            // Is the given value valid?
            set => _clockedShift = validateFormat(value) ? value : null;
        }



        public Shift(string aClockedShift, DateTime aDateTime)
        {
            ClockedShift = aClockedShift;
            _dateTime = aDateTime;
        }

        // Validate the formality of the given shift
        private bool validateFormat(string value)
        {
            var regex = ("^([01]?[0-9]|2[0-3]):([0-5][0-9])-([01]?[0-9]|2[0-3]):([0-5][0-9])");
            return Regex.IsMatch(value, regex) ? isChronological(value) : false;  
        }

        // Check that hours given are in chronological order
        private bool isChronological(string value)
        {
            var splitted = value.Split('-');
            var shiftStart = TimeSpan.Parse(splitted[0]);
            var shiftEnd = TimeSpan.Parse(splitted[1]);
            return TimeSpan.Compare(shiftStart, shiftEnd) <0 ? overTime(shiftStart,shiftEnd): false;
        }

        // Check that shift doesn't exeed 16 hours
        private bool overTime(TimeSpan shiftStart, TimeSpan shiftEnd)
        {

            var duration = shiftEnd - shiftStart;
            Console.WriteLine(duration.TotalMilliseconds);
            return duration.TotalMilliseconds <= 57600000; // 16Hours and not a single millisecond more
        }


        // Get the shift in decimals
        private string getTime(string _clockedShift)
        {
            return "kissa";
        }
    }
}
