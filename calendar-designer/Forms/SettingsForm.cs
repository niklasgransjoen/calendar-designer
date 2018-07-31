using System;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SetUp();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Preferences preferences = Global.Preferences;

            preferences.Line1Color = rdoBlack1.Checked ? DrawClass.Colors.Black : DrawClass.Colors.Gray;
            preferences.Line2Color = rdoBlack2.Checked ? DrawClass.Colors.Black : DrawClass.Colors.Gray;
            preferences.Line3Color = rdoBlack3.Checked ? DrawClass.Colors.Black : DrawClass.Colors.Gray;

            if (rdBtnGlobal.Checked)
                Preferences.Write();

            Calendar.Recalculate();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SetUp()
        {
            Preferences preferences = Global.Preferences;

            if (preferences.Line1Color == DrawClass.Colors.Black)
                rdoBlack1.Checked = true;
            else
                rdBtnGray1.Checked = true;

            if (preferences.Line2Color == DrawClass.Colors.Black)
                rdoBlack2.Checked = true;
            else
                rdBtnGray2.Checked = true;

            if (preferences.Line3Color == DrawClass.Colors.Black)
                rdoBlack3.Checked = true;
            else
                rdBtnGray3.Checked = true;
        }
    }
}