using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public partial class CellEditForm : Form
    {
        private bool copyPrevChanged = false;
        private bool bigTextChanged = false;

        //Constructor
        public CellEditForm()
        {
            InitializeComponent();
            List<Date> selectedCells = Selection.SelectedCells;

            //Matches CopyPrev checkbox state to selected cells
            if (selectedCells.All(x => x.CopyPrev == selectedCells.First().CopyPrev))
                cbxCopyPrev.Checked = selectedCells.First().CopyPrev;
            else
                cbxCopyPrev.CheckState = CheckState.Indeterminate;

            //Matches BigText checkbox state to selected cells
            if (selectedCells.All(x => x.BigText == selectedCells.First().BigText))
                cbxBigText.Checked = selectedCells.First().BigText;
            else
                cbxBigText.CheckState = CheckState.Indeterminate;

            //Only fill textboxes if all selected cells have identical text
            if (selectedCells.All(x => x.Line1 == selectedCells.First().Line1)) textBox1.Text = selectedCells.First().Line1;
            if (selectedCells.All(x => x.Line2 == selectedCells.First().Line2)) textBox2.Text = selectedCells.First().Line2;
            if (selectedCells.All(x => x.Line3 == selectedCells.First().Line3)) textBox3.Text = selectedCells.First().Line3;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (Date date in Selection.SelectedCells)
            {
                if (copyPrevChanged)
                    date.CopyPrev = cbxCopyPrev.Checked;

                if (bigTextChanged)
                    date.BigText = cbxBigText.Checked;

                date.Line1 = textBox1.Text;
                date.Line2 = textBox2.Text;
                date.Line3 = textBox3.Text;
            }

            Calendar.Recalculate();
            Global.Saved = false;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        // Change in checkbox state

        private void cbxCopyPrev_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
                cbxBigText.Checked = false;

            textBox1.Enabled = !checkBox.Checked;
            textBox2.Enabled = !checkBox.Checked;
            textBox3.Enabled = !checkBox.Checked;

            copyPrevChanged = true;
        }

        private void cbxBigText_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
                cbxCopyPrev.Checked = false;

            textBox2.Enabled = !checkBox.Checked;
            textBox3.Enabled = !checkBox.Checked;

            bigTextChanged = true;
        }
    }
}