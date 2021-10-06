using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineManager.Model
{
    class AppProperties
    {
        public int height { get; set; } = 20;
        public int width { get; set; } = 20;

        public int horizontalGap { get; set; } = 0;

        public int initialHorizontalPosition { get; set; } = 30;
        public int initialVerticalPosition { get; set; } = 30;
        public int verticalGap { get; internal set; } = 10;
    }
}
