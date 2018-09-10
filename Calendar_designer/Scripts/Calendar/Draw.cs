using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Calendar_designer
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
        /// Adds an UI element to the canvas.
        /// </summary>
        public static void Add(UIElement element) => Global.Canvas.Children.Add(element);

        /// <summary>
        /// Adds a list of UI Elements to the canvas.
        /// </summary>
        public static void Add(List<UIElement> elements) => elements.ForEach(x => Add(x));

        /// <summary>
        /// Positions an UIElement on the canvas.
        /// </summary>
        /// <param name="element">The element to set the position of.</param>
        /// <param name="location">The position of the element.</param>
        public static void Position(UIElement element, Point location) => Position(element, location.X, location.Y);

        /// <summary>
        /// Positions an UIElement on the canvas.
        /// </summary>
        /// <param name="element">The element to set the position of.</param>
        /// <param name="x">The x-coordinate of the element.</param>
        /// <param name="y">The y-coordinate of the element.</param>
        public static void Position(UIElement element, double x, double y)
        {
            Canvas.SetLeft(element, x);
            Canvas.SetTop(element, y);
        }

        /// <summary>
        /// Draws the calendar.
        /// </summary>
        public static void Redraw()
        {
            Global.Canvas.Children.Clear();

            DrawBody._Draw();
            DrawInfo._Draw();
            Selection._Draw();
        }

        /// <summary>
        /// Recalculates the calendar's data.
        /// </summary>
        public static void Recalculate()
        {
            CalculateRows();
            CalculateCellPoints();
            DrawInfo.Setup();
            DrawBody.Setup();
            Redraw();
        }

        /// <summary>
        /// Calculates the number of rows for the calendar.
        /// <para>Sets the height of the calendar from the result.</para>
        /// </summary>
        private static void CalculateRows()
        {
            Rows = Global.Calendar.Dates.Count / Calendar.Weekdays.Count;
            CellHeight = (DrawClass.CanvasHeight - DrawClass.StartCalY - DrawClass.BotPadding - DrawClass.WeekRowHeight) / Rows;
            DrawClass.SetHeight((CellHeight * Rows + DrawClass.WeekRowHeight));
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

                date.Rect = new Rectangle
                {
                    Width = width,
                    Height = height,
                    Fill = Brushes.Transparent
                };

                Position(date.Rect, x, y);
            }
        }
    }
}