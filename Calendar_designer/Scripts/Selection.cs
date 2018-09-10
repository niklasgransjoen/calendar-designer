using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Calendar_designer
{
    public static class Selection
    {
        /// <summary>
        /// Gets the pen for drawing the outline of the selection rect.
        /// </summary>
        private static Brush MouseOutline { get; } = Brushes.Blue;

        /// <summary>
        /// Gets the brush for filling the selection rect.
        /// </summary>
        private static Brush MouseFill { get; } = new SolidColorBrush(Color.FromArgb(90, 0, 0, 255));

        /// <summary>
        /// Gets the brush for filling a selected date cell.
        /// </summary>
        public static Brush CellFill { get; } = new SolidColorBrush(Color.FromArgb(90, 0, 0, 255));

        /// <summary>
        /// Gets or sets the selection point, the origin of the selection.
        /// </summary>
        public static Point SelectionPoint { get; set; }

        /// <summary>
        /// Gets or sets the selection rect.
        /// </summary>
        public static Rectangle SelectionRect { get; set; } = new Rectangle { Fill = MouseFill, Stroke = MouseOutline, IsEnabled = false };

        /// <summary>
        /// Gets a list of selected cells.
        /// </summary>
        public static List<Date> SelectedCells { get; set; } = new List<Date>();

        /// <summary>
        /// Draws the selection rectangle.
        /// </summary>
        public static void _Draw() => Draw.Add(SelectionRect);

        /// <summary>
        /// Updates the current selection.
        /// </summary>
        public static void Update()
        {
            GetSelectedCells();

            foreach (Date date in Global.Calendar.Dates)
                date.Rect.Fill = date.Selected ? CellFill : Brushes.Transparent;
        }

        /// <summary>
        /// Checks whether any cells intersects with the selection rect.
        /// <para>Returns the interesected cells.</para>
        /// </summary>
        public static List<Date> GetSelectedCells()
        {
            List<Date> selectedCells = new List<Date>();

            bool multiSelect = Keyboard.Modifiers.HasFlag(ModifierKeys.Control);

            foreach (Date date in Global.Calendar.Dates)
            {
                bool wasSelected = SelectedCells.Contains(date);
                bool selectionState = wasSelected & multiSelect;

                Rect mouseRect = SelectionRect.RenderedGeometry.Bounds;
                Rect dateRect = date.Rect.RenderedGeometry.Bounds;

                mouseRect.X = Canvas.GetLeft(SelectionRect);
                mouseRect.Y = Canvas.GetTop(SelectionRect);

                dateRect.X = Canvas.GetLeft(date.Rect);
                dateRect.Y = Canvas.GetTop(date.Rect);

                date.Selected = mouseRect.IntersectsWith(dateRect) ^ selectionState;

                if (date.Selected)
                    selectedCells.Add(date);
            }

            return selectedCells;
        }

        /// <summary>
        /// Disables the selection rect.
        /// </summary>
        public static void DisableSelectionRect()
        {
            SelectionRect.IsEnabled = false;
            SelectionRect.Width = 0;
            SelectionRect.Height = 0;

            Draw.Position(SelectionRect, 0, 0);
        }

        /// <summary>
        /// Toggles the CopyPrev flag on the selection.
        /// </summary>
        public static void ToggleCopyPrev()
        {
            if (!SelectedCells.Any())
                return;

            bool state = !SelectedCells.All(x => x.CopyPrev);

            foreach (Date date in SelectedCells)
            {
                date.CopyPrev = state;
                if (state)
                    date.BigText = false;
            }

            Functions.UpdateCheckedState();
            DrawInfo.EventSetup();
            Draw.Redraw();
            Global.Saved = false;
        }

        /// <summary>
        /// Toggles the BigText flag on the selection.
        /// </summary>
        public static void ToggleBigText()
        {
            if (!SelectedCells.Any())
                return;

            bool state = !SelectedCells.All(x => x.BigText);

            foreach (Date date in SelectedCells)
            {
                date.BigText = state;
                if (state)
                    date.CopyPrev = false;
            }

            Functions.UpdateCheckedState();
            DrawInfo.EventSetup();
            Draw.Redraw();
            Global.Saved = false;
        }

        /// <summary>
        /// Toggles the WrapText flag on the selection.
        /// </summary>
        public static void ToggleWrapText()
        {
            if (!SelectedCells.Any())
                return;

            bool state = !SelectedCells.All(x => x.WrapText);

            foreach (Date date in SelectedCells)
                date.WrapText = state;

            Functions.UpdateCheckedState();
            DrawInfo.EventSetup();
            Draw.Redraw();
            Global.Saved = false;
        }
    }
}