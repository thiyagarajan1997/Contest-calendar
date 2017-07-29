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
    public sealed partial class BlankPage5 : Page
    {
        SQLiteAsyncConnection con = new SQLiteAsyncConnection("appdb");
        public BlankPage5()
        {
            this.InitializeComponent();
            tdy();

        }
        public async void tdy()
        {
            string str = DateTime.Now.ToString("dd-MM-yyyy");
            var result = await con.QueryAsync<eventtable>("Select eventname,description,dates from eventtable where dates=?", new object[] { str });
            if (result.Count == 0 )
            {
                r.Text = "No contests in the "+str;
            }
            else
            {

                foreach (var item in result)
                {
                    r.Text = r.Text + item.dates + "    ";
                    r.Text = r.Text + item.eventname + "    ";
                    r.Text = r.Text + item.description + "\n";
                }
            }
        
        }

        private void home5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
