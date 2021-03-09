using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class Shift
    {
        private string _clockedShift;
        private DateTime _dateTime { get; set; }

        public string ClockedShift
        {
            get => getTime(_clockedShift);
            // Is the given value valid?
            set => _clockedShift = validate(value) ? value : null;
        }



        public Shift(string aClockedShift, DateTime aDateTime)
        {
            ClockedShift = aClockedShift;
            _dateTime = aDateTime;
        }

        // validate the formality of the given shift
        private bool validate(string value)
        {
            return true;
        }


        // Get the shift in decimals
        private string getTime(string _clockedShift)
        {
            throw new NotImplementedException();
        }
    }
}
