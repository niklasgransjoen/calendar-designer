using System;
using System.Windows;

namespace Calendar_designer
{
    public static class MouseMove
    {
        /// <summary>
        /// The event that triggers when the mouse is moved while in selection mode.
        /// </summary>
        public static void Select()
        {
            if (!Selection.SelectionRect.IsEnabled)
                return;

            Point p = Mouse.GetMousePosition();

            double x = Selection.SelectionPoint.X;
            double y = Selection.SelectionPoint.Y;

            Selection.SelectionRect.Width = Math.Abs(p.X - x);
            Selection.SelectionRect.Height = Math.Abs(p.Y - y);

            double rectX = p.X < x ? p.X : x;
            double rectY = p.Y < y ? p.Y : y;

            Draw.Position(Selection.SelectionRect, rectX, rectY);

            Selection.Update();
        }
    }
}