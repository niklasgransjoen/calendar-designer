using System.Windows.Controls;

namespace CalendarDesigner
{
    public static class Global
    {
        /// <summary>
        /// Gets the version of the software.
        /// </summary>
        public const string Version = "2.0.0";

        /// <summary>
        /// Gets or sets the mainform.
        /// </summary>
        public static MainWindow MainWindow { get; set; }

        /// <summary>
        /// Gets or sets the picbox.
        /// </summary>
        public static Canvas Canvas => MainWindow.canvas;

        /// <summary>
        /// Gets or sets the shown tip.
        /// </summary>
        public static string Tip
        {
            get => (string)MainWindow.Tips.Content;
            set => MainWindow.Tips.Content = value;
        }

        /// <summary>
        /// Gets or sets the current calendar.
        /// </summary>
        public static Calendar Calendar { get; set; }

        /// <summary>
        /// Gets or sets the current preferences.
        /// </summary>
        public static Preferences Preferences { get; set; }

        /// <summary>
        /// Gets or sets the saved flag for the current calendar.
        /// </summary>
        public static bool Saved { get; set; }

        /// <summary>
        /// Gets or sets the path of the current calendar.
        /// </summary>
        public static string Path { get; set; }

        /// <summary>
        /// Clears the current global data, including selection, the saved flag, and calendar path.
        /// </summary>
        public static void ResetCalendarData()
        {
            Selection.SelectedCells.Clear();
            Saved = true;
            Path = null;
        }
    }
}