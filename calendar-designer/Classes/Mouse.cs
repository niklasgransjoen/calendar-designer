using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class Mouse
    {
        public static bool leftDown = false;
        public static bool rightDown = false;

        /// <summary>
        /// Mouse is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
                return;

            if (e.Button == MouseButtons.Right && Global.selectedRectangles.Contains(SelectRect(e.Location)))
                return;

            leftDown = e.Button == MouseButtons.Left;
            rightDown = e.Button == MouseButtons.Right;

            Rectangle rect = SelectRect(e.Location, out int index);

            if (Control.ModifierKeys != Keys.Shift)
            {
                Global.selectedIndex = default(int);
                Global.selectedIndexes.Clear();
                Global.selectedRectangles.Clear();
            }

            if (rect != default(Rectangle))
            {
                Global.selectedIndex = index;

                if (!Global.selectedIndexes.Contains(index))
                    Global.selectedIndexes.Add(index);

                if (!Global.selectedRectangles.Contains(rect))
                    Global.selectedRectangles.Add(rect);
            }

            Calendar.ReDraw();
        }

        /// <summary>
        /// Moving mouse (while holding button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MouseMove(object sender, MouseEventArgs e)
        {
            if ((!leftDown && !rightDown) || Global.selectedIndexes.Count == 0)
                return;

            //Messy calculation of selected cells
            int[] startIndex = Global.ListToArrIndex(Global.selectedIndex);

            SelectRect(e.Location, out int[] index);

            if (index == null)
                return;

            if (Control.ModifierKeys != Keys.Shift)
            {
                Global.selectedRectangles.Clear();
                Global.selectedIndexes.Clear();
            }

            int[] indexMin = new int[2];
            int[] indexMax = new int[2];

            for (int i = 0; i < 2; i++)
                if (index[i] > startIndex[i])
                {
                    indexMin[i] = startIndex[i];
                    indexMax[i] = index[i];
                }
                else
                {
                    indexMin[i] = index[i];
                    indexMax[i] = startIndex[i];
                }

            for (int i = indexMin[0]; i <= indexMax[0]; i++)
                for (int j = indexMin[1]; j <= indexMax[1]; j++)
                    Global.selectedIndexes.Add(Global.ArrToListIndex(new int[] { i, j }));

            foreach (int listIndex in Global.selectedIndexes)
                Global.selectedRectangles.Add(RectFromIndex(listIndex));

            Calendar.ReDraw();
        }

        /// <summary>
        /// Releasing mouse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftDown = false;
            else if (e.Button == MouseButtons.Right)
                rightDown = false;

            tsBtnCheckState();

            showTips();

            //Right click
            if (e.Button != MouseButtons.Right)
                return;

            if (SelectRect(e.Location) != default(Rectangle))
            {
                ContextMenuStrip cm = ContextSetup();

                cm.Show(Global.picBox, e.Location);
            }
        }

        /// <summary>
        /// Double click on mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (SelectRect(e.Location) != default(Rectangle))
                new DateEdit().ShowDialog();
        }

        /// <summary>
        /// Get eventual cell that contains point
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <returns>The cell that contains the point</returns>
        private static Rectangle SelectRect(Point point)
        {
            return SelectRect(point, out int[] index);
        }

        /// <summary>
        /// Get eventuel cell that contains point
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <param name="index">Index (list) of the returned cell</param>
        /// <returns>The cell that contains the point</returns>
        private static Rectangle SelectRect(Point point, out int index)
        {
            Rectangle rect = SelectRect(point, out int[] indexArr);

            if (indexArr != null)
            {
                //Converts from array index to list index
                index = Global.ArrToListIndex(indexArr);
                return rect;
            }
            else
            {
                index = default(int);
                return default(Rectangle);
            }
        }

        /// <summary>
        /// Get eventuel cell that contains point
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <param name="index">Index (array) of the returned cell</param>
        /// <returns>The cell that contains the point</returns>
        private static Rectangle SelectRect(Point point, out int[] index)
        {
            Rectangle rect;

            for (int i = 0; i < Global.datesArr.GetLength(1); i++)
                for (int j = 0; j < Global.datesArr.GetLength(0); j++)
                {
                    rect = RectFromIndex(j, i);

                    if (rect.Contains(point))
                    {
                        index = new int[] { j, i };
                        return rect;
                    }
                }

            index = default(int[]);
            return default(Rectangle);
        }

        /// <summary>
        /// Get cell from index (array)
        /// </summary>
        /// <param name="x">x index</param>
        /// <param name="y">y index</param>
        /// <returns>The cell at the given index</returns>
        private static Rectangle RectFromIndex(int x, int y)
        {
            int x1 = CalendarDraw.cornerX + CalendarDraw.paddingX + x * CalendarDraw.colWidth;
            int y1 = CalendarDraw.cornerYTable + CalendarDraw.paddingY + y * CalendarDraw.rowHeight;
            return new Rectangle(x1, y1, CalendarDraw.colWidth, CalendarDraw.rowHeight);
        }

        /// <summary>
        /// Get cell from index (list)
        /// </summary>
        /// <param name="index">Index (list) of the cell to return</param>
        /// <returns></returns>
        private static Rectangle RectFromIndex(int index)
        {
            int[] indexArr = Global.ListToArrIndex(index);
            return RectFromIndex(indexArr[0], indexArr[1]);
        }

        //Checked toolbar buttons
        private static void tsBtnCheckState()
        {
            if (Global.selectedIndexes.Count == 0)
            {
                Global.mainForm.tssBtnCopyCell.Checked = false;
                Global.mainForm.tssBtnBigText.Checked = false;
                return;
            }

            Global.mainForm.tssBtnCopyCell.Checked = true;
            Global.mainForm.tssBtnBigText.Checked = true;
            foreach (int index in Global.selectedIndexes)
            {
                if (!Global.bigText[index])
                    Global.mainForm.tssBtnBigText.Checked = false;

                if (!Global.lineCopyPrev[index])
                    Global.mainForm.tssBtnCopyCell.Checked = false;
            }
        }

        //ContextMenu code
        private static ContextMenuStrip ContextSetup()
        {
            ContextMenuStrip cm = new ContextMenuStrip();

            cm.Items.Add(Global.GetText("editCell"), null, new EventHandler(editCell_Click));
            cm.Items.Add(Global.GetText("copyCell"), null, new EventHandler(copyPrev_Click));
            cm.Items.Add(Global.GetText("bigText"), null, new EventHandler(bigText_Click));

            if (Global.selectedIndexes.Count > 1)
                cm.Items[0].Text += Global.GetText("pluralEnding");

            ((ToolStripMenuItem)cm.Items[1]).Checked = true;
            foreach (int index in Global.selectedIndexes)
                if (!Global.lineCopyPrev[index])
                    ((ToolStripMenuItem)cm.Items[1]).Checked = false;

            ((ToolStripMenuItem)cm.Items[2]).Checked = true;
            foreach (int index in Global.selectedIndexes)
                if (!Global.bigText[index])
                    ((ToolStripMenuItem)cm.Items[2]).Checked = false;

            return cm;
        }

        /// <summary>
        /// Event handler for editing cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void editCell_Click(object sender, EventArgs e)
        {
            if (Global.selectedIndexes.Count == 0)
                return;

            new DateEdit().ShowDialog();
        }

        /// <summary>
        /// Event handling for copying previous cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void copyPrev_Click(object sender, EventArgs e)
        {
            if (Global.selectedIndexes.Count == 0)
                return;

            bool controllerChecked = checkChecked(sender);

            //All marked cells copy previous
            foreach (int index in Global.selectedIndexes)
            {
                Global.lineCopyPrev[index] = !controllerChecked;
                if (!controllerChecked)
                    Global.bigText[index] = false;
            }

            //Top row can't copy cells
            for (int i = 0; i < Global.datesArr.GetLength(0); i++)
                Global.lineCopyPrev[i] = false;

            tsBtnCheckState();
            Calendar.ReDraw();
        }

        /// <summary>
        /// Eventhandler for bigtext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void bigText_Click(object sender, EventArgs e)
        {
            if (Global.selectedIndexes.Count == 0)
                return;

            bool controllerChecked = checkChecked(sender);

            //Sets all marked cells to BigText
            foreach (int index in Global.selectedIndexes)
            {
                Global.bigText[index] = !controllerChecked;
                if (!controllerChecked)
                    Global.lineCopyPrev[index] = false;
            }

            tsBtnCheckState();
            Calendar.ReDraw();
        }

        /// <summary>
        /// Returns whether the selected controller is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private static bool checkChecked(object sender)
        {
            bool controllerChecked;

            if (ReferenceEquals(sender.GetType(), typeof(ToolStripMenuItem)))
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                controllerChecked = menuItem.Checked;
            }
            else
            {
                ToolStripButton stripButton = (ToolStripButton)sender;
                controllerChecked = stripButton.Checked;
            }

            return controllerChecked;
        }

        /// <summary>
        /// Shows tips
        /// </summary>
        private static void showTips()
        {
            if (Global.selectedIndexes.Count != 0)
                Global.mainForm.Tips.Text = Global.GetText("holdShiftTip");
            else
                Global.mainForm.Tips.Text = "";
        }
    }
}