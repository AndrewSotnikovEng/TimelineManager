using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineManager.Model
{
    class AppProperties
    {
        public static int height { get; set; } = 20;
        public static int width { get; set; } = 20;

        public static int horizontalGap { get; set; } = 0;

        public static int initialHorizontalPosition { get; set; } = 30;
        public  static int initialVerticalPosition { get; set; } = 30;
        public static int verticalGap { get; internal set; } = 10;
    }
}
