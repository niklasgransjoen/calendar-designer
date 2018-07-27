using Kalenderdesigner_SS.Properties;
using System;
using System.Windows.Forms;
using System.Xml;

namespace Kalenderdesigner_SS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Global.mainForm = this;
            Global.picBox = picBox;
            Startup.Setup();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;

            if (!Global.saved)
                result = MessageBox.Show(Global.GetText("unsavedChanges") + "\n\n" + Global.GetText("continue"),
                    Global.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
                Calendar.Setup();
        }

        private void btnExport_Click(object sender, EventArgs e) => Calendar.Export();

        private void picBox_Paint(object sender, PaintEventArgs e) => Calendar.Draw(e.Graphics);

        private void picBox_MouseDown(object sender, MouseEventArgs e) => Mouse.MouseDown(sender, e);

        private void picBox_MouseUp(object sender, MouseEventArgs e) => Mouse.MouseUp(sender, e);

        private void picBox_MouseMove(object sender, MouseEventArgs e) => Mouse.MouseMove(sender, e);

        private void picBox_DoubleClick(object sender, MouseEventArgs e) => Mouse.DoubleClick(sender, e);

        private void tsBtnOpen_Click(object sender, EventArgs e) => Calendar.Load();

        private void tssBtnOpen_Click(object sender, EventArgs e) => tsBtnOpen_Click(sender, e);

        private void tsBtnSave_Click(object sender, EventArgs e) => Calendar.Save();

        private void tssBtnSave_Click(object sender, EventArgs e) => tsBtnSave_Click(sender, e);

        private void tsBtnSaveAs_Click(object sender, EventArgs e)
        {
            Global.path = "";
            Calendar.Save();
        }

        private void tsBtnExport_Click(object sender, EventArgs e) => Calendar.Export();

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;

            if (!Global.saved)
                result = MessageBox.Show(Global.GetText("unsavedChanges") + "\n\n" + Global.GetText("continue"),
                    Global.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                Dispose();
        }

        private void tsBtnEditCell_Click(object sender, EventArgs e) => Mouse.editCell_Click(sender, e);

        private void tssBtnEditCell_Click(object sender, EventArgs e) => Mouse.editCell_Click(sender, e);

        private void tsBtnCopyCell_Click(object sender, EventArgs e) => Mouse.copyPrev_Click(sender, e);

        private void tssBtnCopyCell_Click(object sender, EventArgs e) => Mouse.copyPrev_Click(sender, e);

        private void tsBtnBigText_Click(object sender, EventArgs e) => Mouse.bigText_Click(sender, e);

        private void tssBtnBigText_Click(object sender, EventArgs e) => Mouse.bigText_Click(sender, e);

        private void tsBtnEditSubtext_Click(object sender, EventArgs e) => new SubtextEdit().ShowDialog();

        private void tssBtnEditSubtext_Click(object sender, EventArgs e) => tsBtnEditSubtext_Click(sender, e);

        private void tsBtnSettings_Click(object sender, EventArgs e) => new Settings().ShowDialog();

        private void tssBtnSettings_Click(object sender, EventArgs e) => tsBtnSettings_Click(sender, e);

        private void tsBtnChangenotes_Click(object sender, EventArgs e) => MessageBox.Show(Resources.changenotes, Global.GetText("changenotes"));

    }
}