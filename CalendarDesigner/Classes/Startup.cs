using CalendarDesigner.Properties;
using System;
using System.Windows.Controls;

namespace CalendarDesigner
{
    public static class Startup
    {
        /// <summary>
        /// Runs the necessary setup for the software.
        /// </summary>
        public static void Setup()
        {
            //Title on mainform, format Vx.x
            string version = Global.Version;
            Global.MainWindow.Title = text.CalendarDesigner + " V" + version.Substring(0, version.IndexOf(".", version.IndexOf(".") + 1));

            ComboBox boxMonth = Global.MainWindow.cmbMonth;
            ComboBox boxYear = Global.MainWindow.cmbYear;

            for (int i = 0; i < 5; i++)
            {
                //Fill comboBoxes
                int year = DateTime.Now.Year + i;
                boxYear.Items.Add(year);
            }

            //Select NEXT month, roll over to next year if necessary
            if (DateTime.Now.Month + 1 <= boxMonth.Items.Count)
            {
                boxMonth.SelectedIndex = DateTime.Now.Month;
                boxYear.Text = DateTime.Now.Year.ToString();
            }
            else
            {
                boxMonth.SelectedIndex = 0;
                boxYear.Text = (DateTime.Now.Year + 1).ToString();
            }

            new Calendar(true);
        }
    }
}