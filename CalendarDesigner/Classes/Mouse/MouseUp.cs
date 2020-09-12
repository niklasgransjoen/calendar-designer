using System.Linq;

namespace CalendarDesigner
{
    public static class MouseUp
    {
        /// <summary>
        /// The event that triggers when the left mouse button is released.
        /// </summary>
        public static void Select()
        {
            Selection.SelectedCells = Selection.GetSelectedCells();
            Selection.DisableSelectionRect();
            Functions.UpdateCheckedState();
        }

        /// <summary>
        /// The event that triggers when the right mouse button is released.
        /// </summary>
        public static void SelectRight()
        {
            if (!Selection.SelectedCells.Any())
                Selection.SelectedCells = Selection.GetSelectedCells();

            Selection.DisableSelectionRect();
            Functions.UpdateCheckedState();

            MouseMenu.Show();
        }
    }
}