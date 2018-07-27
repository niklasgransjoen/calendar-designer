using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    public partial class DateEdit : Form
    {
        private bool copyPrevChanged;
        private bool bigTextChanged;

        //Constructor
        public DateEdit()
        {
            InitializeComponent();

            List<string> line1 = new List<string>();
            List<string> line2 = new List<string>();
            List<string> line3 = new List<string>();
            List<bool> copyPrev = new List<bool>();
            List<bool> bigText = new List<bool>();

            //Deactivates checkbox if top cell is selected
            foreach (int index in Global.selectedIndexes)
            {
                if (index < 7)
                    cbxCopyPrev.Enabled = false;

                line1.Add(Global.line1[index]);
                line2.Add(Global.line2[index]);
                line3.Add(Global.line3[index]);
                copyPrev.Add(Global.lineCopyPrev[index]);
                bigText.Add(Global.bigText[index]);
            }

            //Matches CopyPrev checkbox state to selected cells
            if (copyPrev.All(x => x == copyPrev.First()))
                cbxCopyPrev.Checked = copyPrev[0];
            else
                cbxCopyPrev.CheckState = CheckState.Indeterminate;

            //Matches BigText checkbox state to selected cells
            if (bigText.All(x => x == bigText.First()))
                cbxBigText.Checked = bigText[0];
            else
                cbxBigText.CheckState = CheckState.Indeterminate;

            //If allowed with three lines of text
            if (Global.datesArr.GetLength(1) == 6)
                textBox3.Enabled = false;

            //Only fill textboxes if all selected cells have identical text
            if (line1.All(x => x == line1.First()))
                textBox1.Text = line1.First();
            if (line2.All(x => x == line2.First()))
                textBox2.Text = line2.First();
            if (line3.All(x => x == line3.First()))
                textBox3.Text = line3.First();

            copyPrevChanged = false;
            bigTextChanged = false;
        }

        /// <summary>
        /// Confirm edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string txt1, txt2, txt3;

            txt1 = textBox1.Text;
            txt2 = textBox2.Text;
            txt3 = textBox3.Text;

            foreach (int index in Global.selectedIndexes)
            {
                if (copyPrevChanged)
                    Global.lineCopyPrev[index] = cbxCopyPrev.Checked;

                if (bigTextChanged)
                    Global.bigText[index] = cbxBigText.Checked;

                if (!Global.lineCopyPrev[index])
                {
                    Global.line1[index] = txt1;
                    Global.line2[index] = txt2;
                    Global.line3[index] = txt3;
                }
            }

            Dispose();

            Calendar.ReDraw();
            Global.saved = false;
        }

        private void btnCancel_Click(object sender, EventArgs e) => Dispose();

        //Change in checkbox state

        private void cbxCopyPrev_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
                cbxBigText.Checked = false;

            textBox1.Enabled = !checkBox.Checked;
            textBox2.Enabled = !checkBox.Checked;
            textBox3.Enabled = !checkBox.Checked;
            cbxBigText.Enabled = !checkBox.Checked;

            copyPrevChanged = true;

            if (Global.datesArr.GetLength(1) == 6)
                textBox3.Enabled = false;
        }

        private void cbxBigText_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            textBox2.Enabled = !checkBox.Checked;
            textBox3.Enabled = !checkBox.Checked;

            bigTextChanged = true;

            if (Global.datesArr.GetLength(1) == 6)
                textBox3.Enabled = false;
        }
    }
}