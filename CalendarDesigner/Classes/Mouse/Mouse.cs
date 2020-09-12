using CalendarDesigner.Properties;
using System.Windows;
using System.Windows.Input;

using Input = System.Windows.Input;

namespace CalendarDesigner
{
    public static class Mouse
    {
        /// <summary>
        /// Mouse is pressed.
        /// </summary>
        public static void Down(MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    MouseDown.Left(e);
                    break;

                case MouseButton.Right:
                    MouseDown.SelectRight();
                    break;
            }

            ShowTips();
        }

        /// <summary>
        /// Moving mouse (while holding button)
        /// </summary>
        public static void Move(MouseEventArgs e)
        {
            MouseMove.Select();
            ShowTips();
        }

        /// <summary>
        /// Releasing mouse button
        /// </summary>
        public static void Up(MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    MouseUp.Select();
                    break;

                case MouseButton.Right:
                    MouseUp.SelectRight();
                    break;
            }

            ShowTips();
        }

        /// <summary>
        /// Double click on mouse
        /// </summary>
        public static void DoubleClick(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                MouseDown.DoubleClick();
        }

        /// <summary>
        /// Returns the position of the mouse relative to the canvas.
        /// </summary>
        public static Point GetMousePosition() => Input.Mouse.GetPosition(Global.Canvas);

        /// <summary>
        /// Shows tips.
        /// </summary>
        private static void ShowTips()
        {
            if (Selection.SelectedCells.Count != 0)
                Global.Tip = text.TipHoldShift;
            else
                Global.Tip = "";
        }
    }
}