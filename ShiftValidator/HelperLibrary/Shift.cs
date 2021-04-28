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
        private TimeSpan _clockedShift;
        private DateTime _dateTime { get; set; }

        public string ClockedShift
        {
            get => _clockedShift.ToString();
            // Is the given value valid?
            set {
                try
                {
                    validateFormat(value);
                } catch (ArgumentException)
                {
                    throw new ArgumentException("value vas not in correct format", nameof(value));
                }
                
                   

            }
        }



        public Shift(string aClockedShift, DateTime aDateTime)
        {
            ClockedShift = aClockedShift;
            _dateTime = aDateTime;
        }

        // Validate the formality of the given shift
        private bool validateFormat(string value)
        {
            string[] splitted = value.Split('-');
            var shiftStart = convertToTimeSpan(splitted[0]);
            var shiftEnd = convertToTimeSpan(splitted[1]);
            var regex = ("^([01]?[0-9]|2[0-3]):([0-5][0-9])-([01]?[0-9]|2[0-3]):([0-5][0-9])$");
            return (isChronological(shiftStart,shiftEnd) && isOverTime(shiftStart, shiftEnd) && Regex.IsMatch(value, regex));
        }

        // Check that hours given are in chronological order
        private bool isChronological(TimeSpan shiftStart, TimeSpan shiftEnd)
        {

            return (TimeSpan.Compare(shiftStart, shiftEnd) < 0); 
        }

        // Check that shift doesn't exeed 16 hours
        private bool isOverTime(TimeSpan shiftStart, TimeSpan shiftEnd)
        {
            var SIXTEEN_HOURS_INMILLIS = 57600000;
            var duration = shiftEnd - shiftStart;
            return duration.TotalMilliseconds <= SIXTEEN_HOURS_INMILLIS; 
        }


        // Get the shift in decimals
        public Double getShift()
        {
            var ClockedShift = _clockedShift.ToString();
            string[] splitted = ClockedShift.Split('-');
            var shiftStart = convertToTimeSpan(splitted[0]);
            var shiftEnd = convertToTimeSpan(splitted[1]);
            var duration = shiftEnd - shiftStart;
            return Math.Round(duration.TotalHours,2);

        }

        public TimeSpan convertToTimeSpan(string stringToConvert) => TimeSpan.Parse(stringToConvert);
        
    }
}
