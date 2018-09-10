using Calendar_designer.Properties;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Calendar_designer
{
    public static class DrawClass
    {
        private const int canvasWidth = 594;
        private const int canvasHeight = 420;

        private const int startX = 20;
        private const int startY = 20;
        private const int startCalY = 80;
        private const int padding = 2;
        private const int botPadding = 30;
        private const int weekColWidth = 29;
        private const int weekRowHeight = 20;
        private const int cellWidth = 75;

        private static int height;

        // Colors

        public enum Colors { Black, Gray }

        public static List<string> ColorStr { get; } = new List<string> { text.Black, text.Gray };
        public static List<Brush> ColorBrush { get; } = new List<Brush> { Brushes.Black, Brushes.Gray };

        // Fonts

        private const string fontName = "Calibri";
        private const int fontSize = 12;
        private const int fontSizeTitle = 36;
        private const int fontSizeInfo = 10;
        private const int fontSizeSubtext = 10;
        private const int fontSizeAuthor = 6;

        public static List<FontWeight> FontWeight { get; } = new List<FontWeight> { FontWeights.Bold, FontWeights.Normal };

        /// <summary>
        /// Gets the height of the canvas.
        /// </summary>
        public static int CanvasHeight => canvasHeight * Draw.Multiplier;

        /// <summary>
        /// Gets the width of the canvas.
        /// </summary>
        public static int CanvasWidth => canvasWidth * Draw.Multiplier;

        /// <summary>
        /// Gets the width of the calendar.
        /// </summary>
        public static int Width => CanvasWidth - StartX * 2;

        /// <summary>
        /// Gets the height of the calendar.
        /// </summary>
        public static int Height => height;

        /// <summary>
        /// Gets the x-coordinate to draw the business info on.
        /// </summary>
        public static int BusinessInfoX => CanvasWidth - StartX;

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
        /// Gets the standard padding for text.
        /// </summary>
        public static int Padding => padding * Draw.Multiplier;

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
        public static int CellHeight => Draw.CellHeight;

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
        public static int FontSizeTitle => fontSizeTitle * Draw.Multiplier;

        /// <summary>
        /// Gets the font size for information.
        /// </summary>
        public static int FontSizeInfo => fontSizeInfo * Draw.Multiplier;

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

        /// <summary>
        /// Returns the size of a string.
        /// </summary>
        /// <param name="candidate">The string to measure.</param>
        public static Size MeasureString(string candidate, FontFamily fontFamily, double fontSize)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(fontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                fontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);

            return new Size(formattedText.Width, formattedText.Height);
        }
    }
}