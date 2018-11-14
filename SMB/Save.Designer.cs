namespace SMB
{
    partial class Save
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_item = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BRN_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item No.";
            // 
            // TB_item
            // 
            this.TB_item.Location = new System.Drawing.Point(119, 61);
            this.TB_item.Name = "TB_item";
            this.TB_item.Size = new System.Drawing.Size(259, 20);
            this.TB_item.TabIndex = 1;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(130, 126);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(97, 23);
            this.BTN_Save.TabIndex = 2;
            this.BTN_Save.Text = "Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BRN_Cancel
            // 
            this.BRN_Cancel.Location = new System.Drawing.Point(254, 126);
            this.BRN_Cancel.Name = "BRN_Cancel";
            this.BRN_Cancel.Size = new System.Drawing.Size(97, 23);
            this.BRN_Cancel.TabIndex = 3;
            this.BRN_Cancel.Text = "Cancel";
            this.BRN_Cancel.UseVisualStyleBackColor = true;
            this.BRN_Cancel.Click += new System.EventHandler(this.BRN_Cancel_Click);
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(449, 181);
            this.Controls.Add(this.BRN_Cancel);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.TB_item);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Save";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Save_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_item;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BRN_Cancel;
    }
}