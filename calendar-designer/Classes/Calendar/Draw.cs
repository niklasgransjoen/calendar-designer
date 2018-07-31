using CalendarDesigner.Properties;
using System;
using System.Drawing;

namespace CalendarDesigner
{
    public static class Draw
    {
        /// <summary>
        /// Gets or sets the multiplier to draw the calendar with.
        /// <para>Used for exporting the calendar with higher resolution.</para>
        /// </summary>
        public static int Multiplier { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of rows of the calendar.
        /// </summary>
        public static int Rows { get; set; }

        /// <summary>
        /// Gets or sets the height of the rows of the calendar.
        /// </summary>
        public static int CellHeight { get; set; }

        /// <summary>
        /// Gets or sets the logo to draw on the calendar.
        /// </summary>
        public static Image Logo { get; set; }

        /// <summary>
        /// Draws the calendar.
        /// </summary>
        public static void Redraw(Graphics g)
        {
            g.Clear(Color.White);
            g.DrawImage(Logo, new Point(DrawClass.StartX, DrawClass.StartY));

            DrawBody.Draw(g);
            DrawInfo.Draw(g);
            Selection.Draw(g);
        }

        /// <summary>
        /// Recalculates the calendar's data.
        /// </summary>
        public static void Recalculate()
        {
            CalculateRows();
            CalculateCellPoints();
            DrawInfo.FontSetup();
            LogoResize();
        }

        /// <summary>
        /// Calculates the number of rows for the calendar.
        /// <para>Sets the height of the calendar from the result.</para>
        /// </summary>
        private static void CalculateRows()
        {
            Rows = Global.Calendar.Dates.Count / Calendar.Weekdays.Count;
            CellHeight = (Global.PicBox.Height - (DrawClass.StartCalY + DrawClass.BotPadding + DrawClass.WeekRowHeight) / Multiplier) / Rows;
            DrawClass.SetHeight((CellHeight * Rows + DrawClass.WeekRowHeight / Multiplier));
        }

        /// <summary>
        /// Calculates the points of the date cells of the calendar.
        /// </summary>
        private static void CalculateCellPoints()
        {
            int startX = DrawClass.StartX + DrawClass.WeekColWidth;
            int startY = DrawClass.StartCalY + DrawClass.WeekRowHeight;
            int width = DrawClass.CellWidth;
            int height = DrawClass.CellHeight;

            for (int i = 0; i < Global.Calendar.Dates.Count; i++)
            {
                Date date = Global.Calendar.Dates[i];

                // Gets the row and col of this date.
                int col = i % Calendar.Weekdays.Count;
                int row = (int)Math.Floor(i / (double)Calendar.Weekdays.Count);

                int x = startX + col * width;
                int y = startY + row * height;

                date.Points[Date.indexTopLeft] = new Point(x, y);
                date.Points[Date.indexTopRight] = new Point(x + width, y);
                date.Points[Date.indexBotRight] = new Point(x + width, y + height);
                date.Points[Date.indexBotLeft] = new Point(x, y + height);
            }
        }

        /// <summary>
        /// Resizes the logo to fit the current multiplier.
        /// </summary>
        private static void LogoResize()
        {
            double logoDiv = .1 * Multiplier;

            Image logo = Resources.ssLogo;
            Logo = logo.Resize((int)(logo.Width * logoDiv), (int)(logo.Height * logoDiv));
        }
    }
}