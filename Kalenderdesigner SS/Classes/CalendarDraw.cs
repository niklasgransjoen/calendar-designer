using Kalenderdesigner_SS.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;

namespace Kalenderdesigner_SS
{
    internal static class CalendarDraw
    {
        public static int cornerX = 20;
        public static int cornerY = 20;
        public static int cornerYTable = 80;
        public static int cornerYBottom = 30;

        public static int paddingX = 29;
        public static int paddingY = 20;

        public static int colWidth = 75;
        public static int rowHeight;
        public static int rows;

        public static int width = Global.mainForm.picBox.Width - cornerX * 2;
        public static int height = Global.mainForm.picBox.Height - cornerYBottom - cornerYTable;

        public static int infoPosX = cornerX + width;
        public static int infoSize = 8;
        private static string address = Global.GetText("businessInfo1");
        private static string tlf = Global.GetText("businessInfo2");
        private static string email = Global.GetText("businessInfo3");
        private static string website = Global.GetText("businessInfo4");

        public static int headlineSize = 24;
        public static int fontSize = 12;
        public static double logoDiv = 10;

        //Fonts
        private const string fontName = "Calibri";
        private static Font ssFont;
        private static Font font;
        private static Font fontBold;
        private static Font fontInfo;
        private static Font fontSubtext;

        public static readonly IReadOnlyCollection<string> weekdays = new List<string> {
            Global.GetText("monday"),
            Global.GetText("tuesday"),
            Global.GetText("wednesday"),
            Global.GetText("thursday"),
            Global.GetText("friday"),
            Global.GetText("saturday"),
            Global.GetText("sunday") };

        /// <summary>
        /// Draw the calendar
        /// </summary>
        /// <param name="g">Graphics</param>
        public static void Draw(Graphics g)
        {
            g.Clear(Color.White);

            Image logo = Resources.ssLogo;
            Image logoResize = ResizeImage(logo, (int)(logo.Width / logoDiv), (int)(logo.Height / logoDiv));
            g.DrawImage(logoResize, new Point(cornerX, cornerY));

            CalculatePoints();
            DrawColor(g);
            DrawOutline(g);
            DrawText(g);
        }

        /// <summary>
        /// Calculate points based on the number of rows
        /// </summary>
        private static void CalculatePoints()
        {
            rows = Global.datesArr.GetLength(1);
            rowHeight = (height - paddingY) / rows;

            //Finds new height (otherwise, there's a rounding error)
            height = rowHeight * rows + paddingY;
        }

        /// <summary>
        /// Fills top row and col, weekend cells and marked cells
        /// </summary>
        /// <param name="g"></param>
        private static void DrawColor(Graphics g)
        {
            Brush fill = Brushes.Gray;

            //Fills top column
            Rectangle rectCol = new Rectangle(cornerX, cornerYTable, width, paddingY);
            g.FillRectangle(fill, rectCol);

            //Fills left row
            Rectangle rectRow = new Rectangle(cornerX, cornerYTable, paddingX, height);
            g.FillRectangle(fill, rectRow);

            //Fills weekends
            Point point = new Point(cornerX + paddingX + 5 * colWidth, cornerYTable + paddingY);
            Size size = new Size(width + cornerX - point.X, height - paddingY);
            Rectangle rectWeekend = new Rectangle(point, size);
            g.FillRectangle(Brushes.LightGray, rectWeekend);

            //Fills marked rect
            if (Global.selectedRectangles != null)
                foreach (Rectangle rect in Global.selectedRectangles)
                    g.FillRectangle(SystemBrushes.Highlight, rect);
        }

        /// <summary>
        /// Draw the outline of the calendar
        /// </summary>
        /// <param name="g"></param>
        private static void DrawOutline(Graphics g)
        {
            Pen black = Pens.Black;

            //Vertical lines
            {
                //Left line, week nr.
                Point x1 = new Point(cornerX, cornerYTable);
                Point x2 = new Point(cornerX, cornerYTable + height);
                g.DrawLine(black, x1, x2);

                //Right line, week nr.
                Point x3 = new Point(cornerX + paddingX, cornerYTable);
                Point x4 = new Point(cornerX + paddingX, cornerYTable + height);
                g.DrawLine(black, x3, x4);

                //Remaining lines
                for (int i = 1; i <= weekdays.Count; i++)
                {
                    Point point1 = new Point(cornerX + paddingX + colWidth * i, cornerYTable);
                    Point point2 = new Point(cornerX + paddingX + colWidth * i, cornerYTable + height);
                    g.DrawLine(black, point1, point2);
                }
            }

            //Horizontal lines
            {
                //Top line, weekdays
                Point x1 = new Point(cornerX, cornerYTable);
                Point x2 = new Point(cornerX + width, cornerYTable);
                g.DrawLine(black, x1, x2);

                //Bottom line, weekdays
                Point x3 = new Point(cornerX, cornerYTable + paddingY);
                Point x4 = new Point(cornerX + width, cornerYTable + paddingY);
                g.DrawLine(black, x3, x4);

                //Remaining lines
                for (int i = 1; i <= rows; i++)
                {
                    Point point1 = new Point(cornerX, cornerYTable + paddingY + rowHeight * i);
                    Point point2 = new Point(cornerX + width, cornerYTable + paddingY + rowHeight * i);
                    g.DrawLine(black, point1, point2);
                }
            }
        }

        /// <summary>
        /// Draws all text on the calendar
        /// </summary>
        /// <param name="g"></param>
        private static void DrawText(Graphics g)
        {
            FontSetup();
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            //Text formatting
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat sfInfo = new StringFormat { Alignment = StringAlignment.Far };

            Brush black = Brushes.Black;
            Brush gray = Brushes.Gray;
            Brush white = Brushes.White;

            string headline = Global.monthStr + Global.GetText("title");
            Point headlinePos = new Point((width + cornerX * 2) / 2, cornerY);
            g.DrawString(headline, ssFont, black, headlinePos, sf);

            //Draw business info ("ssInfo")
            string ssInfo = address + "\n" + tlf + "\n" + email + "\n" + website;
            g.DrawString(ssInfo, fontInfo, black, new Point(infoPosX, cornerY), sfInfo);

            //Draw weekdays
            for (int i = 0; i < weekdays.Count; i++)
            {
                Point pos = new Point(cornerX + paddingX + colWidth * i, cornerYTable);
                g.DrawString(weekdays.ElementAt(i), fontBold, white, pos);
            }

            //Draw week nr.
            for (int i = 0; i < rows; i++)
            {
                DateTime date = Global.dates[0].AddDays(7 * i);
                Point pos = new Point(cornerX, cornerYTable + paddingY + rowHeight * i);
                string weekNr = GetIso8601WeekOfYear(date).ToString();
                g.DrawString(weekNr, font, white, pos);
            }

            //Draw dates
            for (int i = 0; i < Global.datesArr.GetLength(0); i++)
                for (int j = 0; j < Global.datesArr.GetLength(1); j++)
                {
                    Point pos = new Point(cornerX + paddingX + colWidth * i, cornerYTable + paddingY + rowHeight * j);
                    DateTime date = Global.datesArr[i, j];

                    Brush brush;
                    if (date.Month == Global.monthInt)
                        brush = black;
                    else
                        brush = gray;

                    g.DrawString(date.Day.ToString("D"), font, brush, pos);
                }

            //Draw cell info (events and such)
            DrawCellInfo(g);

            //Draw adittional text (below the calendar)
            g.DrawString(Global.subtext1, fontSubtext, black, new Point(cornerX, cornerYTable + height));
            g.DrawString(Global.subtext2, fontSubtext, black, new Point(cornerX, cornerYTable + height + fontSize));
        }

        /// <summary>
        /// Draws the cell info
        /// </summary>
        /// <param name="g"></param>
        private static void DrawCellInfo(Graphics g)
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };

            //Checks font settings (black text is bold)
            //TODO: Add settings for choosing font
            if (Global.line1Color == Color.Black)
                Global.line1Font = fontBold;
            else
                Global.line1Font = font;

            if (Global.line2Color == Color.Black)
                Global.line2Font = fontBold;
            else
                Global.line2Font = font;

            if (Global.line3Color == Color.Black)
                Global.line3Font = fontBold;
            else
                Global.line3Font = font;

            //Loops through cells
            //TODO: Fix this mess
            for (int i = 0; i < Global.datesArr.GetLength(1); i++)
                for (int j = 0; j < Global.datesArr.GetLength(0); j++)
                {
                    int index = Global.ArrToListIndex(j, i);

                    //Draw eventual BigText
                    if (Global.bigText[index] && Global.line1[index] != "")
                    {
                        int jStart = j;
                        int indexStart = index;
                        float bigTextWidth;
                        int bigTextWidthTotal;
                        int bigTextCnt = 1;

                        while (j + 1 < Global.datesArr.GetLength(0) &&
                            Global.line1[indexStart] == Global.line1[index + 1] && Global.bigText[index + 1])
                            index = Global.ArrToListIndex(++j, i);

                        //Calculate the number of times to draw BigText
                        bigTextWidth = g.MeasureString(Global.line1[index], ssFont).Width;
                        bigTextWidthTotal = (index - indexStart + 1) * colWidth;
                        while (bigTextWidth * (bigTextCnt + 1) < bigTextWidthTotal)
                            bigTextCnt++;

                        for (int k = 1; k <= bigTextCnt; k++)
                        {
                            //Messy point calculation
                            float spacing = (bigTextWidthTotal - (bigTextWidth * bigTextCnt)) / (bigTextCnt + 1);
                            float x = cornerX + paddingX + colWidth * jStart + spacing * k + bigTextWidth * (k - 1) + bigTextWidth / 2;
                            int y = cornerYTable + paddingY + rowHeight * i + fontSize;

                            Point pos = new Point((int)x, y);
                            g.DrawString(Global.line1[index], ssFont, Brushes.Black, pos, sf);
                        }
                    }
                    else //If no BigText
                    {
                        string[] text = new string[3];

                        while (Global.lineCopyPrev[index] && index >= 7)
                            index -= 7;

                        text[0] = Global.line1[index];
                        text[1] = Global.line2[index];
                        text[2] = Global.line3[index];

                        Point pos1 = new Point(cornerX + paddingX + colWidth * j, cornerYTable + paddingY + rowHeight * i + fontSize);
                        Point pos2 = new Point(cornerX + paddingX + colWidth * j, cornerYTable + paddingY + rowHeight * i + fontSize * 2);
                        Point pos3 = new Point(cornerX + paddingX + colWidth * j, cornerYTable + paddingY + rowHeight * i + fontSize * 3);
                        g.DrawString(text[0], Global.line1Font, new SolidBrush(Global.line1Color), pos1);
                        g.DrawString(text[1], Global.line2Font, new SolidBrush(Global.line2Color), pos2);
                        g.DrawString(text[2], Global.line3Font, new SolidBrush(Global.line3Color), pos3);
                    }
                }
        }

        /// <summary>
        /// Sets up fonts
        /// </summary>
        private static void FontSetup()
        {
            ssFont = new Font(Global.pfc.Families[0], headlineSize);
            font = new Font(fontName, fontSize);
            fontBold = new Font(font, FontStyle.Bold);
            fontInfo = new Font(fontName, infoSize);

            if (Global.subtext2 == "")
                fontSubtext = font;
            else
                fontSubtext = new Font(fontName, fontSize * 2 / 3);
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            try
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }
            catch
            {
                return new Bitmap(image);
            }
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        /// <summary>
        /// Calculate the week nr.
        /// </summary>
        /// <param name="time">Day/week to get week nr. of</param>
        /// <returns>Week nr.</returns>
        private static int GetIso8601WeekOfYear(DateTime time)
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
    }
}