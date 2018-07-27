using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    public partial class SubtextEdit : Form
    {
        public SubtextEdit()
        {
            InitializeComponent();

            textBox1.Text = Global.subtext1;
            textBox2.Text = Global.subtext2;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Global.subtext1 = textBox1.Text;
            Global.subtext2 = textBox2.Text;

            Dispose();
            Calendar.ReDraw();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
