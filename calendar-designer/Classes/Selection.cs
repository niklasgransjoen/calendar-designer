using System.Collections.Generic;
using System.Drawing;

namespace CalendarDesigner
{
    public static class Selection
    {
        /// <summary>
        /// Gets a list of selected cells.
        /// </summary>
        public static List<Date> SelectedCells { get; } = new List<Date>();

        /// <summary>
        /// Gets the pen for drawing the outline of the selection rect.
        /// </summary>
        private static Pen MousePen { get; } = Pens.Blue;

        /// <summary>
        /// Gets the brush for filling the selection rect.
        /// </summary>
        private static SolidBrush MouseFill { get; } = new SolidBrush(Color.FromArgb(90, Color.Blue));

        /// <summary>
        /// Gets the brush for filling a selected date cell.
        /// </summary>
        private static SolidBrush DateSelectionFill { get; } = new SolidBrush(Color.FromArgb(120, Color.Blue));

        /// <summary>
        /// Draws all selection-related data.
        /// <para>Calling this updates the Global.SelectedCells list.</para>
        /// </summary>
        /// <param name="g"></param>
        public static void Draw(Graphics g)
        {
            DrawSelection(g);
            DrawSelectionRect(g);
        }

        /// <summary>
        /// Fills all selected date cells.
        /// </summary>
        private static void DrawSelection(Graphics g)
        {
            foreach (Date date in SelectedCells)
                g.FillRectangle(DateSelectionFill, date.Rect);
        }

        /// <summary>
        /// Draws the selection rectangle.
        /// </summary>
        private static void DrawSelectionRect(Graphics g)
        {
            g.FillRectangle(MouseFill, Mouse.SelectionRect);
            g.DrawRectangle(MousePen, Mouse.SelectionRect);
        }

        /// <summary>
        /// Checks whether any cells intersects with the selection rect.
        /// <para>The result is added to the Global.SelectedCells list.</para>
        /// </summary>
        public static void IntersectCheck()
        {
            Rectangle selectionRect = Mouse.SelectionRect;
            Selection.SelectedCells.Clear();

            foreach (Date date in Global.Calendar.Dates)
                if (date.Rect.IntersectsWith(selectionRect))
                    Selection.SelectedCells.Add(date);
        }
    }
}