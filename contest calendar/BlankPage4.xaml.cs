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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace contest_calendar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage4 : Page
    {
        SQLiteAsyncConnection con = new SQLiteAsyncConnection("appdb");
        public BlankPage4()
        {
            this.InitializeComponent();
             
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var str = e.Parameter as string;
            var result = await con.QueryAsync<eventtable>("Select eventname,description,dates from eventtable where dates=?", new object[] { str });
            if (result.Count == 0 )
            {
                res.Text = "No contests in the selected date";
            }
            else
            {

                foreach (var item in result)
                {
                    res.Text = res.Text + item.dates + "    ";
                    res.Text = res.Text + item.eventname + "    ";
                    res.Text = res.Text + item.description + "\n";
                }
            }
        }

        private void home1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
