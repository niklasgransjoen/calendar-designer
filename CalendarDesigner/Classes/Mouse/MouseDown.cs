using CalendarDesigner.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalendarDesigner
{
    public static class MouseDown
    {
        /// <summary>
        /// The event that triggers when the left mouse button is pressed down.
        /// </summary>
        public static void Left(MouseButtonEventArgs e)
        {
            switch (e.ClickCount)
            {
                case 1:
                    Select();
                    break;

                default:
                    DoubleClick();
                    break;
            }
        }

        /// <summary>
        /// The event that triggers when the left mouse button is pressed down once.
        /// </summary>
        public static void Select()
        {
            if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                Selection.SelectedCells.Clear();

            Selection.SelectionPoint = Mouse.GetMousePosition();
            Selection.SelectionRect.IsEnabled = true;
            Draw.Position(Selection.SelectionRect, Selection.SelectionPoint);

            Selection.Update();
        }

        /// <summary>
        /// The event that triggers when the right mouse button is pressed down.
        /// </summary>
        public static void SelectRight()
        {
            Point location = Mouse.GetMousePosition();

            foreach (Date date in Selection.SelectedCells)
            {
                Rect dateRect = date.Rect.RenderedGeometry.Bounds;

                dateRect.X = Canvas.GetLeft(date.Rect);
                dateRect.Y = Canvas.GetTop(date.Rect);

                if (dateRect.Contains(location))
                    return;
            }

            Select();
        }

        /// <summary>
        /// The event that triggers when the left mouse button is double clicked.
        /// </summary>
        public static void DoubleClick()
        {
            if (Selection.SelectedCells.Any())
                new CellWindow().ShowDialog();
        }
    }
}