using CalendarDesigner.Properties;
using System;
using System.Windows.Forms;

namespace CalendarDesigner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Startup.LoadFont();
            Preferences.Read();

            InitializeComponent();
            foreach (string month in Calendar.Months)
                cmbBoxMonth.Items.Add(month);

            Global.MainForm = this;
            Startup.Setup();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;

            if (!Global.Saved)
                result = MessageBox.Show(
                    text.PopupUnsaved + "\n\n" +
                    text.PopupContinue,
                    text.Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                new Calendar(true);
        }

        private void btnExport_Click(object sender, EventArgs e) => File.SaveAs(File.Extentions.PNG);

        private void picBox_Paint(object sender, PaintEventArgs e) => Draw.Redraw(e.Graphics);

        private void picBox_MouseDown(object sender, MouseEventArgs e) => Mouse.Down(e);

        private void picBox_MouseUp(object sender, MouseEventArgs e) => Mouse.Up(e);

        private void picBox_MouseMove(object sender, MouseEventArgs e) => Mouse.Move(e);

        private void picBox_DoubleClick(object sender, MouseEventArgs e) => Mouse.DoubleClick(e);

        private void tsBtnOpen_Click(object sender, EventArgs e) => File.Open();

        private void tssBtnOpen_Click(object sender, EventArgs e) => File.Open();

        private void tsBtnSave_Click(object sender, EventArgs e) => File.Save();

        private void tssBtnSave_Click(object sender, EventArgs e) => File.Save();

        private void tsBtnSaveAs_Click(object sender, EventArgs e) => File.SaveAs();

        private void tsBtnExport_Click(object sender, EventArgs e) => File.SaveAs(File.Extentions.PNG);

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;

            if (!Global.Saved)
                result = MessageBox.Show(
                    text.PopupUnsaved + "\n\n" +
                    text.PopupContinue,
                    text.Warning,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                Dispose();
        }

        private void tsBtnEditCell_Click(object sender, EventArgs e) => MouseMenu.EditCell_Click(sender, e);

        private void tssBtnEditCell_Click(object sender, EventArgs e) => MouseMenu.EditCell_Click(sender, e);

        private void tsBtnCopyCell_Click(object sender, EventArgs e) => MouseMenu.CopyPrev_Click(sender, e);

        private void tssBtnCopyCell_Click(object sender, EventArgs e) => MouseMenu.CopyPrev_Click(sender, e);

        private void tsBtnBigText_Click(object sender, EventArgs e) => MouseMenu.BigText_Click(sender, e);

        private void tssBtnBigText_Click(object sender, EventArgs e) => MouseMenu.BigText_Click(sender, e);

        private void tsBtnEditSubtext_Click(object sender, EventArgs e) => new SubtextEditForm().ShowDialog();

        private void tssBtnEditSubtext_Click(object sender, EventArgs e) => tsBtnEditSubtext_Click(sender, e);

        private void tsBtnSettings_Click(object sender, EventArgs e) => new SettingsForm().ShowDialog();

        private void tssBtnSettings_Click(object sender, EventArgs e) => tsBtnSettings_Click(sender, e);

        private void tsBtnChangenotes_Click(object sender, EventArgs e) => MessageBox.Show(Resources.changenotes, text.Changenotes);
    }
}