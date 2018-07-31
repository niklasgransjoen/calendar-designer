using CalendarDesigner.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace CalendarDesigner
{
    public static class DrawClass
    {
        private const int startX = 20;
        private const int startY = 20;
        private const int startCalY = 80;
        private const int botPadding = 30;
        private const int weekColWidth = 29;
        private const int weekRowHeight = 20;
        private const int cellWidth = 75;

        private static int height;

        // Colors

        public enum Colors { Black, Gray, White }

        public static SolidBrush Black { get; set; } = new SolidBrush(Color.Black);
        public static SolidBrush Gray { get; set; } = new SolidBrush(Color.Gray);
        public static SolidBrush White { get; set; } = new SolidBrush(Color.White);

        public static List<string> ColorStr { get; } = new List<string>() { text.Black, text.Gray };
        public static List<SolidBrush> ColorBrush { get; } = new List<SolidBrush>() { Black, Gray };

        // Fonts

        private const string fontName = "Calibri";
        private const int fontSize = 12;
        private const int fontSizeHeadline = 24;
        private const int fontSizeSubtext = 8;
        private const int fontSizeAuthor = 6;

        public enum Font { Standard }

        /// <summary>
        /// Gets the width of the calendar.
        /// </summary>
        public static int Width => Global.PicBox.Width * Draw.Multiplier - StartX * 2;

        /// <summary>
        /// Gets the height of the calendar.
        /// </summary>
        public static int Height => height * Draw.Multiplier;

        /// <summary>
        /// Gets the x-coordinate to draw the business info on.
        /// </summary>
        public static int BusinessInfoX => Global.PicBox.Width * Draw.Multiplier - StartX;

        /// <summary>
        /// Gets the x-coordinate of the upper right corner of the calendar.
        /// </summary>
        public static int StartX => startX * Draw.Multiplier;

        /// <summary>
        /// Gets the y-coordinate of the upper right corner of the image (with padding).
        /// </summary>
        public static int StartY => startY * Draw.Multiplier;

        /// <summary>
        /// Gets the y-coordinate of the upper right corner of the image.
        /// </summary>
        public static int StartCalY => startCalY * Draw.Multiplier;

        /// <summary>
        /// Gets the spacing between the bottom of the calendar and the end of the image.
        /// </summary>
        public static int BotPadding => botPadding * Draw.Multiplier;

        /// <summary>
        /// Gets the height of the weekday row.
        /// </summary>
        public static int WeekRowHeight => weekRowHeight * Draw.Multiplier;

        /// <summary>
        /// Gets the width of the week nr. column.
        /// </summary>
        public static int WeekColWidth => weekColWidth * Draw.Multiplier;

        /// <summary>
        /// Gets the width of a cell.
        /// </summary>
        public static int CellWidth => cellWidth * Draw.Multiplier;

        /// <summary>
        /// Gets the height of a row.
        /// </summary>
        public static int CellHeight => Draw.CellHeight * Draw.Multiplier;

        /// <summary>
        /// Gets the font name.
        /// </summary>
        public static string FontName => fontName;

        /// <summary>
        /// Gets the standard font size.
        /// </summary>
        public static int FontSize => fontSize * Draw.Multiplier;

        /// <summary>
        /// Gets the font size for the headline.
        /// </summary>
        public static int FontSizeHeadline => fontSizeHeadline * Draw.Multiplier;

        /// <summary>
        /// Gets the font size of the subtext.
        /// </summary>
        public static int FontSizeSubtext => fontSizeSubtext * Draw.Multiplier;

        /// <summary>
        /// Gets the font size of the author info.
        /// </summary>
        public static int FontSizeAuthor => fontSizeAuthor * Draw.Multiplier;

        //// Methods ////

        /// <summary>
        /// Sets the height of the calendar.
        /// </summary>
        /// <param name="height">The height to set the calendar to.</param>
        public static void SetHeight(int height) => DrawClass.height = height;
    }
}