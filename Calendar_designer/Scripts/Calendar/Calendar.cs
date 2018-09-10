using Calendar_designer.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calendar_designer
{
    public class Calendar
    {
        /// <summary>
        /// Creates a new instance of the Calendar object.
        /// </summary>
        /// <param name="newInstance">Whether or not the calendar should act as a new instance, and create its content itself.
        /// <para>The alternative is when loading a saved calendar.</para></param>
        public Calendar(bool newInstance)
        {
            Global.Calendar = this;
            Global.ResetCalendarData();

            if (newInstance)
                GetCalendar();

            Draw.Recalculate();
        }

        /// <summary>
        /// Creates a new instance of the calender object.
        /// <para>Only to be used by the Xml Serializer!</para>
        /// </summary>
        public Calendar()
        {
            Global.Calendar = this;
            Global.ResetCalendarData();
        }

        /// <summary>
        /// Gets or sets the year of this calendar.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the month index of this calendar.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the name of the month of this calendar.
        /// </summary>
        public string MonthName { get; set; }

        /// <summary>
        /// Gets or sets a list containing the dates of this calendar.
        /// </summary>
        public List<Date> Dates { get; set; } = new List<Date>();

        /// <summary>
        /// Gets or sets the first line of subtext on this calendar.
        /// </summary>
        public string Subtext1 { get; set; } = "";

        /// <summary>
        /// Gets or sets the second line of subtext on this calendar.
        /// </summary>
        public string Subtext2 { get; set; } = "";

        /// <summary>
        /// Gets or sets the preferences of this calendar.
        /// </summary>
        public Preferences Preferences { get; set; } = Global.Preferences;

        //// Methods ////

        /// <summary>
        /// Generates list with the dates of the chosen month
        /// <para>The list starts on the last monday before the month's start,
        /// and ends on the final sunday after the month</para>
        /// </summary>
        public void GetCalendar()
        {
            //Reads the month and year
            Month = Global.MainWindow.cmbMonth.SelectedIndex + 1;
            Year = int.Parse(Global.MainWindow.cmbYear.Text);

            //Finds first date of list
            DateTime listStart = new DateTime(Year, Month, 1);
            while (listStart.DayOfWeek != DayOfWeek.Monday)
                listStart = listStart.AddDays(-1);

            //Finds final date of list
            DateTime listEnd = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            while (listEnd.DayOfWeek != DayOfWeek.Sunday)
                listEnd = listEnd.AddDays(1);

            //Fills list with dates
            DateTime nextDate = listStart;
            while (nextDate.AddDays(-1) != listEnd)
            {
                Dates.Add(new Date(nextDate));
                nextDate = nextDate.AddDays(1);
            }

            MonthName = Global.MainWindow.cmbMonth.Text.ToString();
        }

        //// Static methods ////

        /// <summary>
        /// Drops the current selection.
        /// </summary>
        public static void DropSelection()
        {
            Selection.SelectedCells.Clear();
            Selection.DisableSelectionRect();
        }

        /// <summary>
        /// Calculates the week nr.
        /// </summary>
        /// <param name="time">Day/week to get week nr. of</param>
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets a list of the days of the week.
        /// </summary>
        public static IReadOnlyList<string> Weekdays { get; } = new List<string> {
            text.Monday,
            text.Tuesday,
            text.Wednesday,
            text.Thursday,
            text.Friday,
            text.Saturday,
            text.Sunday
        };
    }
}