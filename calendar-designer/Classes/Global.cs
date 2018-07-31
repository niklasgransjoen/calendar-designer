using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public static class Global
    {
        /// <summary>
        /// Gets the version of the software.
        /// </summary>
        public const string Version = "1.3.0";

        /// <summary>
        /// Gets the version of the settings file.
        /// </summary>
        public const string SettingsVer = "1.0.0";

        /// <summary>
        /// Gets or sets the mainform.
        /// </summary>
        public static MainForm MainForm { get; set; }

        /// <summary>
        /// Gets or sets the picbox.
        /// </summary>
        public static PictureBox PicBox => MainForm.picBox;

        /// <summary>
        /// Gets or sets the shown tip.
        /// </summary>
        public static string Tip
        {
            get => MainForm.Tips.Text;
            set => MainForm.Tips.Text = value;
        }

        /// <summary>
        /// Gets or sets the font collection.
        /// <para>Used for custom font.</para>
        /// </summary>
        public static PrivateFontCollection Pfc { get; set; } = new PrivateFontCollection();

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
        public static void Reset()
        {
            Selection.SelectedCells.Clear();
            Preferences.Read();
            Saved = true;
            Path = null;
        }
    }
}