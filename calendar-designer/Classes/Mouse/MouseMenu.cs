using CalendarDesigner.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public static class MouseMenu
    {

        //Checked toolbar buttons
        private static void BtnCheckState()
        {
            Calendar calendar = Global.Calendar;

            if (Selection.SelectedCells.Count == 0)
            {
                Global.MainForm.tssBtnCopyCell.Checked = false;
                Global.MainForm.tssBtnBigText.Checked = false;
                return;
            }

            Global.MainForm.tssBtnCopyCell.Checked = true;
            Global.MainForm.tssBtnBigText.Checked = true;
            foreach (Date date in Selection.SelectedCells)
            {
                if (!date.BigText)
                    Global.MainForm.tssBtnBigText.Checked = false;

                if (!date.CopyPrev)
                    Global.MainForm.tssBtnCopyCell.Checked = false;
            }
        }

        //ContextMenu code
        public static ContextMenuStrip ContextSetup()
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            Calendar calendar = Global.Calendar;

            cm.Items.Add(text.EditCell, null, new EventHandler(EditCell_Click));
            cm.Items.Add(text.CopyPrev, null, new EventHandler(CopyPrev_Click));
            cm.Items.Add(text.BigText, null, new EventHandler(BigText_Click));

            ((ToolStripMenuItem)cm.Items[1]).Checked = true;
            foreach (Date date in Selection.SelectedCells)
                if (!date.CopyPrev)
                    ((ToolStripMenuItem)cm.Items[1]).Checked = false;

            ((ToolStripMenuItem)cm.Items[2]).Checked = true;
            foreach (Date date in Selection.SelectedCells)
                if (!date.BigText)
                    ((ToolStripMenuItem)cm.Items[2]).Checked = false;

            return cm;
        }

        /// <summary>
        /// Event handler for editing cells
        /// </summary>
        public static void EditCell_Click(object sender, EventArgs e)
        {
            if (Selection.SelectedCells.Count == 0)
                return;

            new CellEditForm().ShowDialog();
        }

        /// <summary>
        /// Event handling for copying previous cell
        /// </summary>
        public static void CopyPrev_Click(object sender, EventArgs e)
        {
            if (Selection.SelectedCells.Count == 0)
                return;

            Calendar calendar = Global.Calendar;
            bool controllerChecked = CheckChecked(sender);

            //All marked cells copy previous
            foreach (Date date in Selection.SelectedCells)
            {
                date.CopyPrev = !controllerChecked;
                if (!controllerChecked)
                    date.BigText = false;
            }

            //Top row can't copy cells
            for (int i = 0; i < Calendar.Weekdays.Count; i++)
                calendar.Dates[i].CopyPrev = false;

            BtnCheckState();
            Calendar.Redraw();
        }

        /// <summary>
        /// Eventhandler for bigtext
        /// </summary>
        public static void BigText_Click(object sender, EventArgs e)
        {
            Calendar calendar = Global.Calendar;

            if (Selection.SelectedCells.Count == 0)
                return;

            bool controllerChecked = CheckChecked(sender);

            //Sets all marked cells to BigText
            foreach (Date date in Selection.SelectedCells)
            {
                date.BigText = !controllerChecked;
                if (!controllerChecked)
                    date.CopyPrev = false;
            }

            BtnCheckState();
            Calendar.Redraw();
        }

        /// <summary>
        /// Returns whether the selected controller is checked
        /// </summary>
        private static bool CheckChecked(object sender)
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
    }
}
