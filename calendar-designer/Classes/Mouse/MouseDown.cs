using System.Drawing;
using System.Linq;

namespace CalendarDesigner
{
    public static class MouseDown
    {
        /// <summary>
        /// The event that triggers when the left mouse button is pressed down.
        /// </summary>
        public static void Select(Point location)
        {
            Mouse.SelectionPoint = location;
            Mouse.SelectionRect = new Rectangle(location, Size.Empty);

            Selection.IntersectCheck();
            Calendar.Redraw();
        }

        /// <summary>
        /// The event that triggers when the right mouse button is pressed down.
        /// </summary>
        public static void SelectRight(Point location)
        {
            foreach (Date date in Selection.SelectedCells)
                if (date.Rect.Contains(location))
                    return;

            Select(location);
        }

        /// <summary>
        /// The event that triggers when the left mouse button is double clicked.
        /// </summary>
        public static void DoubleClick(Point location)
        {
            if (Selection.SelectedCells.Any())
                new CellEditForm().ShowDialog();
        }
    }
}