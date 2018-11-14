namespace SMB
{
    partial class Spaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spaces));
            this.table = new System.Windows.Forms.Label();
            this.Qty1 = new System.Windows.Forms.TextBox();
            this.Add1 = new System.Windows.Forms.Button();
            this.Des1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Des2 = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Comment = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.Des3 = new System.Windows.Forms.ComboBox();
            this.Note1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Ref1 = new System.Windows.Forms.TextBox();
            this.Note2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.Location = new System.Drawing.Point(406, 10);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(41, 13);
            this.table.TabIndex = 98;
            this.table.Text = "Spaces";
            this.table.Visible = false;
            // 
            // Qty1
            // 
            this.Qty1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qty1.Location = new System.Drawing.Point(193, 218);
            this.Qty1.Name = "Qty1";
            this.Qty1.Size = new System.Drawing.Size(47, 23);
            this.Qty1.TabIndex = 9;
            // 
            // Add1
            // 
            this.Add1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add1.Location = new System.Drawing.Point(380, 221);
            this.Add1.Name = "Add1";
            this.Add1.Size = new System.Drawing.Size(67, 27);
            this.Add1.TabIndex = 10;
            this.Add1.Text = "Add";
            this.Add1.UseVisualStyleBackColor = true;
            this.Add1.Click += new System.EventHandler(this.Add1_Click);
            // 
            // Des1
            // 
            this.Des1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Des1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Des1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Des1.FormattingEnabled = true;
            this.Des1.Location = new System.Drawing.Point(193, 62);
            this.Des1.Name = "Des1";
            this.Des1.Size = new System.Drawing.Size(254, 23);
            this.Des1.TabIndex = 1;
            this.Des1.SelectedIndexChanged += new System.EventHandler(this.Des1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(14, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 18);
            this.label6.TabIndex = 91;
            this.label6.Text = "Space Type";
            // 
            // Des2
            // 
            this.Des2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Des2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Des2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Des2.FormattingEnabled = true;
            this.Des2.Location = new System.Drawing.Point(193, 88);
            this.Des2.Name = "Des2";
            this.Des2.Size = new System.Drawing.Size(254, 23);
            this.Des2.TabIndex = 2;
            this.Des2.SelectedIndexChanged += new System.EventHandler(this.Des2_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.ForestGreen;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(538, 43);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 19);
            this.linkLabel1.TabIndex = 209;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Extract To Excel";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.Color.Maroon;
            this.Comment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Comment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Comment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comment.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Comment.Location = new System.Drawing.Point(676, 12);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(95, 32);
            this.Comment.TabIndex = 213;
            this.Comment.Text = "Add Text";
            this.Comment.UseVisualStyleBackColor = false;
            this.Comment.Click += new System.EventHandler(this.Comment_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(14, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 18);
            this.label17.TabIndex = 216;
            this.label17.Text = "Reference";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label28.Location = new System.Drawing.Point(14, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(78, 18);
            this.label28.TabIndex = 231;
            this.label28.Text = "Panel Form";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label30.Location = new System.Drawing.Point(14, 141);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(118, 18);
            this.label30.TabIndex = 234;
            this.label30.Text = "Space Description";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label31.Location = new System.Drawing.Point(14, 115);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(139, 18);
            this.label31.TabIndex = 233;
            this.label31.Text = "Space No of Modules";
            // 
            // Des3
            // 
            this.Des3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Des3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Des3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Des3.FormattingEnabled = true;
            this.Des3.Location = new System.Drawing.Point(193, 114);
            this.Des3.Name = "Des3";
            this.Des3.Size = new System.Drawing.Size(254, 23);
            this.Des3.TabIndex = 3;
            this.Des3.SelectedIndexChanged += new System.EventHandler(this.Des3_SelectedIndexChanged_1);
            // 
            // Note1
            // 
            this.Note1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note1.Location = new System.Drawing.Point(193, 140);
            this.Note1.Name = "Note1";
            this.Note1.Size = new System.Drawing.Size(460, 23);
            this.Note1.TabIndex = 7;
            this.Note1.Tag = "reference";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::SMB.Properties.Resources.Picture2;
            this.pictureBox1.Location = new System.Drawing.Point(1068, 619);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 204;
            this.pictureBox1.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(14, 219);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 18);
            this.label19.TabIndex = 290;
            this.label19.Text = "Quantity";
            // 
            // Ref1
            // 
            this.Ref1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ref1.Location = new System.Drawing.Point(193, 192);
            this.Ref1.Name = "Ref1";
            this.Ref1.Size = new System.Drawing.Size(254, 23);
            this.Ref1.TabIndex = 8;
            this.Ref1.Tag = "reference";
            // 
            // Note2
            // 
            this.Note2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note2.Location = new System.Drawing.Point(193, 166);
            this.Note2.Name = "Note2";
            this.Note2.Size = new System.Drawing.Size(460, 23);
            this.Note2.TabIndex = 317;
            this.Note2.Tag = "reference";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(14, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 18);
            this.label20.TabIndex = 318;
            this.label20.Text = "Note";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::SMB.Properties.Resources.Picture2;
            this.pictureBox2.Location = new System.Drawing.Point(503, 253);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(318, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 374;
            this.pictureBox2.TabStop = false;
            // 
            // Spaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(833, 333);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Note2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.Note1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Des3);
            this.Controls.Add(this.Des2);
            this.Controls.Add(this.table);
            this.Controls.Add(this.Qty1);
            this.Controls.Add(this.Ref1);
            this.Controls.Add(this.Add1);
            this.Controls.Add(this.Des1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Spaces";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Spcaes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Current_VoltageTransformers_FormClosing);
            this.Load += new System.EventHandler(this.Current_VoltageTransformers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Current_VoltageTransformers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label table;
        private System.Windows.Forms.TextBox Qty1;
        private System.Windows.Forms.Button Add1;
        private System.Windows.Forms.ComboBox Des1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Des2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button Comment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox Des3;
        private System.Windows.Forms.TextBox Note1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Ref1;
        private System.Windows.Forms.TextBox Note2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}