using System;
using System.Drawing;

namespace CalendarDesigner
{
    public static class MouseMove
    {
        /// <summary>
        /// The event that triggers when the mouse is moved while in selection mode.
        /// </summary>
        public static void Select(Point p)
        {
            if (Mouse.SelectionRect == Rectangle.Empty)
                return;

            int x = Mouse.SelectionPoint.X;
            int y = Mouse.SelectionPoint.Y;

            Mouse.SelectionRect = new Rectangle(
                p.X < x ? p.X : x,
                p.Y < y ? p.Y : y,
                Math.Abs(p.X - x),
                Math.Abs(p.Y - y)
            );

            Selection.IntersectCheck();
            Calendar.Redraw();
        }
    }
}