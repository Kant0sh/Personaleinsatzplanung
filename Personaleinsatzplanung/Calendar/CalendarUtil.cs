using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personaleinsatzplanung.Calendar
{
    public static class CalendarUtil
    {
        public static string[] GetDayNames()
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("en-"))
            {
                return new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            }
            else if (CultureInfo.CurrentCulture.Name.StartsWith("de-"))
            {
                return new[] { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
            }
            else
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
            }
        }
    }
}
