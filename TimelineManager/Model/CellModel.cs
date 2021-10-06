using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineManager.View
{
    public class CellModel
    {
        public string cellId { get; set; }
        //public int rowId { get; set; }
        //public int colId { get; set; }
        public string Color { get; set; }

        public CellModel(string cellId, string color)
        {
            this.cellId = cellId;
            //this.rowId = rowId;
            //this.colId = colId;
            Color = color;
        }
    }
}
