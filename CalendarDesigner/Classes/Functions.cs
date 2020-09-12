using System.Collections.Generic;
using System.Linq;

namespace CalendarDesigner
{
    public static class Functions
    {
        /// <summary>
        /// Updates the checked state of all functions.
        /// </summary>
        public static void UpdateCheckedState()
        {
            List<Date> selection = Selection.SelectedCells;

            if (!selection.Any())
                return;

            bool copyPrev = selection.All(x => x.CopyPrev);
            bool bigText = selection.All(x => x.BigText);
            bool wrapText = selection.All(x => x.WrapText);

            Global.MainWindow.tsCopyPrev.IsChecked = copyPrev;
            Global.MainWindow.tssCopyPrev.IsChecked = copyPrev;

            Global.MainWindow.tsBigText.IsChecked = bigText;
            Global.MainWindow.tssBigText.IsChecked = bigText;

            Global.MainWindow.tsWrapText.IsChecked = wrapText;
            Global.MainWindow.tssWrapText.IsChecked = wrapText;
        }
    }
}