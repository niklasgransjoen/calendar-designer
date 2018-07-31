using System;
using System.Drawing;
using System.Linq;

namespace CalendarDesigner
{
    /// <summary>
    /// Used for drawing the info of the calendar.
    /// </summary>
    public static class DrawInfo
    {
        // Fonts //

        public static Font ssFont;
        public static Font font;
        public static Font fontBold;
        public static Font fontInfo;
        public static Font fontSubtext;
        public static Font fontAuthor;

        // Text formatting //

        private static StringFormat Sf { get; } = new StringFormat { Alignment = StringAlignment.Center };
        private static StringFormat SfInfo { get; } = new StringFormat { Alignment = StringAlignment.Far };

        /// <summary>
        /// Draws the info of the calendar.
        /// </summary>
        public static void Draw(Graphics g)
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            DrawBusinessInfo(g);
            DrawBaseInfo(g);
            DrawCellInfo(g);
            DrawAuthorInfo(g);
        }

        /// <summary>
        /// Draws business info, sub text.
        /// </summary>
        private static void DrawBusinessInfo(Graphics g)
        {
            Calendar calendar = Global.Calendar;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int width = DrawClass.Width;
            int height = DrawClass.Height;

            int cellWidth = DrawClass.CellWidth;
            int weekColWidth = DrawClass.WeekColWidth;
            int weekRowHeight = DrawClass.WeekRowHeight;

            Brush black = DrawClass.Black;

            string headline = calendar.MonthName + " " + Text.BusinessTitle;
            Point headlinePos = new Point((width + x * 2) / 2, DrawClass.StartY);
            g.DrawString(headline, ssFont, black, headlinePos, Sf);

            //Draw business info ("ssInfo")
            string ssInfo =
                Text.BusinessInfo1 + "\n" +
                Text.BusinessInfo2 + "\n" +
                Text.BusinessInfo3 + "\n" +
                Text.BusinessInfo4;

            g.DrawString(ssInfo, fontInfo, black, new Point(DrawClass.BusinessInfoX, DrawClass.StartY), SfInfo);

            //Draw adittional text (below the calendar)
            g.DrawString(calendar.Subtext1, fontSubtext, black, new Point(x, y + height));
            g.DrawString(calendar.Subtext2, fontSubtext, black, new Point(x, y + height + DrawClass.FontSize));
        }

        /// <summary>
        /// Draws the base info (dates, week nr.) onto the calendar.
        /// </summary>
        private static void DrawBaseInfo(Graphics g)
        {
            Calendar calendar = Global.Calendar;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int width = DrawClass.Width;
            int height = DrawClass.Height;

            int cellWidth = DrawClass.CellWidth;
            int weekColWidth = DrawClass.WeekColWidth;
            int weekRowHeight = DrawClass.WeekRowHeight;

            Brush black = DrawClass.Black;
            Brush gray = DrawClass.Gray;
            Brush white = DrawClass.White;

            //Draw weekdays
            for (int i = 0; i < Calendar.Weekdays.Count; i++)
            {
                Point pos = new Point(x + weekColWidth + cellWidth * i, y);
                g.DrawString(Calendar.Weekdays[i], fontBold, white, pos);
            }

            //Draw week nr.
            for (int i = 0; i < CalendarDesigner.Draw.Rows; i++)
            {
                DateTime date = calendar.Dates.First().Time.AddDays(Calendar.Weekdays.Count * i);
                Point pos = new Point(x, y + weekRowHeight + DrawClass.CellHeight * i);
                string weekNr = Calendar.GetIso8601WeekOfYear(date).ToString();
                g.DrawString(weekNr, font, white, pos);
            }

            //Draw dates
            foreach (Date date in calendar.Dates)
            {
                Brush brush = (date.Time.Month == calendar.Month ? black : gray);
                g.DrawString(date.Time.Day.ToString("D"), font, brush, date.TopLeft);
            }
        }

        /// <summary>
        /// Draws the cell info.
        /// </summary>
        private static void DrawCellInfo(Graphics g)
        {
            Calendar calendar = Global.Calendar;
            Preferences preferences = Global.Preferences;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int weekColWidth = DrawClass.WeekColWidth;
            int cellWidth = DrawClass.CellWidth;
            int cellHeight = DrawClass.CellHeight;

            //Checks font settings (black text is bold)
            Font line1Font = (preferences.Line1Color == DrawClass.Colors.Black ? fontBold : font);
            Font line2Font = (preferences.Line2Color == DrawClass.Colors.Black ? fontBold : font);
            Font line3Font = (preferences.Line3Color == DrawClass.Colors.Black ? fontBold : font);

            //Loops through cells
            for (int i = 0; i < calendar.Dates.Count; i++)
            {
                Date date = calendar.Dates[i];

                //Check for and draw eventual bigtext. If not, fill cell.
                if (!DrawBigText(g, i, out i))
                {
                    int index = i;
                    Date dateCopy = date;
                    while (dateCopy.CopyPrev && index >= 7)
                    {
                        index -= 7;
                        dateCopy = calendar.Dates[index];
                    }

                    Point pos1 = date.TopLeft + new Size(0, DrawClass.FontSize);
                    Point pos2 = date.TopLeft + new Size(0, DrawClass.FontSize * 2);
                    Point pos3 = date.TopLeft + new Size(0, DrawClass.FontSize * 3);

                    g.DrawString(dateCopy.Line1, line1Font, DrawClass.ColorBrush[(int)preferences.Line1Color], pos1);
                    g.DrawString(dateCopy.Line2, line2Font, DrawClass.ColorBrush[(int)preferences.Line2Color], pos2);
                    g.DrawString(dateCopy.Line3, line3Font, DrawClass.ColorBrush[(int)preferences.Line3Color], pos3);
                }
            }
        }

        /// <summary>
        /// Draws the BigText for this and all folowing cells on the same row.
        /// </summary>
        /// <param name="index">The index of the cell to draw BigText for.</param>
        /// <param name="newIndex">The index of the last cell drawn BigText on (if no BigText, returns index).</param>
        private static bool DrawBigText(Graphics g, int index, out int newIndex)
        {
            Calendar calendar = Global.Calendar;
            Date date = calendar.Dates[index];
            newIndex = index;

            // Return if there's no BigText.
            if (!date.BigText || date.Line1 == "")
                return false;

            int x = DrawClass.StartX;
            int y = DrawClass.StartY;
            int weekColWidth = DrawClass.WeekColWidth;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int cellWidth = DrawClass.CellWidth;
            int cellHeight = DrawClass.CellHeight;

            // Merge all BigText cells with the same text.
            if (newIndex != calendar.Dates.Count - 1)
                while (date.Line1 == calendar.Dates[newIndex + 1].Line1 && calendar.Dates[newIndex + 1].BigText)
                {
                    if (newIndex % Calendar.Weekdays.Count == Calendar.Weekdays.Count - 1)
                        break;

                    newIndex++;

                    if (newIndex == calendar.Dates.Count - 1)
                        break;
                }

            // Calculate the number of times to draw BigText.
            float bigTextWidth = g.MeasureString(calendar.Dates[newIndex].Line1, ssFont).Width;
            int bigTextWidthTotal = (newIndex - index + 1) * cellWidth;

            int bigTextCnt = 1;
            while (bigTextWidth * (bigTextCnt + 1) < bigTextWidthTotal)
                bigTextCnt++;

            for (int i = 1; i <= bigTextCnt; i++)
            {
                float spacing = (bigTextWidthTotal - (bigTextWidth * bigTextCnt)) / (bigTextCnt + 1);

                Point pos = new Point(
                (int)(date.TopLeft.X + spacing * i + bigTextWidth * (i - 1) + bigTextWidth / 2),
                date.TopLeft.Y + cellHeight);

                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                g.DrawString(calendar.Dates[newIndex].Line1, ssFont, DrawClass.Black, pos, sf);
            }

            return true;
        }

        /// <summary>
        /// Draws the author info in the bottom right corner.
        /// </summary>
        private static void DrawAuthorInfo(Graphics g)
        {
            Calendar calendar = Global.Calendar;

            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            string text = Text.AuthorInfo1 + "\n" + Text.AuthorInfo2;
            Point point = calendar.Dates.Last().BotRight;
            g.DrawString(text, fontAuthor, DrawClass.Black, point, sf);
        }

        /// <summary>
        /// Sets up fonts.
        /// </summary>
        public static void FontSetup()
        {
            ssFont = new Font(Global.Pfc.Families[0], DrawClass.FontSizeHeadline);
            font = new Font(DrawClass.FontName, DrawClass.FontSize);
            fontBold = new Font(font, FontStyle.Bold);
            fontInfo = new Font(DrawClass.FontName, DrawClass.FontSizeSubtext);
            fontAuthor = new Font(DrawClass.FontName, DrawClass.FontSizeAuthor);

            if (Global.Calendar.Subtext2 == "")
                fontSubtext = font;
            else
                fontSubtext = fontInfo;
        }
    }
}