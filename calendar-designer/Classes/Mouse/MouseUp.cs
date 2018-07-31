using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public static class MouseUp
    {
        /// <summary>
        /// The event that triggers when the left mouse button is released.
        /// </summary>
        public static void Select(Point location)
        {
            Mouse.SelectionRect = Rectangle.Empty;
            Calendar.Redraw();
        }

        /// <summary>
        /// The event that triggers when the right mouse button is released.
        /// </summary>
        public static void SelectRight(Point location)
        {
            ContextMenuStrip cm = MouseMenu.ContextSetup();
            cm.Show(Global.PicBox, location);

            Mouse.SelectionRect = Rectangle.Empty;
            Calendar.Redraw();
        }
    }
}
