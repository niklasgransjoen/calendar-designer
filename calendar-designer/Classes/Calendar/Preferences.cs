using System.Drawing;
using System.IO;

namespace CalendarDesigner
{
    public class Preferences
    {

        public enum Languages { Norwegian, English }

        /// <summary>
        /// Gets or sets the language of this software.
        /// </summary>
        public Languages Language { get; set; } = Languages.Norwegian;

        /// <summary>
        /// Gets or sets the color of the first line of a cell.
        /// </summary>
        public DrawClass.Colors Line1Color { get; set; } = DrawClass.Colors.Black;

        /// <summary>
        /// Gets or sets the color of the second line of a cell.
        /// </summary>
        public DrawClass.Colors Line2Color { get; set; } = DrawClass.Colors.Black;

        /// <summary>
        /// Gets or sets the color of the third line of a cell.
        /// </summary>
        public DrawClass.Colors Line3Color { get; set; } = DrawClass.Colors.Gray;

        /// <summary>
        /// Gets or sets the font of the first line of a cell.
        /// </summary>
        public DrawClass.Font Line1Font { get; set; } = DrawClass.Font.Standard;

        /// <summary>
        /// Gets or sets the font of the second line of a cell.
        /// </summary>
        public DrawClass.Font Line2Font { get; set; } = DrawClass.Font.Standard;

        /// <summary>
        /// Gets or sets the font of the third line of a cell.
        /// </summary>
        public DrawClass.Font Line3Font { get; set; } = DrawClass.Font.Standard;

        /// <summary>
        /// Reads settings if there are any.
        /// </summary>
        public static void Read()
        {
            if (File.ReadFile(Text.SoftwareFolder + Text.SettingsFileName, out Preferences preferences, false))
                Global.Preferences = preferences;
            else
                Global.Preferences = new Preferences();
        }

        /// <summary>
        /// Writes the current settings.
        /// </summary>
        public static void Write()
        {
            if (!Directory.Exists(Text.SoftwareFolder))
                Directory.CreateDirectory(Text.SoftwareFolder);

            File.WriteFile(Global.Preferences, Text.SoftwareFolder + Text.SettingsFileName);
        }
    }
}