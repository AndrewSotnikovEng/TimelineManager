using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using TimelineManager.Model;
using TimelineManager.View;

namespace TimelineManager
{
    class ViewModel
    {
        List<RowModel> rowList = new List<RowModel>();
        
        public RowModel YearModel
        {
            get 
            {
                return rowList.ElementAt(0);
            }
        }

        public RowModel MonthModel
        {
            get
            {
                return rowList.ElementAt(1);
            }
        }

        public List<RowModel> DataModel
        {
            get
            {
                return rowList.Skip(0).ToList();
            }
        }

        public DateTime StartDate { get; set; }



        public DateTime EndDate { get; set; }



        public ViewModel()
        {
            DateTime today = DateTime.Today;

            

            rowList.Add(new RowModel(2, "Basement", today.AddDays(-159), today.AddDays(30), "Aqua"));
            rowList.Add(new RowModel(3, "Wiring", today.AddDays(-118), today.AddDays(29), "Blue"));
            rowList.Add(new RowModel(4, "Fence", today.AddDays(-117), today.AddDays(28), "Orange"));

            DateTime _srartDate;
            DateTime _endDate;
            TimeUtils.GetOutlineDates(rowList, out _srartDate, out _endDate);

            StartDate = _srartDate;
            EndDate = _endDate;


            RowModel yearLabel = new RowModel(0, "", StartDate, EndDate, "White");
            RowModel monthLabel = new RowModel(1, "", StartDate, EndDate, "White");
            rowList.Insert(0, yearLabel);
            rowList.Insert(0, monthLabel);




        }
    }
}
