using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641  
namespace contest_calendar
{
    /// <summary>  
    /// An empty page that can be used on its own or navigated to within a Frame.  
    /// </summary>  
    public sealed partial class BlankPage1 : Page
    {
        
        DateTime calendarDate;
        public BlankPage1()
        {
            this.InitializeComponent();
            
            calendarDate = DateTime.Today;
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

      
        /// <summary>  
        /// Invoked when this page is about to be displayed in a Frame.  
        /// </summary>  
        /// <param name="e">Event data that describes how this page was reached.  
        /// This parameter is typically used to configure the page.</param>  
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateCalendar(calendarDate);
        }
        public void UpdateCalendar(DateTime objdate)
        {
            CalendarHeader.Text = objdate.ToString("MMMM yyyy");
            objdate = new DateTime(objdate.Year, objdate.Month, 1);
            int dayOfWeek = (int)objdate.DayOfWeek + 1;
            int daysOfMonth = DateTime.DaysInMonth(objdate.Year, objdate.Month);
            int i = 1;
            foreach (var o1 in Calendar.Children)
            {
                foreach (var o2 in (o1 as StackPanel).Children)
                {
                    var o3 = (o2 as Grid).Children[0] as TextBlock;
                    if (i >= dayOfWeek && i < (daysOfMonth + dayOfWeek))
                    {
                        o3.Text = (i - dayOfWeek + 1).ToString();
                    }
                    else
                    {
                        o3.Text = "";
                    }
                    i++;
                }
            }
        }
        private void previousMonth(object sender, RoutedEventArgs e)
        {
            calendarDate = calendarDate.AddMonths(-1);
            UpdateCalendar(calendarDate);
        }
        private void nextMonth(object sender, RoutedEventArgs e)
        {
            calendarDate = calendarDate.AddMonths(1);
            UpdateCalendar(calendarDate);
        }

        private  void button1_Click(object sender, RoutedEventArgs e)
        {
            string d = datebox.Text;  
            this.Frame.Navigate(typeof(BlankPage4),d);
            
           
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        
    }
}