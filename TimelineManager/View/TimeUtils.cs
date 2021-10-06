using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineManager.Model;

namespace TimelineManager.View
{
    class TimeUtils
    {
        public static string ParseDayFromId(string id) => id.Split('_')[1];

        public static string ParseMonthFromId(string id) => id.Split('_')[2];

        public static string ParseYearFromId(string id) => id.Split('_')[3];

        public static DateTime ParseDateTimeFromId(string id)
        {
            string s = $"{ParseYearFromId(id)}-{ParseMonthFromId(id)}-{ParseDayFromId(id)}";
            DateTime dt = DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return dt;
        }

        public static void GetOutlineDates(List<RowModel> rows, out DateTime startDate, out DateTime endDate)
        {
            const int daysOffset = 5;

            DateTime sd = rows.OrderBy(x => x.StartDate).Select(x => x.StartDate).FirstOrDefault();
            DateTime ed = rows.OrderBy(x => x.EndDate).Select(x => x.EndDate).Last();

            Console.WriteLine("sd " + sd.ToLongDateString());


            startDate = sd.AddDays(-daysOffset);
            endDate = ed.AddDays(daysOffset);
        }
    }
}
