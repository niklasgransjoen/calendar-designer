using Calendar_designer.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calendar_designer
{
    public static class MouseMenu
    {
        /// <summary>
        /// Displays the ContextMenu.
        /// </summary>
        public static void Show()
        {
            ContextMenu cm = new ContextMenu();
            Calendar calendar = Global.Calendar;
            MainWindow mainWindow = Global.MainWindow;

            MenuItem editCell = new MenuItem { Header = text.EditCell };
            MenuItem copyPrev = new MenuItem { Header = text.CopyPrev };
            MenuItem bigText = new MenuItem { Header = text.BigText };
            MenuItem wrapText = new MenuItem { Header = text.Wrap };

            editCell.Click += new RoutedEventHandler(mainWindow.EditCell_Click);
            copyPrev.Click += new RoutedEventHandler(mainWindow.CopyPrev_Click);
            bigText.Click += new RoutedEventHandler(mainWindow.BigText_Click);
            wrapText.Click += new RoutedEventHandler(mainWindow.WrapText_Click);

            cm.Items.Add(editCell);
            cm.Items.Add(copyPrev);
            cm.Items.Add(bigText);
            cm.Items.Add(wrapText);

            List<Date> selection = Selection.SelectedCells;

            if (selection.Any())
            {
                copyPrev.IsChecked = selection.All(x => x.CopyPrev);
                bigText.IsChecked = selection.All(x => x.BigText);
                wrapText.IsChecked = selection.All(x => x.WrapText);
            }
            else
            {
                copyPrev.IsEnabled = false;
                bigText.IsEnabled = false;
                wrapText.IsEnabled = false;
            }

            cm.IsOpen = true;
        }
    }
}