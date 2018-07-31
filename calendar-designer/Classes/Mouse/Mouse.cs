using CalendarDesigner.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public static class Mouse
    {
        /// <summary>
        /// Gets or sets the origin of the selection rect.
        /// </summary>
        public static Point SelectionPoint { get; set; }

        /// <summary>
        /// Gets or sets the selection rect.
        /// </summary>
        public static Rectangle SelectionRect { get; set; }

        /// <summary>
        /// Mouse is pressed.
        /// </summary>
        public static void Down(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    MouseDown.Select(e.Location);
                    break;

                case MouseButtons.Right:
                    MouseDown.SelectRight(e.Location);
                    break;
            }

            ShowTips();
        }

        /// <summary>
        /// Moving mouse (while holding button)
        /// </summary>
        public static void Move(MouseEventArgs e)
        {
            MouseMove.Select(e.Location);
            ShowTips();
        }

        /// <summary>
        /// Releasing mouse button
        /// </summary>
        public static void Up(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    MouseUp.Select(e.Location);
                    break;

                case MouseButtons.Right:
                    MouseUp.SelectRight(e.Location);
                    break;
            }

            ShowTips();
        }

        /// <summary>
        /// Double click on mouse
        /// </summary>
        public static void DoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MouseDown.DoubleClick(e.Location);
        }

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