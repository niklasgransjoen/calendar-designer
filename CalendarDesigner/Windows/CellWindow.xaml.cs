using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CalendarDesigner.Windows
{
    /// <summary>
    /// Interaction logic for CellWindow.xaml
    /// </summary>
    public partial class CellWindow : Window
    {
        /// <summary>
        /// Gets the TextBoxes of this window.
        /// </summary>
        private List<TextBox> Lines { get; } = new List<TextBox>();

        public CellWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            Lines.AddRange(new List<TextBox> { Line1, Line2, Line3 });

            List<Date> SelectedCells = Selection.SelectedCells;
            Date date = SelectedCells.First();

            // Fills the window with the first date's events.
            for (int i = 0; i < Lines.Count; i++)
                Lines[i].Text = date.Events[i];

            // Preserve the dates' properties if they differ.

            if (SelectedCells.All(x => x.CopyPrev == date.CopyPrev))
                CopyPrev.IsChecked = date.CopyPrev;

            if (SelectedCells.All(x => x.BigText == date.BigText))
                BigText.IsChecked = date.BigText;

            if (SelectedCells.All(x => x.WrapText == date.WrapText))
                WrapText.IsChecked = date.WrapText;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Date date in Selection.SelectedCells)
            {
                for (int i = 0; i < Lines.Count; i++)
                    date.Events[i] = Lines[i].Text;

                if (CopyPrev.IsChecked != null)
                    date.CopyPrev = (bool)CopyPrev.IsChecked;

                if (BigText.IsChecked != null)
                    date.BigText = (bool)BigText.IsChecked;

                if (WrapText.IsChecked != null)
                    date.WrapText = (bool)WrapText.IsChecked;
            }

            DrawInfo.EventSetup();
            Draw.Redraw();
            Global.Saved = false;
            Close();
        }

        // Make sure both properties aren't selected at once.
        private void CheckChange(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk == CopyPrev)
            {
                if (chk.IsChecked == true)
                    BigText.IsChecked = false;
            }
            else
            {
                if (chk.IsChecked == true)
                    CopyPrev.IsChecked = false;
            }
        }

        private void Line_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox Line = (TextBox)sender;
            Line.SelectAll();
        }
    }
}