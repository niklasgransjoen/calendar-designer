using System;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbBoxMonth = new System.Windows.Forms.ComboBox();
            this.cmbBoxYear = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnCalendar = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnEditCell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnBigText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnEditSubtext = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.tsBtnInfo = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnChangenotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tssBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tssBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tssBtnEditCell = new System.Windows.Forms.ToolStripButton();
            this.tssBtnCopyCell = new System.Windows.Forms.ToolStripButton();
            this.tssBtnBigText = new System.Windows.Forms.ToolStripButton();
            this.tssBtnEditSubtext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tssBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.Tips = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBoxMonth
            // 
            this.cmbBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMonth.FormattingEnabled = true;
            this.cmbBoxMonth.Items.AddRange(new object[] {
            Global.GetText("january"),
            Global.GetText("february"),
            Global.GetText("march"),
            Global.GetText("april"),
            Global.GetText("may"),
            Global.GetText("june"),
            Global.GetText("july"),
            Global.GetText("august"),
            Global.GetText("september"),
            Global.GetText("october"),
            Global.GetText("november"),
            Global.GetText("december") });

            this.cmbBoxMonth.Location = new System.Drawing.Point(15, 53);
            this.cmbBoxMonth.Name = "cmbBoxMonth";
            this.cmbBoxMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxMonth.TabIndex = 1;
            // 
            // cmbBoxYear
            // 
            this.cmbBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxYear.FormattingEnabled = true;
            this.cmbBoxYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbBoxYear.Location = new System.Drawing.Point(142, 53);
            this.cmbBoxYear.Name = "cmbBoxYear";
            this.cmbBoxYear.Size = new System.Drawing.Size(79, 21);
            this.cmbBoxYear.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(227, 53);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(103, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = Global.GetText("createCalendar");
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(534, 53);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = Global.GetText("export");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(15, 80);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(594, 420);
            this.picBox.TabIndex = 5;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            this.picBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picBox_DoubleClick);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            this.picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFile,
            this.tsBtnCalendar,
            this.tsBtnSettings,
            this.tsBtnInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(623, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnFile
            // 
            this.tsBtnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOpen,
            this.tsBtnSave,
            this.tsBtnSaveAs,
            this.toolStripSeparator3,
            this.tsBtnExport,
            this.toolStripSeparator1,
            this.tsBtnClose});
            this.tsBtnFile.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFile.Image")));
            this.tsBtnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFile.Name = "tsBtnFile";
            this.tsBtnFile.Size = new System.Drawing.Size(32, 22);
            this.tsBtnFile.Text = Global.GetText("toolbarFile");
            this.tsBtnFile.ToolTipText = Global.GetText("toolbarFile");
            // 
            // tsBtnOpen
            // 
            this.tsBtnOpen.Name = "tsBtnOpen";
            this.tsBtnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsBtnOpen.Size = new System.Drawing.Size(163, 22);
            this.tsBtnOpen.Text = Global.GetText("toolbarOpen");
            this.tsBtnOpen.Click += new System.EventHandler(this.tsBtnOpen_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsBtnSave.Size = new System.Drawing.Size(163, 22);
            this.tsBtnSave.Text = Global.GetText("toolbarSave");
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnSaveAs
            // 
            this.tsBtnSaveAs.Name = "tsBtnSaveAs";
            this.tsBtnSaveAs.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.tsBtnSaveAs.Size = new System.Drawing.Size(163, 22);
            this.tsBtnSaveAs.Text = Global.GetText("toolbarSaveAs");
            this.tsBtnSaveAs.Click += new System.EventHandler(this.tsBtnSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // tsBtnExport
            // 
            this.tsBtnExport.Name = "tsBtnExport";
            this.tsBtnExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsBtnExport.Size = new System.Drawing.Size(163, 22);
            this.tsBtnExport.Text = Global.GetText("export");
            this.tsBtnExport.Click += new System.EventHandler(this.tsBtnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // tsBtnClose
            // 
            this.tsBtnClose.Name = "tsBtnClose";
            this.tsBtnClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsBtnClose.Size = new System.Drawing.Size(163, 22);
            this.tsBtnClose.Text = Global.GetText("toolbarClose");
            this.tsBtnClose.Click += new System.EventHandler(this.tsBtnClose_Click);
            // 
            // tsBtnCalendar
            // 
            this.tsBtnCalendar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnCalendar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEditCell,
            this.tsBtnCopyCell,
            this.tsBtnBigText,
            this.tsBtnEditSubtext});
            this.tsBtnCalendar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCalendar.Image")));
            this.tsBtnCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCalendar.Name = "tsBtnCalendar";
            this.tsBtnCalendar.Size = new System.Drawing.Size(66, 22);
            this.tsBtnCalendar.Text = Global.GetText("toolbarCalendar");
            // 
            // tsBtnEditCell
            // 
            this.tsBtnEditCell.Name = "tsBtnEditCell";
            this.tsBtnEditCell.Size = new System.Drawing.Size(180, 22);
            this.tsBtnEditCell.Text = Global.GetText("editCell");
            this.tsBtnEditCell.Click += new System.EventHandler(this.tsBtnEditCell_Click);
            // 
            // tsBtnCopyCell
            // 
            this.tsBtnCopyCell.Name = "tsBtnCopyCell";
            this.tsBtnCopyCell.Size = new System.Drawing.Size(180, 22);
            this.tsBtnCopyCell.Text = Global.GetText("copyCell");
            this.tsBtnCopyCell.Click += new System.EventHandler(this.tsBtnCopyCell_Click);
            // 
            // tsBtnBigText
            // 
            this.tsBtnBigText.Name = "tsBtnBigText";
            this.tsBtnBigText.Size = new System.Drawing.Size(180, 22);
            this.tsBtnBigText.Text = Global.GetText("bigText");
            this.tsBtnBigText.Click += new System.EventHandler(this.tsBtnBigText_Click);
            // 
            // tsBtnEditSubtext
            // 
            this.tsBtnEditSubtext.Name = "tsBtnEditSubtext";
            this.tsBtnEditSubtext.Size = new System.Drawing.Size(180, 22);
            this.tsBtnEditSubtext.Text = Global.GetText("editSubText");
            this.tsBtnEditSubtext.Click += new System.EventHandler(this.tsBtnEditSubtext_Click);
            // 
            // tsBtnSettings
            // 
            this.tsBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSettings.Image")));
            this.tsBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSettings.Name = "tsBtnSettings";
            this.tsBtnSettings.Size = new System.Drawing.Size(73, 22);
            this.tsBtnSettings.Text = Global.GetText("toolbarSettings");
            this.tsBtnSettings.Click += new System.EventHandler(this.tsBtnSettings_Click);
            // 
            // tsBtnInfo
            // 
            this.tsBtnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnChangenotes});
            this.tsBtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnInfo.Image")));
            this.tsBtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInfo.Name = "tsBtnInfo";
            this.tsBtnInfo.Size = new System.Drawing.Size(52, 22);
            this.tsBtnInfo.Text = Global.GetText("toolbarOther");
            // 
            // tsBtnChangenotes
            // 
            this.tsBtnChangenotes.Name = "tsBtnChangenotes";
            this.tsBtnChangenotes.Size = new System.Drawing.Size(144, 22);
            this.tsBtnChangenotes.Text = Global.GetText("changenotes");
            this.tsBtnChangenotes.Click += new System.EventHandler(this.tsBtnChangenotes_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssBtnOpen,
            this.tssBtnSave,
            this.toolStripSeparator4,
            this.tssBtnEditCell,
            this.tssBtnCopyCell,
            this.tssBtnBigText,
            this.tssBtnEditSubtext,
            this.toolStripSeparator6,
            this.tssBtnSettings});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(623, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tssBtnOpen
            // 
            this.tssBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnOpen.Image = global::Kalenderdesigner_SS.Properties.Resources.open_file_icon;
            this.tssBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnOpen.Name = "tssBtnOpen";
            this.tssBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tssBtnOpen.Text = Global.GetText("toolbarOpen");
            this.tssBtnOpen.Click += new System.EventHandler(this.tssBtnOpen_Click);
            // 
            // tssBtnSave
            // 
            this.tssBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnSave.Image = global::Kalenderdesigner_SS.Properties.Resources.save_icon;
            this.tssBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnSave.Name = "tssBtnSave";
            this.tssBtnSave.Size = new System.Drawing.Size(23, 22);
            this.tssBtnSave.Text = Global.GetText("toolbarSave");
            this.tssBtnSave.Click += new System.EventHandler(this.tssBtnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tssBtnEditCell
            // 
            this.tssBtnEditCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnEditCell.Image = global::Kalenderdesigner_SS.Properties.Resources.edit_icon;
            this.tssBtnEditCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnEditCell.Name = "tssBtnEditCell";
            this.tssBtnEditCell.Size = new System.Drawing.Size(23, 22);
            this.tssBtnEditCell.Text = Global.GetText("editCell");
            this.tssBtnEditCell.Click += new System.EventHandler(this.tssBtnEditCell_Click);
            // 
            // tssBtnCopyCell
            // 
            this.tssBtnCopyCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnCopyCell.Image = global::Kalenderdesigner_SS.Properties.Resources.copy_icon;
            this.tssBtnCopyCell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnCopyCell.Name = "tssBtnCopyCell";
            this.tssBtnCopyCell.Size = new System.Drawing.Size(23, 22);
            this.tssBtnCopyCell.Text = Global.GetText("copyCell");
            this.tssBtnCopyCell.Click += new System.EventHandler(this.tssBtnCopyCell_Click);
            // 
            // tssBtnBigText
            // 
            this.tssBtnBigText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnBigText.Image = global::Kalenderdesigner_SS.Properties.Resources.bigtext_icon;
            this.tssBtnBigText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnBigText.Name = "tssBtnBigText";
            this.tssBtnBigText.Size = new System.Drawing.Size(23, 22);
            this.tssBtnBigText.Text = Global.GetText("bigText");
            this.tssBtnBigText.Click += new System.EventHandler(this.tssBtnBigText_Click);
            // 
            // tssBtnEditSubtext
            // 
            this.tssBtnEditSubtext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnEditSubtext.Image = global::Kalenderdesigner_SS.Properties.Resources.edit_text_icon;
            this.tssBtnEditSubtext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnEditSubtext.Name = "tssBtnEditSubtext";
            this.tssBtnEditSubtext.Size = new System.Drawing.Size(23, 22);
            this.tssBtnEditSubtext.Text = Global.GetText("editSubText");
            this.tssBtnEditSubtext.Click += new System.EventHandler(this.tssBtnEditSubtext_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tssBtnSettings
            // 
            this.tssBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssBtnSettings.Image = global::Kalenderdesigner_SS.Properties.Resources.settings_icons;
            this.tssBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssBtnSettings.Name = "tssBtnSettings";
            this.tssBtnSettings.Size = new System.Drawing.Size(23, 22);
            this.tssBtnSettings.Text = Global.GetText("toolbarSettings");
            this.tssBtnSettings.Click += new System.EventHandler(this.tssBtnSettings_Click);
            // 
            // Tips
            // 
            this.Tips.AutoSize = true;
            this.Tips.Location = new System.Drawing.Point(12, 503);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(0, 13);
            this.Tips.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 522);
            this.Controls.Add(this.Tips);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbBoxYear);
            this.Controls.Add(this.cmbBoxMonth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Global.GetText("mainformHeader");
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox cmbBoxMonth;
        public System.Windows.Forms.ComboBox cmbBoxYear;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.PictureBox picBox;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton tsBtnFile;
        private ToolStripMenuItem tsBtnOpen;
        private ToolStripMenuItem tsBtnSave;
        private ToolStripMenuItem tsBtnExport;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsBtnClose;
        private ToolStripButton tsBtnSettings;
        private ToolStripDropDownButton tsBtnInfo;
        private ToolStripMenuItem tsBtnChangenotes;
        private ToolStripDropDownButton tsBtnCalendar;
        private ToolStripMenuItem tsBtnEditCell;
        private ToolStripMenuItem tsBtnCopyCell;
        private ToolStripMenuItem tsBtnBigText;
        private ToolStripMenuItem tsBtnEditSubtext;
        private ToolStripMenuItem tsBtnSaveAs;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStrip toolStrip2;
        private ToolStripButton tssBtnOpen;
        private ToolStripButton tssBtnSave;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tssBtnEditCell;
        public ToolStripButton tssBtnCopyCell;
        public ToolStripButton tssBtnBigText;
        private ToolStripButton tssBtnEditSubtext;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton tssBtnSettings;
        public Label Tips;
    }
}

