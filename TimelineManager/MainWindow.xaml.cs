using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimelineManager.Model;
using TimelineManager.View;

namespace TimelineManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppProperties prop = new AppProperties();

            //Canvas canvas = this.MainCanvas;

            int rowHorizontalPosition = prop.initialHorizontalPosition;
            int rowVerticalPosition = prop.initialVerticalPosition;

            List<RowModel> rowList = new List<RowModel>();

            DateTime today = DateTime.Today;


            rowList.Add(new RowModel(2, "Basement", today.AddDays(-159), today.AddDays(30), "Aqua"));
            rowList.Add(new RowModel(3, "Wiring", today.AddDays(-118), today.AddDays(29), "Blue"));
            rowList.Add(new RowModel(4, "Fence", today.AddDays(-117), today.AddDays(28), "Orange"));

            DateTime startDate;
            DateTime endDate;
            TimeUtils.GetOutlineDates(rowList, out startDate, out endDate);

            RowDefinition rowDefinition = new RowDefinition();
            MainContainer.RowDefinitions.Add(rowDefinition);


            //year
            RowModel label = new RowModel(0, "", startDate, endDate, "White");
            int colCounter = 0;
            string prevYear = "";
            string curYear;
            foreach (var c in DrawUtils.CreateCellsForRow(label, startDate, endDate))
            {
                ColumnDefinition colDefinition = new ColumnDefinition();
                MainContainer.ColumnDefinitions.Add(colDefinition);

                rowHorizontalPosition += prop.width + prop.horizontalGap;

                TextBlock tb = new TextBlock();
                tb.Height = prop.height;
                tb.Width = prop.width;

                curYear = TimeUtils.ParseYearFromId(c.cellId);

                if (!String.IsNullOrEmpty(prevYear) && curYear != prevYear)
                {
                    tb.Text = curYear.Substring(2, 2);
                }

                
                tb.Name = c.cellId;
                tb.FontSize = 10;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;

                tb.ToolTip = label.Name;

                DateTime dt = TimeUtils.ParseDateTimeFromId(c.cellId);

                DateRange range = new DateRange(label.StartDate, label.EndDate);
                if (range.Includes(dt))
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(c.Color);
                }
                else
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }

                Grid.SetRow(tb, 0);

                //if (prevMonth != curMonth)
                //{
                Grid.SetColumn(tb, colCounter);
                prevYear = curYear;
                //}
                MainContainer.Children.Add(tb);

                colCounter++;
            }
            //MainContainer.Height = 1 * prop.height + prop.verticalGap;




            //month
            rowDefinition = new RowDefinition();
            MainContainer.RowDefinitions.Add(rowDefinition);
            label = new RowModel(1, "", startDate, endDate, "White");
            colCounter = 0;
            string prevMonth = "";
            string curMonth = "";
            foreach (var c in DrawUtils.CreateCellsForRow(label, startDate, endDate))
            {
               
                ColumnDefinition colDefinition = new ColumnDefinition();
                MainContainer.ColumnDefinitions.Add(colDefinition);

                rowHorizontalPosition += prop.width + prop.horizontalGap;

                TextBlock tb = new TextBlock();
                tb.Height = prop.height;
                tb.Width = prop.width;

                curMonth = TimeUtils.ParseMonthFromId(c.cellId);

                if (!String.IsNullOrEmpty(prevMonth) && curMonth != prevMonth)
                {
                    tb.Text = curMonth;
                }
                
                tb.Name = c.cellId;
                tb.FontSize = 10;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;

                tb.ToolTip = label.Name;

                DateTime dt = TimeUtils.ParseDateTimeFromId(c.cellId);

                DateRange range = new DateRange(label.StartDate, label.EndDate);
                if (range.Includes(dt))
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(c.Color);
                }
                else
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }

                Grid.SetRow(tb, 1);

                //if (prevmonth != curmonth)
                //{
                    Grid.SetColumn(tb, colCounter);
                    prevMonth = curMonth;
                //}
                MainContainer.Children.Add(tb);

                colCounter++;
            }
            //MainContainer.Height = 2 * prop.height + prop.verticalGap;



            //data
            int rowCounter = 2;
            foreach (var row in rowList)
            {
                rowDefinition = new RowDefinition();
                MainContainer.RowDefinitions.Add(rowDefinition);

                colCounter = 0;
                foreach (var c in DrawUtils.CreateCellsForRow(row, startDate, endDate))
                {
                    ColumnDefinition colDefinition = new ColumnDefinition();
                    MainContainer.ColumnDefinitions.Add(colDefinition);

                    rowHorizontalPosition += prop.width + prop.horizontalGap;

                    TextBlock tb = new TextBlock();
                    tb.Height = prop.height;
                    tb.Width = prop.width;

                    tb.Text = TimeUtils.ParseDayFromId(c.cellId);
                    tb.Name = c.cellId;
                    tb.FontSize = 10;
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;

                    tb.ToolTip = row.Name;

                    DateTime dt = TimeUtils.ParseDateTimeFromId(c.cellId);

                    DateRange range = new DateRange(row.StartDate, row.EndDate);
                    if (range.Includes(dt))
                    {
                        tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(c.Color);
                    } else
                    {
                        tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                    }

                    Grid.SetRow(tb, rowCounter);
                    Grid.SetColumn(tb, colCounter);
                    MainContainer.Children.Add(tb);

                    colCounter++;
                }
                rowCounter++;
                //MainContainer.Height = (rowCounter + 1) * ( prop.height + prop.verticalGap);
            }
        }
    }
}