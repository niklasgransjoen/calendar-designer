using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calendar_designer.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private List<List<RadioButton>> lines = new List<List<RadioButton>>();

        public SettingsWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        /// <summary>
        /// Fills in current preferences.
        /// </summary>
        private void InitializeWindow()
        {
            lines.Add(new List<RadioButton> { Line1Black, Line1Gray });
            lines.Add(new List<RadioButton> { Line2Black, Line2Gray });
            lines.Add(new List<RadioButton> { Line3Black, Line3Gray });

            Preferences preferences = Global.Calendar.Preferences;

            for (int i = 0; i < lines.Count; i++)
            {
                if (preferences.LineColor[i] == DrawClass.Colors.Black)
                    lines[i].First().IsChecked = true;
                else
                    lines[i].Last().IsChecked = true;
            }

            Language.SelectedIndex = (int)preferences.Language;
        }

        /// <summary>
        /// Writes the selected settings back to file.
        /// </summary>
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Preferences preferences = new Preferences(useStandardSet: true);

            for (int i = 0; i < lines.Count; i++)
            {
                bool isBlack = (bool)lines[i].First().IsChecked;
                preferences.LineColor[i] = isBlack ? DrawClass.Colors.Black : DrawClass.Colors.Gray;
            }

            preferences.Language = (Preferences.Languages)Language.SelectedIndex;

            Global.Calendar.Preferences = preferences;

            if (UseAlways.IsChecked == true)
                Preferences.Write();
            else
                Global.Saved = false;

            Draw.Recalculate();
            Close();
        }
    }
}