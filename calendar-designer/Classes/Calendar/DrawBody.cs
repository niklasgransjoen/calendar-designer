using System.Drawing;

namespace CalendarDesigner
{
    /// <summary>
    /// Used for drawing the body of the calendar.
    /// </summary>
    public static class DrawBody
    {
        /// <summary>
        /// Draws the body of the calendar.
        /// </summary>
        public static void Draw(Graphics g)
        {
            FillCells(g);
            DrawOutline(g);
        }

        /// <summary>
        /// Fills top row and col, and weekend cells.
        /// </summary>
        private static void FillCells(Graphics g)
        {
            SolidBrush fill = DrawClass.Gray;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int width = DrawClass.Width;
            int height = DrawClass.Height;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int weekColWidth = DrawClass.WeekColWidth;

            // Fills top column
            Rectangle rectCol = new Rectangle(x, y, width, weekRowHeight);
            g.FillRectangle(fill, rectCol);

            // Fills left row
            Rectangle rectRow = new Rectangle(x, y, weekColWidth, height);
            g.FillRectangle(fill, rectRow);

            // Fills weekends
            foreach (Date date in Global.Calendar.Dates)
                if (date.Time.DayOfWeek == System.DayOfWeek.Saturday || date.Time.DayOfWeek == System.DayOfWeek.Sunday)
                    g.FillRectangle(Brushes.LightGray, date.Rect);
        }

        /// <summary>
        /// Draws the calendar's outline.
        /// </summary>
        private static void DrawOutline(Graphics g)
        {
            Pen pen = Pens.Black;
            SolidBrush brush = DrawClass.Black;
            int outlineWidth = CalendarDesigner.Draw.Multiplier;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int height = DrawClass.Height;
            int width = DrawClass.Width;
            int weekColWidth = DrawClass.WeekColWidth;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int cellWidth = DrawClass.CellWidth;
            int cellHeight = DrawClass.CellHeight;

            // Vertical lines
            {
                // Left and right sides.
                g.FillRectangle(brush, new Rectangle(x, y, outlineWidth, height));
                g.FillRectangle(brush, new RectangleF(x + weekColWidth, y, outlineWidth, height));
                g.FillRectangle(brush, new Rectangle(x + width, y, outlineWidth, height));

                //Remaining lines
                for (int i = 1; i <= Calendar.Weekdays.Count - 1; i++)
                {
                    Point point1 = new Point(x + weekColWidth + cellWidth * i, y);
                    Point point2 = new Point(x + weekColWidth + cellWidth * i, y + height);
                    g.DrawLine(pen, point1, point2);
                }
            }

            // Horizontal lines
            {
                // Top and bottom lines.
                g.FillRectangle(brush, new Rectangle(x, y, width, outlineWidth));
                g.FillRectangle(brush, new RectangleF(x, y + weekRowHeight, width, outlineWidth));
                g.FillRectangle(brush, new Rectangle(x, y + height, width + outlineWidth, outlineWidth));

                // Remaining lines
                for (int i = 1; i <= CalendarDesigner.Draw.Rows - 1; i++)
                {
                    Point point1 = new Point(x, y + weekRowHeight + cellHeight * i);
                    Point point2 = new Point(x + width, y + weekRowHeight + cellHeight * i);
                    g.DrawLine(pen, point1, point2);
                }
            }
        }
    }
}