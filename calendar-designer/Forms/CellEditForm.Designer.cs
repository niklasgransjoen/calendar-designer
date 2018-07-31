using CalendarDesigner.Properties;

namespace CalendarDesigner
{
    partial class CellEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellEditForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbxCopyPrev = new System.Windows.Forms.CheckBox();
            this.cbxBigText = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(103, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = text.btnCancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 113);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = text.btnConfirm;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 64);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(166, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 1;
            // 
            // cbxCopyPrev
            // 
            this.cbxCopyPrev.AutoSize = true;
            this.cbxCopyPrev.Location = new System.Drawing.Point(12, 90);
            this.cbxCopyPrev.Name = "cbxCopyPrev";
            this.cbxCopyPrev.Size = new System.Drawing.Size(88, 17);
            this.cbxCopyPrev.TabIndex = 11;
            this.cbxCopyPrev.TabStop = false;
            this.cbxCopyPrev.Text = text.CopyPrev;
            this.cbxCopyPrev.UseVisualStyleBackColor = true;
            this.cbxCopyPrev.CheckedChanged += new System.EventHandler(this.cbxCopyPrev_CheckedChanged);
            // 
            // cbxBigText
            // 
            this.cbxBigText.AutoSize = true;
            this.cbxBigText.Location = new System.Drawing.Point(116, 90);
            this.cbxBigText.Name = "cbxBigText";
            this.cbxBigText.Size = new System.Drawing.Size(62, 17);
            this.cbxBigText.TabIndex = 12;
            this.cbxBigText.TabStop = false;
            this.cbxBigText.Text = text.BigText;
            this.cbxBigText.UseVisualStyleBackColor = true;
            this.cbxBigText.CheckedChanged += new System.EventHandler(this.cbxBigText_CheckedChanged);
            // 
            // DateEdit
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 148);
            this.Controls.Add(this.cbxBigText);
            this.Controls.Add(this.cbxCopyPrev);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = text.EditCell;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.CancelButton = btnCancel;

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbxCopyPrev;
        private System.Windows.Forms.CheckBox cbxBigText;
    }
}