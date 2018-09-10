using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Calendar_designer
{
    public class Preferences
    {
        public enum Languages { Norwegian, English }

        private readonly List<string> Culture = new List<string> { "no-NO", "en-US" };

        public Preferences(bool useStandardSet)
        {
            if (useStandardSet)
            {
                LineColor.Add(DrawClass.Colors.Black);
                LineColor.Add(DrawClass.Colors.Black);
                LineColor.Add(DrawClass.Colors.Gray);
            }
        }

        public Preferences()
        {
        }

        /// <summary>
        /// Gets or sets the language of this software.
        /// </summary>
        public Languages Language { get; set; } = Languages.Norwegian;

        /// <summary>
        /// Gets or sets the color of the first line of a cell.
        /// </summary>
        public List<DrawClass.Colors> LineColor { get; set; } = new List<DrawClass.Colors>(3);

        /// <summary>
        /// Sets the current culture for this application.
        /// </summary>
        public void SetCulture() => Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture[(int)Language]);

        /// <summary>
        /// Reads preferences if there are any.
        /// <para>Returns the defualt preferences if there are none available.</para>
        /// </summary>
        public static Preferences Read()
        {
            if (!File.ReadFile(Text.SoftwareFolder + Text.SettingsFileName, out Preferences preferences, showError: false))
                preferences = new Preferences(useStandardSet: true);

            // Set the language of the application
            preferences.SetCulture();

            return preferences;
        }

        /// <summary>
        /// Writes the current settings.
        /// </summary>
        public static void Write()
        {
            if (!Directory.Exists(Text.SoftwareFolder))
                Directory.CreateDirectory(Text.SoftwareFolder);

            File.WriteFile(Global.Calendar.Preferences, Text.SoftwareFolder + Text.SettingsFileName);
        }
    }
}