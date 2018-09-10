using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calendar_designer
{
    /// <summary>
    /// Used for drawing the info of the calendar.
    /// </summary>
    public static class DrawInfo
    {
        /// <summary>
        /// Gets or sets the special font.
        /// </summary>
        private static FontFamily SpecialFont { get; set; }

        /// <summary>
        /// Gets or sets the standard font.
        /// </summary>
        private static FontFamily Font { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        private static TextBlock Title { get; set; }

        /// <summary>
        /// Gets or sets the business info.
        /// </summary>
        private static TextBlock BusinessInfo { get; set; }

        /// <summary>
        /// Gets or sets the subtext.
        /// </summary>
        private static TextBlock Subtext { get; set; }

        /// <summary>
        /// Gets or sets the weekdays.
        /// </summary>
        private static List<UIElement> Weekdays { get; set; }

        /// <summary>
        /// Gets or sets the week numbers.
        /// </summary>
        private static List<UIElement> WeekNumbers { get; set; }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        private static List<UIElement> Dates { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        private static List<UIElement> Events { get; set; }

        /// <summary>
        /// Gets or sets the author info.
        /// </summary>
        private static TextBlock AuthorInfo { get; set; }

        /// <summary>
        /// Draws the info of the calendar.
        /// </summary>
        public static void _Draw()
        {
            Draw.Add(Title);
            Draw.Add(BusinessInfo);
            Draw.Add(Subtext);
            Draw.Add(Weekdays);
            Draw.Add(WeekNumbers);
            Draw.Add(Dates);
            Draw.Add(Events);
            Draw.Add(AuthorInfo);
        }

        /// <summary>
        /// Calculates the info of the calendar.
        /// </summary>
        public static void Setup()
        {
            FontSetup();
            HeaderSetup();
            BaseSetup();
            SubtextSetup();
            EventSetup();
            AuthorSetup();
        }

        /// <summary>
        /// Sets up fonts.
        /// </summary>
        private static void FontSetup()
        {
            SpecialFont = new FontFamily(new Uri("pack://application:,,,/"), "./Resources/#Candlescript Demo Version");
            Font = new FontFamily(DrawClass.FontName);
        }

        /// <summary>
        /// Sets up the title, business info.
        /// </summary>
        public static void HeaderSetup()
        {
            Calendar calendar = Global.Calendar;

            int x = DrawClass.StartX;
            int y = DrawClass.StartY;
            int width = DrawClass.Width;

            string title = calendar.MonthName + " " + Text.BusinessTitleSuffix;
            double titleWidth = DrawClass.MeasureString(title, SpecialFont, DrawClass.FontSizeTitle).Width;

            Title = new TextBlock
            {
                Text = title,
                FontFamily = SpecialFont,
                FontSize = DrawClass.FontSizeTitle
            };
            Draw.Position(Title, (width - titleWidth) / 2 + x, y);

            // Draw business info.
            string businessInfo =
                Text.BusinessInfo1 + "\n" +
                Text.BusinessInfo2 + "\n" +
                Text.BusinessInfo3 + "\n" +
                Text.BusinessInfo4;

            double businessInfoWidth = DrawClass.MeasureString(businessInfo, Font, DrawClass.FontSizeInfo).Width;

            BusinessInfo = new TextBlock
            {
                Text = businessInfo,
                FontFamily = Font,
                FontSize = DrawClass.FontSizeInfo,
                TextAlignment = TextAlignment.Right
            };
            Draw.Position(BusinessInfo, DrawClass.BusinessInfoX - businessInfoWidth, y);
        }

        /// <summary>
        /// Sets up the Subtext.
        /// </summary>
        public static void SubtextSetup()
        {
            int x = DrawClass.StartX;
            int height = DrawClass.Height;

            Calendar calendar = Global.Calendar;
            string subtext = calendar.Subtext1 + "\n" + calendar.Subtext2;

            Subtext = new TextBlock
            {
                Text = subtext,
                FontFamily = Font,
                FontSize = DrawClass.FontSizeSubtext
            };
            Draw.Position(Subtext, x, DrawClass.StartCalY + height);
        }

        /// <summary>
        /// Sets up the base info (weekday, weeknr, dates).
        /// </summary>
        private static void BaseSetup()
        {
            Weekdays = new List<UIElement>();
            WeekNumbers = new List<UIElement>();
            Dates = new List<UIElement>();

            Calendar calendar = Global.Calendar;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int padding = DrawClass.Padding;

            Brush black = Brushes.Black;
            Brush gray = Brushes.Gray;
            Brush white = Brushes.White;

            //Draw weekdays
            for (int i = 0; i < Calendar.Weekdays.Count; i++)
            {
                Point pos = new Point(x + DrawClass.WeekColWidth + DrawClass.CellWidth * i + padding, y);

                TextBlock weekday = new TextBlock
                {
                    Text = Calendar.Weekdays[i],
                    FontFamily = Font,
                    FontSize = DrawClass.FontSize,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White
                };
                Draw.Position(weekday, pos);

                Weekdays.Add(weekday);
            }

            //Draw week nr.
            for (int i = 0; i < Draw.Rows; i++)
            {
                DateTime date = calendar.Dates.First().Time.AddDays(Calendar.Weekdays.Count * i);
                Point pos = new Point(x + padding, y + DrawClass.WeekRowHeight + DrawClass.CellHeight * i);

                TextBlock weekNr = new TextBlock
                {
                    Text = Calendar.GetIso8601WeekOfYear(date).ToString(),
                    FontFamily = Font,
                    FontSize = DrawClass.FontSize,
                    Foreground = Brushes.White,
                };
                Draw.Position(weekNr, pos);

                WeekNumbers.Add(weekNr);
            }

            //Draw dates
            foreach (Date date in calendar.Dates)
            {
                Brush brush = (date.Time.Month == calendar.Month ? black : gray);
                Point pos = new Point(date.TopLeft.X + padding, date.TopLeft.Y);

                TextBlock txtDate = new TextBlock
                {
                    Text = date.Time.Day.ToString("D"),
                    FontFamily = Font,
                    FontSize = DrawClass.FontSize,
                    Foreground = brush
                };
                Draw.Position(txtDate, pos);

                Dates.Add(txtDate);
            }
        }

        /// <summary>
        /// Sets up the event info.
        /// </summary>
        public static void EventSetup()
        {
            Events = new List<UIElement>();

            Calendar calendar = Global.Calendar;
            Preferences preferences = calendar.Preferences;
            List<Date> dates = calendar.Dates;

            int x = DrawClass.StartX;
            int y = DrawClass.StartCalY;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int weekColWidth = DrawClass.WeekColWidth;
            int cellWidth = DrawClass.CellWidth;
            int cellHeight = DrawClass.CellHeight;

            // Loops through the calendar's dates.
            for (int i = 0; i < dates.Count; i++)
            {
                Date date = dates[i];

                //Check for and draw eventual bigtext. If not, fill cell.
                if (DrawBigText(i, out i))
                    continue;

                int index = i;
                Date dateCopyFrom = date;
                while (dateCopyFrom.CopyPrev && index >= 7)
                {
                    index -= 7;
                    dateCopyFrom = dates[index];
                }

                // Loops through the cell's three lines.
                for (int j = 0; j < dateCopyFrom.Events.Count; j++)
                {
                    int color = (int)preferences.LineColor[j];

                    TextBlock txtEvent = new TextBlock
                    {
                        Text = dateCopyFrom.Events[j],
                        FontFamily = Font,
                        FontSize = DrawClass.FontSize,
                        FontWeight = DrawClass.FontWeight[color],
                        Foreground = DrawClass.ColorBrush[color],
                    };

                    Draw.Position(txtEvent, date.TopLeft.X + DrawClass.Padding, date.TopLeft.Y + DrawClass.FontSize * (j + 1));

                    if (dateCopyFrom.WrapText)
                        AdjustTextSize(txtEvent);

                    Events.Add(txtEvent);
                }
            }
        }

        /// <summary>
        /// Draws the BigText for this and all folowing cells on the same row.
        /// </summary>
        /// <param name="index">The index of the cell to draw BigText for.</param>
        /// <param name="newIndex">The index of the last cell drawn BigText on (if no BigText, returns index).</param>
        private static bool DrawBigText(int index, out int newIndex)
        {
            Calendar calendar = Global.Calendar;
            Date date = calendar.Dates[index];
            newIndex = index;

            string bigTextStr = date.Events.First();

            // Return if there's no BigText.
            if (!date.BigText || bigTextStr == "")
                return false;

            int weekColWidth = DrawClass.WeekColWidth;
            int weekRowHeight = DrawClass.WeekRowHeight;
            int cellWidth = DrawClass.CellWidth;
            int cellHeight = DrawClass.CellHeight;

            // Merge all BigText cells with the same text.
            if (newIndex != calendar.Dates.Count - 1)
                while (bigTextStr == calendar.Dates[newIndex + 1].Events.First() && calendar.Dates[newIndex + 1].BigText)
                {
                    if (newIndex % Calendar.Weekdays.Count == Calendar.Weekdays.Count - 1)
                        break;

                    newIndex++;

                    if (newIndex == calendar.Dates.Count - 1)
                        break;
                }

            // Calculate the number of times to draw BigText.
            double bigTextWidth = DrawClass.MeasureString(bigTextStr, SpecialFont, DrawClass.FontSizeTitle).Width;
            int bigTextWidthTotal = (newIndex - index + 1) * cellWidth;

            int bigTextCnt = 1;
            while (bigTextWidth * (bigTextCnt + 1) < bigTextWidthTotal)
                bigTextCnt++;

            for (int i = 1; i <= bigTextCnt; i++)
            {
                double spacing = (bigTextWidthTotal - (bigTextWidth * bigTextCnt)) / (bigTextCnt + 1);

                int x = (int)(date.TopLeft.X + spacing * i + bigTextWidth * (i - 1));
                int y = (int)(date.TopLeft.Y);

                TextBlock bigText = new TextBlock
                {
                    Text = bigTextStr,
                    FontFamily = SpecialFont,
                    FontSize = DrawClass.FontSizeTitle,
                    TextAlignment = TextAlignment.Center,
                };
                Draw.Position(bigText, x, y);

                Events.Add(bigText);
            }

            return true;
        }

        /// <summary>
        /// Adjusts the text size of the event to get make sure it doesn't overflow downward.
        /// </summary>
        private static void AdjustTextSize(TextBlock txtEvent)
        {
            if (txtEvent.Text == "")
                return;

            txtEvent.TextWrapping = TextWrapping.Wrap;
            txtEvent.Width = DrawClass.CellWidth;

            // We add some margin, due to the linebreaks being sub-optimal (break at spacings, not max line length).
            const double margin = .25;

            // Check if the text has to be reduced in size.
            double width = DrawClass.MeasureString(txtEvent.Text, txtEvent.FontFamily, DrawClass.FontSize).Width;
            if (width > DrawClass.CellWidth)
            {
                int lines = (int)Math.Ceiling(width / DrawClass.CellWidth);

                // Calculate a divider for reducing the text in size, while attempting to keep the maximum number of lines.
                double divider = Math.Ceiling(1 + (lines * DrawClass.FontSize) / (double)DrawClass.CellHeight + margin);
                txtEvent.FontSize /= divider;
            }
        }

        /// <summary>
        /// Sets up the author info.
        /// </summary>
        private static void AuthorSetup()
        {
            string text = Text.AuthorInfo1 + "\n" + Text.AuthorInfo2;

            AuthorInfo = new TextBlock
            {
                Text = text,
                FontFamily = Font,
                FontSize = DrawClass.FontSizeAuthor,
                TextAlignment = TextAlignment.Right
            };

            Point point = Global.Calendar.Dates.Last().BotRight;
            int textWidth = (int)DrawClass.MeasureString(text, Font, DrawClass.FontSizeAuthor).Width;

            Draw.Position(AuthorInfo, point.X - textWidth, point.Y);
        }
    }
}