using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kalenderdesigner_SS
{
    internal static class Calendar
    {
        public static void Setup()
        {
            Global.Reset();
            GetCalendar();
            Preferences.Read();
            ReDraw();
        }

        public static void Draw(Graphics g) => CalendarDraw.Draw(g);

        public static void ReDraw() => Global.picBox.Invalidate();

        public static void Export() => CalendarExport.Export();

        public static void Load() => CalendarLoad.Load();

        public static bool Save() => CalendarSave.Save();

        //The list starts on the last monday before the month's start, and ends on the final sunday after the month
        /// <summary>
        /// Generate list of the dates of the chosen month
        /// </summary>
        public static void GetCalendar()
        {
            List<DateTime> dates = new List<DateTime>();

            //Reads the month and year
            int month = Global.mainForm.cmbBoxMonth.SelectedIndex + 1;
            int year = Int32.Parse(Global.mainForm.cmbBoxYear.Text);

            //Finds first date of list
            DateTime listStart = new DateTime(year, month, 1);
            while (listStart.DayOfWeek != DayOfWeek.Monday)
                listStart = listStart.AddDays(-1);

            //Finds final date of list
            DateTime listEnd = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            while (listEnd.DayOfWeek != DayOfWeek.Sunday)
                listEnd = listEnd.AddDays(1);

            //Fills list with dates
            DateTime nextDate = listStart;
            while (nextDate.AddDays(-1) != listEnd)
            {
                dates.Add(nextDate);
                nextDate = nextDate.AddDays(1);
            }

            DateTime[,] datesArr = new DateTime[7, dates.Count / 7];
            for (int j = 0; j < datesArr.GetLength(1); j++)
                for (int i = 0; i < datesArr.GetLength(0); i++)
                    datesArr[i, j] = dates[j * datesArr.GetLength(0) + i];

            Global.year = year;
            Global.monthInt = month;
            Global.monthStr = Global.mainForm.cmbBoxMonth.SelectedItem.ToString();
            Global.dates = dates;
            Global.datesArr = datesArr;

            for (int i = 0; i < dates.Count; i++)
            {
                Global.line1.Add("");
                Global.line2.Add("");
                Global.line3.Add("");
                Global.lineCopyPrev.Add(false);
                Global.bigText.Add(false);
            }
        }
    }
}