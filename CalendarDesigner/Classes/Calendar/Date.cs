using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CalendarDesigner
{
    /// <summary>
    /// A date object, one of a calendar's cells.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// The index of the top left corner of this date cell in its point array.
        /// </summary>
        public const int indexTopLeft = 0;

        /// <summary>
        /// The index of the top right corner of this date cell in its point array.
        /// </summary>
        public const int indexTopRight = 1;

        /// <summary>
        /// The index of the bot right corner of this date cell in its point array.
        /// </summary>
        public const int indexBotRight = 2;

        /// <summary>
        /// The index of the bot left corner of this date cell in its point array.
        /// </summary>
        public const int indexBotLeft = 3;

        /// <summary>
        /// The size of the points array.
        /// </summary>
        public const int pointsSize = indexBotLeft + 1;

        /// <summary>
        /// Creates a new instance of the Date object.
        /// </summary>
        /// <param name="time">The date of this date object.</param>
        public Date(DateTime time)
        {
            Time = time;
            Events.AddRange(new List<string> { "", "", "" });
        }

        /// <summary>
        /// Empty constructor for use with deserialization.
        /// </summary>
        public Date()
        {
        }

        /// <summary>
        /// Gets or sets the time of this date.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the text of the first line of this date.
        /// </summary>
        public List<string> Events { get; } = new List<string>(3);

        /// <summary>
        /// Gets or sets whether this date should copy the text of the previous one.
        /// <para>Invalid to set this for the first seven dates of a month.</para>
        /// </summary>
        public bool CopyPrev { get; set; }

        /// <summary>
        /// Gets or sets whether this date should only display the first line as BigText.
        /// </summary>
        public bool BigText { get; set; }

        /// <summary>
        /// Gets or sets whether this date's text should wrap around if it's too long for its cell.
        /// </summary>
        public bool WrapText { get; set; } = true;

        /// <summary>
        /// Gets or sets the points of this date cell.
        /// </summary>
        [XmlIgnore]
        public Point[] Points { get; set; } = new Point[pointsSize];

        /// <summary>
        /// Gets or sets the top left corner of this date cell.
        /// </summary>
        public Point TopLeft => Points[indexTopLeft];

        /// <summary>
        /// Gets or sets the top right corner of this date cell.
        /// </summary>
        public Point TopRight => Points[indexTopRight];

        /// <summary>
        /// Gets or sets the bot right corner of this date cell.
        /// </summary>
        public Point BotRight => Points[indexBotRight];

        /// <summary>
        /// Gets or sets the bot left corner of this date cell.
        /// </summary>
        public Point BotLeft => Points[indexBotLeft];

        /// <summary>
        /// Gets or sets the rectangle defined by this date's cell's points.
        /// </summary>
        [XmlIgnore]
        public Rectangle Rect { get; set; }

        /// <summary>
        /// Gets or sets the Selected flag for this date's cell.
        /// </summary>
        [XmlIgnore]
        public bool Selected { get; set; } = false;
    }
}