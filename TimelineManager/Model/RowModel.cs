using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineManager.Model
{
    public class RowModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; }

        public RowModel(long id, string name, DateTime startDate, DateTime endDate, string color)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Color = color;
        }
    }
}
