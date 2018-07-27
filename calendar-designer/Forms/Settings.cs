using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            SetUp();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rdBtnBlack1.Checked)
                Global.line1Color = Color.Black;
            else
                Global.line1Color = Color.Gray;

            if (rdBtnBlack2.Checked)
                Global.line2Color = Color.Black;
            else
                Global.line2Color = Color.Gray;

            if (rdBtnBlack3.Checked)
                Global.line3Color = Color.Black;
            else
                Global.line3Color = Color.Gray;

            if (rdBtnGlobal.Checked)
                Preferences.Write();

            Dispose();

            Calendar.ReDraw();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SetUp()
        {
            if (Global.line1Color == Color.Black)
                rdBtnBlack1.Checked = true;
            else
                rdBtnGray1.Checked = true;

            if (Global.line2Color == Color.Black)
                rdBtnBlack2.Checked = true;
            else
                rdBtnGray2.Checked = true;

            if (Global.line3Color == Color.Black)
                rdBtnBlack3.Checked = true;
            else
                rdBtnGray3.Checked = true;
        }
    }
}