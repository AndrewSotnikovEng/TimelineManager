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
        int _rowHorizontalPosition;

        public MainWindow()
        {
            InitializeComponent();
            AppProperties prop = new AppProperties();

            //Canvas canvas = this.MainCanvas;

            int _rowHorizontalPosition = AppProperties.initialHorizontalPosition;
            int rowVerticalPosition = AppProperties.initialVerticalPosition;

            vm = new ViewModel();

            DrawYear(vm.StartDate, vm.EndDate);
            DrawMonth(vm.StartDate, vm.EndDate);
            DrawData(vm.DataModel, vm.StartDate, vm.EndDate);


        }

        ViewModel vm;

        private void DrawYear(DateTime startDate, DateTime endDate)
        {
            
            //year
            
            int colCounter = 0;
            string prevYear = "";
            string curYear;
            foreach (var c in DrawUtils.CreateCellsForRow(vm.YearModel, startDate, endDate))
            {
                ColumnDefinition colDefinition = new ColumnDefinition();
                MainContainer.ColumnDefinitions.Add(colDefinition);

                _rowHorizontalPosition += AppProperties.width + AppProperties.horizontalGap;

                TextBlock tb = new TextBlock();
                tb.Height = AppProperties.height;
                tb.Width = AppProperties.width;

                curYear = TimeUtils.ParseYearFromId(c.cellId);


                tb.Text = curYear.Substring(2, 2);

                tb.Name = c.cellId;
                tb.FontSize = 10;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;

                tb.ToolTip = vm.YearModel.Name;

                DateTime dt = TimeUtils.ParseDateTimeFromId(c.cellId);

                DateRange range = new DateRange(vm.YearModel.StartDate, vm.YearModel.EndDate);
                if (range.Includes(dt))
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(c.Color);
                }
                else
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }

                Grid.SetRow(tb, 0);

                Grid.SetColumn(tb, colCounter);
                prevYear = curYear;

                MainContainer.Children.Add(tb);

                colCounter++;
            }
            
        }

        private void DrawData(List<RowModel> rowList, DateTime startDate, DateTime endDate)
        {
            int rowCounter = 2;
            foreach (var row in rowList)
            {
                RowDefinition rowDefinition = new RowDefinition();
                MainContainer.RowDefinitions.Add(rowDefinition);

                int colCounter = 0;
                foreach (var c in DrawUtils.CreateCellsForRow(row, startDate, endDate))
                {
                    ColumnDefinition colDefinition = new ColumnDefinition();
                    MainContainer.ColumnDefinitions.Add(colDefinition);

                    _rowHorizontalPosition += AppProperties.width + AppProperties.horizontalGap;

                    TextBlock tb = new TextBlock();
                    tb.Height = AppProperties.height;
                    tb.Width = AppProperties.width;

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
                    }
                    else
                    {
                        tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                    }

                    Grid.SetRow(tb, rowCounter);
                    Grid.SetColumn(tb, colCounter);
                    MainContainer.Children.Add(tb);

                    colCounter++;
                }
                rowCounter++;
            }
        }

        private void DrawMonth(DateTime startDate, DateTime endDate)
        {
            RowDefinition rowDefinition = new RowDefinition();
            MainContainer.RowDefinitions.Add(rowDefinition);

            int colCounter = 0;
            string prevMonth = "";
            string curMonth;
            foreach (var c in DrawUtils.CreateCellsForRow(vm.MonthModel, startDate, endDate))
            {

                ColumnDefinition colDefinition = new ColumnDefinition();
                MainContainer.ColumnDefinitions.Add(colDefinition);

                _rowHorizontalPosition += AppProperties.width + AppProperties.horizontalGap;

                TextBlock tb = new TextBlock();
                tb.Height = AppProperties.height;
                tb.Width = AppProperties.width;

                curMonth = TimeUtils.ParseMonthFromId(c.cellId);

                tb.Text = curMonth;


                tb.Name = c.cellId;
                tb.FontSize = 10;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;

                tb.ToolTip = vm.MonthModel.Name;

                DateTime dt = TimeUtils.ParseDateTimeFromId(c.cellId);

                DateRange range = new DateRange(vm.MonthModel.StartDate, vm.MonthModel.EndDate);
                if (range.Includes(dt))
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(c.Color);
                }
                else
                {
                    tb.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }

                Grid.SetRow(tb, 1);
                Grid.SetColumn(tb, colCounter);
                prevMonth = curMonth;

                MainContainer.Children.Add(tb);

                colCounter++;
            }

            //_rowHorizontalPosition = rowHorizontalPosition;
        }
    }
}