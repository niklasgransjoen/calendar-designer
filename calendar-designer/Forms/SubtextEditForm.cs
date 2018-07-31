using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public partial class SubtextEditForm : Form
    {
        /// <summary>
        /// Creates a new instance of the Subtext Edit Form.
        /// </summary>
        public SubtextEditForm()
        {
            InitializeComponent();
            Calendar calendar = Global.Calendar;

            // Copies the subtext of the calendar to the textboxes.
            textBox1.Text = calendar.Subtext1;
            textBox2.Text = calendar.Subtext2;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Calendar calendar = Global.Calendar;

            // Writes the entered text to the calendar's subtext.
            calendar.Subtext1 = textBox1.Text;
            calendar.Subtext2 = textBox2.Text;

            DrawInfo.FontSetup();
            Calendar.Redraw();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
