using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarDesigner
{
    /// <summary>
    /// Used for drawing the body of the calendar.
    /// </summary>
    public static class DrawBody
    {
        /// <summary>
        /// Gets or sets the background of the calendar.
        /// </summary>
        private static Rectangle Background { get; set; }

        /// <summary>
        /// Gets or sets the weekdays rect.
        /// </summary>
        private static Rectangle Weekdays { get; set; }

        /// <summary>
        /// Gets or sets the weeknumbers rect.
        /// </summary>
        private static Rectangle WeekNumbers { get; set; }

        /// <summary>
        /// Gets or sets the weekend rect.
        /// </summary>
        private static Rectangle Weekend { get; set; }

        /// <summary>
        /// Gets or sets the lines that make out the outline of the calendar.
        /// </summary>
        private static List<UIElement> Outline { get; set; }

        /// <summary>
        /// Gets or sets the logo to draw on the calendar.
        /// </summary>
        private static Image Logo { get; set; }

        /// <summary>
        /// Draws the body of the calendar.
        /// </summary>
        public static void _Draw()
        {
            DrawFill();
            DrawOutline();
            Draw.Add(Logo);
        }

        /// <summary>
        /// Fills top row and col, and weekend cells.
        /// </summary>
        private static void DrawFill()
        {
            Draw.Add(Background);
            Draw.Add(Weekdays);
            Draw.Add(WeekNumbers);
            Draw.Add(Weekend);

            Global.Calendar.Dates.ForEach(x => Draw.Add(x.Rect));
        }

        /// <summary>
        /// Draws the calendar's outline.
        /// </summary>
        private static void DrawOutline() => Draw.Add(Outline);

        /// <summary>
        /// Calculates the shapes of the body.
        /// </summary>
        public static void Setup()
        {
            LogoSetup();
            FillSetup();
            OutlineSetup();
        }

        /// <summary>
        /// Calculates all fill-related shapes.
        /// </summary>
        private static void FillSetup()
        {
            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int width = DrawClass.Width;
            int height = DrawClass.Height;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int weekColWidth = DrawClass.WeekColWidth;

            Background = new Rectangle
            {
                Width = DrawClass.CanvasWidth - 1,
                Height = DrawClass.CanvasHeight - 1,
                Fill = Brushes.White
            };

            // Fill top column.
            Weekdays = new Rectangle
            {
                Width = width,
                Height = weekRowHeight,
                Fill = Brushes.Gray
            };
            Draw.Position(Weekdays, x, y);

            // Fill left row.
            WeekNumbers = new Rectangle
            {
                Width = weekColWidth,
                Height = height,
                Fill = Brushes.Gray
            };
            Draw.Position(WeekNumbers, x, y);

            // Finds first saturday, fills weekend cells.
            foreach (Date date in Global.Calendar.Dates)
                if (date.Time.DayOfWeek == DayOfWeek.Saturday)
                {
                    Weekend = new Rectangle
                    {
                        Width = DrawClass.CellWidth * 2,
                        Height = DrawClass.CellHeight * Draw.Rows,
                        Fill = Brushes.LightGray
                    };
                    Draw.Position(Weekend, date.TopLeft);

                    break;
                }
        }

        /// <summary>
        /// Calculates all outline-related shapes.
        /// </summary>
        private static void OutlineSetup()
        {
            Outline = new List<UIElement>();

            Brush stroke = Brushes.Black;
            int outlineWidth = Draw.Multiplier;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;

            // Vertical lines.
            {
                int height = DrawClass.Height;
                int weekColWidth = DrawClass.WeekColWidth;
                int cellWidth = DrawClass.CellWidth;
                int weekdays = Calendar.Weekdays.Count;

                // Left line.
                Line line = new Line
                {
                    Y2 = height,
                    Stroke = stroke,
                    StrokeThickness = outlineWidth
                };
                Draw.Position(line, x, y);

                Outline.Add(line);

                // Remaining lines.
                for (int i = 0; i <= weekdays; i++)
                {
                    int lineX = x + weekColWidth + cellWidth * i;

                    line = new Line
                    {
                        Y2 = height,
                        Stroke = stroke,
                        StrokeThickness = (i == 0 || i == weekdays) ? outlineWidth : 1
                    };
                    Draw.Position(line, lineX, y);

                    Outline.Add(line);
                }
            }

            // Horizontal lines.
            {
                int rows = Draw.Rows;
                int width = DrawClass.Width;
                int weekRowHeight = DrawClass.WeekRowHeight;
                int cellHeight = DrawClass.CellHeight;

                // Top line (adds a single pixel to its width).
                Line line = new Line
                {
                    X2 = width + 1,
                    Stroke = stroke,
                    StrokeThickness = outlineWidth
                };
                Draw.Position(line, x - 1, y);

                Outline.Add(line);

                // Remaining lines.
                for (int i = 0; i <= rows; i++)
                {
                    int lineY = y + weekRowHeight + cellHeight * i;

                    line = new Line
                    {
                        X2 = width,
                        Stroke = stroke,
                        StrokeThickness = (i == 0 || i == rows) ? outlineWidth : 1
                    };
                    Draw.Position(line, x, lineY);

                    Outline.Add(line);
                }
            }
        }

        /// <summary>
        /// Resizes the logo to fit the current multiplier.
        /// </summary>
        private static void LogoSetup()
        {
            double logoDiv = .1 * Draw.Multiplier;

            BitmapImage btm = new BitmapImage(new Uri("pack://application:,,,/Resources/Logo.jpg", UriKind.Absolute));

            Logo = new Image
            {
                Margin = new Thickness(DrawClass.StartX, DrawClass.StartY, 0, 0),
                Source = btm,
            };

            RenderOptions.SetBitmapScalingMode(Logo, BitmapScalingMode.HighQuality);

            Logo.Width = btm.Width * logoDiv;
            Logo.Height = btm.Height * logoDiv;
        }
    }
}