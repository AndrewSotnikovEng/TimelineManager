using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineManager.Model;

namespace TimelineManager.View
{
    public class DrawUtils
    {
        public static List<CellModel> CreateCellsForRow(RowModel item, DateTime startDate, DateTime endDate)
        {
            DateTime today = DateTime.Today;

            //replace with flexible values
            int cellsCount = (endDate - startDate).Days;
            //DateTime lastDate = new DateTime().AddDays(150);    //get somewhere from service
            DateTime curDate = startDate;

            List<CellModel> l = new List<CellModel>();

            for (int i = 0; i < cellsCount; i++)
            {
                curDate = startDate.AddDays(i);
                string dateFormat = $"{curDate.Day.ToString("00")}_" +
                                    $"{curDate.Month.ToString("00")}_" +
                                    $"{curDate.Year.ToString("0000")}";

                string cellId = $"{item.Name}_{dateFormat}";
                CellModel cell = new CellModel
                    (cellId, item.Color);

                l.Add(cell);
            }

            return l;
        }




    }
}
