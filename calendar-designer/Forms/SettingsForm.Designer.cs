using CalendarDesigner.Properties;

namespace CalendarDesigner
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingsTab = new System.Windows.Forms.TabControl();
            this.pageDateInfo = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdBtnGlobal = new System.Windows.Forms.RadioButton();
            this.rdBtnLocal = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdBtnGray3 = new System.Windows.Forms.RadioButton();
            this.rdoBlack3 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdBtnGray2 = new System.Windows.Forms.RadioButton();
            this.rdoBlack2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdBtnGray1 = new System.Windows.Forms.RadioButton();
            this.rdoBlack1 = new System.Windows.Forms.RadioButton();
            this.lblLine3 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.pageLanguage = new System.Windows.Forms.TabPage();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.settingsTab.SuspendLayout();
            this.pageDateInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.pageDateInfo);
            this.settingsTab.Controls.Add(this.pageLanguage);
            this.settingsTab.Location = new System.Drawing.Point(12, 12);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.SelectedIndex = 0;
            this.settingsTab.Size = new System.Drawing.Size(223, 214);
            this.settingsTab.TabIndex = 0;
            // 
            // pageDateInfo
            // 
            this.pageDateInfo.Controls.Add(this.panel4);
            this.pageDateInfo.Controls.Add(this.label5);
            this.pageDateInfo.Controls.Add(this.label4);
            this.pageDateInfo.Controls.Add(this.panel3);
            this.pageDateInfo.Controls.Add(this.panel2);
            this.pageDateInfo.Controls.Add(this.panel1);
            this.pageDateInfo.Controls.Add(this.lblLine3);
            this.pageDateInfo.Controls.Add(this.lblLine2);
            this.pageDateInfo.Controls.Add(this.lblLine1);
            this.pageDateInfo.Location = new System.Drawing.Point(4, 22);
            this.pageDateInfo.Name = "pageDateInfo";
            this.pageDateInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageDateInfo.Size = new System.Drawing.Size(215, 188);
            this.pageDateInfo.TabIndex = 0;
            this.pageDateInfo.Text = global::CalendarDesigner.Properties.text.Events;
            this.pageDateInfo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdBtnGlobal);
            this.panel4.Controls.Add(this.rdBtnLocal);
            this.panel4.Location = new System.Drawing.Point(50, 131);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(156, 48);
            this.panel4.TabIndex = 17;
            // 
            // rdBtnGlobal
            // 
            this.rdBtnGlobal.AutoSize = true;
            this.rdBtnGlobal.Location = new System.Drawing.Point(3, 26);
            this.rdBtnGlobal.Name = "rdBtnGlobal";
            this.rdBtnGlobal.Size = new System.Drawing.Size(58, 17);
            this.rdBtnGlobal.TabIndex = 1;
            this.rdBtnGlobal.Text = global::CalendarDesigner.Properties.text.Always;
            this.rdBtnGlobal.UseVisualStyleBackColor = true;
            // 
            // rdBtnLocal
            // 
            this.rdBtnLocal.AutoSize = true;
            this.rdBtnLocal.Checked = true;
            this.rdBtnLocal.Location = new System.Drawing.Point(3, 3);
            this.rdBtnLocal.Name = "rdBtnLocal";
            this.rdBtnLocal.Size = new System.Drawing.Size(122, 17);
            this.rdBtnLocal.TabIndex = 0;
            this.rdBtnLocal.TabStop = true;
            this.rdBtnLocal.Text = global::CalendarDesigner.Properties.text.NAlways;
            this.rdBtnLocal.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdBtnGray3);
            this.panel3.Controls.Add(this.rdoBlack3);
            this.panel3.Location = new System.Drawing.Point(50, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(107, 25);
            this.panel3.TabIndex = 14;
            // 
            // rdBtnGray3
            // 
            this.rdBtnGray3.AutoSize = true;
            this.rdBtnGray3.Location = new System.Drawing.Point(59, 5);
            this.rdBtnGray3.Name = "rdBtnGray3";
            this.rdBtnGray3.Size = new System.Drawing.Size(47, 17);
            this.rdBtnGray3.TabIndex = 13;
            this.rdBtnGray3.TabStop = true;
            this.rdBtnGray3.Text = global::CalendarDesigner.Properties.text.Gray;
            this.rdBtnGray3.UseVisualStyleBackColor = true;
            // 
            // rdBtnBlack3
            // 
            this.rdoBlack3.AutoSize = true;
            this.rdoBlack3.Location = new System.Drawing.Point(3, 5);
            this.rdoBlack3.Name = "rdBtnBlack3";
            this.rdoBlack3.Size = new System.Drawing.Size(52, 17);
            this.rdoBlack3.TabIndex = 12;
            this.rdoBlack3.TabStop = true;
            this.rdoBlack3.Text = global::CalendarDesigner.Properties.text.Black;
            this.rdoBlack3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdBtnGray2);
            this.panel2.Controls.Add(this.rdoBlack2);
            this.panel2.Location = new System.Drawing.Point(50, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 25);
            this.panel2.TabIndex = 14;
            // 
            // rdBtnGray2
            // 
            this.rdBtnGray2.AutoSize = true;
            this.rdBtnGray2.Location = new System.Drawing.Point(59, 5);
            this.rdBtnGray2.Name = "rdBtnGray2";
            this.rdBtnGray2.Size = new System.Drawing.Size(47, 17);
            this.rdBtnGray2.TabIndex = 13;
            this.rdBtnGray2.TabStop = true;
            this.rdBtnGray2.Text = global::CalendarDesigner.Properties.text.Gray;
            this.rdBtnGray2.UseVisualStyleBackColor = true;
            // 
            // rdBtnBlack2
            // 
            this.rdoBlack2.AutoSize = true;
            this.rdoBlack2.Location = new System.Drawing.Point(3, 5);
            this.rdoBlack2.Name = "rdBtnBlack2";
            this.rdoBlack2.Size = new System.Drawing.Size(52, 17);
            this.rdoBlack2.TabIndex = 12;
            this.rdoBlack2.TabStop = true;
            this.rdoBlack2.Text = global::CalendarDesigner.Properties.text.Black;
            this.rdoBlack2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdBtnGray1);
            this.panel1.Controls.Add(this.rdoBlack1);
            this.panel1.Location = new System.Drawing.Point(50, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 25);
            this.panel1.TabIndex = 9;
            // 
            // rdBtnGray1
            // 
            this.rdBtnGray1.AutoSize = true;
            this.rdBtnGray1.Location = new System.Drawing.Point(59, 5);
            this.rdBtnGray1.Name = "rdBtnGray1";
            this.rdBtnGray1.Size = new System.Drawing.Size(47, 17);
            this.rdBtnGray1.TabIndex = 13;
            this.rdBtnGray1.TabStop = true;
            this.rdBtnGray1.Text = global::CalendarDesigner.Properties.text.Gray;
            this.rdBtnGray1.UseVisualStyleBackColor = true;
            // 
            // rdBtnBlack1
            // 
            this.rdoBlack1.AutoSize = true;
            this.rdoBlack1.Location = new System.Drawing.Point(3, 5);
            this.rdoBlack1.Name = "rdBtnBlack1";
            this.rdoBlack1.Size = new System.Drawing.Size(52, 17);
            this.rdoBlack1.TabIndex = 12;
            this.rdoBlack1.TabStop = true;
            this.rdoBlack1.Text = global::CalendarDesigner.Properties.text.Black;
            this.rdoBlack1.UseVisualStyleBackColor = true;
            // 
            // lblLine3
            // 
            this.lblLine3.AutoSize = true;
            this.lblLine3.Location = new System.Drawing.Point(6, 94);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(36, 13);
            this.lblLine3.TabIndex = 2;
            this.lblLine3.Text = "Line 3";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.Location = new System.Drawing.Point(6, 66);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(36, 13);
            this.lblLine2.TabIndex = 1;
            this.lblLine2.Text = "Line 2";
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(6, 38);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(36, 13);
            this.lblLine1.TabIndex = 0;
            this.lblLine1.Text = "Line 1";
            // 
            // pageLanguage
            // 
            this.pageLanguage.Controls.Add(this.cmbLanguage);
            this.pageLanguage.Controls.Add(this.lblLanguage);
            this.pageLanguage.Location = new System.Drawing.Point(4, 22);
            this.pageLanguage.Name = "pageLanguage";
            this.pageLanguage.Size = new System.Drawing.Size(215, 188);
            this.pageLanguage.TabIndex = 1;
            this.pageLanguage.Text = global::CalendarDesigner.Properties.text.Language;
            this.pageLanguage.UseVisualStyleBackColor = true;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            global::CalendarDesigner.Properties.text.English,
            global::CalendarDesigner.Properties.text.Norwegian});
            this.cmbLanguage.Location = new System.Drawing.Point(63, 26);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(149, 21);
            this.cmbLanguage.TabIndex = 1;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(3, 29);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(79, 228);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = global::CalendarDesigner.Properties.text.btnConfirm;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = global::CalendarDesigner.Properties.text.btnCancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(247, 257);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.settingsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.settingsTab.ResumeLayout(false);
            this.pageDateInfo.ResumeLayout(false);
            this.pageDateInfo.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageLanguage.ResumeLayout(false);
            this.pageLanguage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTab;
        private System.Windows.Forms.TabPage pageDateInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdBtnGlobal;
        private System.Windows.Forms.RadioButton rdBtnLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdBtnGray3;
        private System.Windows.Forms.RadioButton rdoBlack3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdBtnGray2;
        private System.Windows.Forms.RadioButton rdoBlack2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdBtnGray1;
        private System.Windows.Forms.RadioButton rdoBlack1;
        private System.Windows.Forms.Label lblLine3;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage pageLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
    }
}