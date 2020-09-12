using CalendarDesigner.Properties;
using CalendarDesigner.Windows;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CalendarDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global.Preferences = Preferences.Read();
            InitializeComponent();

            Global.MainWindow = this;
            Startup.Setup();
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (!Global.Saved)
                result = MessageBox.Show(
                    text.PopupUnsaved + "\n\n" +
                    text.PopupContinue,
                    text.Warning,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
                new Calendar(newInstance: true);
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e) => Mouse.Down(e);

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e) => Mouse.Up(e);

        private void Canvas_MouseMove(object sender, MouseEventArgs e) => Mouse.Move(e);

        private void Open_Click(object sender, RoutedEventArgs e) => File.Open();

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) => File.Open();

        private void Save_Click(object sender, RoutedEventArgs e) => File.Save();

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) => File.Save();

        private void SaveAs_Click(object sender, RoutedEventArgs e) => File.SaveAs();

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) => File.SaveAs();

        private void Close_Click(object sender, RoutedEventArgs e) => Close();

        private void CloseCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) => Close();

        protected override void OnClosing(CancelEventArgs e) => CloseSoftware(e);

        public void EditCell_Click(object sender, RoutedEventArgs e)
        {
            if (Selection.SelectedCells.Any())
                new CellWindow().ShowDialog();
        }

        public void CopyPrev_Click(object sender, RoutedEventArgs e) => Selection.ToggleCopyPrev();

        public void BigText_Click(object sender, RoutedEventArgs e) => Selection.ToggleBigText();

        public void WrapText_Click(object sender, RoutedEventArgs e) => Selection.ToggleWrapText();

        private void EditSubtext_Click(object sender, RoutedEventArgs e) => new SubtextWindow().ShowDialog();

        private void Export_Click(object sender, RoutedEventArgs e) => File.SaveAs(File.Extentions.PNG);

        private void ToolBar_DropDown(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ContextMenu menu = btn.ContextMenu;

            menu.PlacementTarget = btn;
            menu.Placement = PlacementMode.Bottom;
            menu.IsOpen = true;
        }

        private void Settings_Click(object sender, RoutedEventArgs e) => new SettingsWindow().ShowDialog();

        /// <summary>
        /// Prompts the user to save unsaved work, then closes the software.
        /// </summary>
        private void CloseSoftware(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBoxResult.Yes;

            if (!Global.Saved)
                result = MessageBox.Show(
                    text.PopupUnsaved + "\n\n" +
                    text.PopupContinue,
                    text.Warning,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                e.Cancel = true;
        }

    }
}