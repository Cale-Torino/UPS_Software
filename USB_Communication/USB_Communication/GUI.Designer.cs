namespace USB_Communication
{
    partial class GUI
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
            this.textBox_VID_Read = new System.Windows.Forms.TextBox();
            this.textBox_PID_Read = new System.Windows.Forms.TextBox();
            this.textBox_UsagePage_Send = new System.Windows.Forms.TextBox();
            this.textBox_Usage_Send = new System.Windows.Forms.TextBox();
            this.textBox_RID_Send = new System.Windows.Forms.TextBox();
            this.textBox_Read = new System.Windows.Forms.TextBox();
            this.button_Read = new System.Windows.Forms.Button();
            this.label_PID_Read = new System.Windows.Forms.Label();
            this.label_VID_Read = new System.Windows.Forms.Label();
            this.gb_filter = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox6_Send = new System.Windows.Forms.TextBox();
            this.textBox5_Send = new System.Windows.Forms.TextBox();
            this.textBox4_Send = new System.Windows.Forms.TextBox();
            this.textBox3_Send = new System.Windows.Forms.TextBox();
            this.textBox2_Send = new System.Windows.Forms.TextBox();
            this.textBox1_Send = new System.Windows.Forms.TextBox();
            this.label_RID_Send = new System.Windows.Forms.Label();
            this.label_Usage_Send = new System.Windows.Forms.Label();
            this.textBox0_Send = new System.Windows.Forms.TextBox();
            this.label_UsagePage_Send = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.label_PID_Send = new System.Windows.Forms.Label();
            this.label_VID_Send = new System.Windows.Forms.Label();
            this.textBox_VID_Send = new System.Windows.Forms.TextBox();
            this.textBox_PID_Send = new System.Windows.Forms.TextBox();
            this.gb_filter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_VID_Read
            // 
            this.textBox_VID_Read.Location = new System.Drawing.Point(147, 23);
            this.textBox_VID_Read.Name = "textBox_VID_Read";
            this.textBox_VID_Read.Size = new System.Drawing.Size(100, 26);
            this.textBox_VID_Read.TabIndex = 0;
            this.textBox_VID_Read.TextChanged += new System.EventHandler(this.textBox_VID_Read_TextChanged);
            // 
            // textBox_PID_Read
            // 
            this.textBox_PID_Read.Location = new System.Drawing.Point(147, 54);
            this.textBox_PID_Read.Name = "textBox_PID_Read";
            this.textBox_PID_Read.Size = new System.Drawing.Size(100, 26);
            this.textBox_PID_Read.TabIndex = 1;
            this.textBox_PID_Read.TextChanged += new System.EventHandler(this.textBox_PID_Read_TextChanged);
            // 
            // textBox_UsagePage_Send
            // 
            this.textBox_UsagePage_Send.Location = new System.Drawing.Point(150, 85);
            this.textBox_UsagePage_Send.Name = "textBox_UsagePage_Send";
            this.textBox_UsagePage_Send.Size = new System.Drawing.Size(100, 26);
            this.textBox_UsagePage_Send.TabIndex = 2;
            this.textBox_UsagePage_Send.TextChanged += new System.EventHandler(this.textBox_UsagePage_Send_TextChanged);
            // 
            // textBox_Usage_Send
            // 
            this.textBox_Usage_Send.Location = new System.Drawing.Point(150, 117);
            this.textBox_Usage_Send.Name = "textBox_Usage_Send";
            this.textBox_Usage_Send.Size = new System.Drawing.Size(100, 26);
            this.textBox_Usage_Send.TabIndex = 3;
            this.textBox_Usage_Send.TextChanged += new System.EventHandler(this.textBox_Usage_Send_TextChanged);
            // 
            // textBox_RID_Send
            // 
            this.textBox_RID_Send.Location = new System.Drawing.Point(150, 146);
            this.textBox_RID_Send.Name = "textBox_RID_Send";
            this.textBox_RID_Send.Size = new System.Drawing.Size(100, 26);
            this.textBox_RID_Send.TabIndex = 4;
            this.textBox_RID_Send.TextChanged += new System.EventHandler(this.textBox_RID_Send_TextChanged);
            // 
            // textBox_Read
            // 
            this.textBox_Read.Location = new System.Drawing.Point(15, 146);
            this.textBox_Read.Name = "textBox_Read";
            this.textBox_Read.Size = new System.Drawing.Size(209, 26);
            this.textBox_Read.TabIndex = 15;
            // 
            // button_Read
            // 
            this.button_Read.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Read.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Read.ForeColor = System.Drawing.Color.White;
            this.button_Read.Location = new System.Drawing.Point(15, 93);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(209, 43);
            this.button_Read.TabIndex = 7;
            this.button_Read.Text = "Read";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // label_PID_Read
            // 
            this.label_PID_Read.AutoSize = true;
            this.label_PID_Read.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PID_Read.Location = new System.Drawing.Point(12, 57);
            this.label_PID_Read.Name = "label_PID_Read";
            this.label_PID_Read.Size = new System.Drawing.Size(130, 20);
            this.label_PID_Read.TabIndex = 6;
            this.label_PID_Read.Text = "Product ID (PID):";
            // 
            // label_VID_Read
            // 
            this.label_VID_Read.AutoSize = true;
            this.label_VID_Read.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label_VID_Read.Location = new System.Drawing.Point(11, 26);
            this.label_VID_Read.Name = "label_VID_Read";
            this.label_VID_Read.Size = new System.Drawing.Size(132, 20);
            this.label_VID_Read.TabIndex = 5;
            this.label_VID_Read.Text = "Vendor  ID (VID):";
            // 
            // gb_filter
            // 
            this.gb_filter.Controls.Add(this.button_Read);
            this.gb_filter.Controls.Add(this.label_PID_Read);
            this.gb_filter.Controls.Add(this.label_VID_Read);
            this.gb_filter.Controls.Add(this.textBox_Read);
            this.gb_filter.Controls.Add(this.textBox_VID_Read);
            this.gb_filter.Controls.Add(this.textBox_PID_Read);
            this.gb_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_filter.ForeColor = System.Drawing.Color.White;
            this.gb_filter.Location = new System.Drawing.Point(14, 14);
            this.gb_filter.Name = "gb_filter";
            this.gb_filter.Size = new System.Drawing.Size(253, 277);
            this.gb_filter.TabIndex = 17;
            this.gb_filter.TabStop = false;
            this.gb_filter.Text = "Device Description:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox6_Send);
            this.groupBox2.Controls.Add(this.textBox5_Send);
            this.groupBox2.Controls.Add(this.textBox4_Send);
            this.groupBox2.Controls.Add(this.textBox3_Send);
            this.groupBox2.Controls.Add(this.textBox2_Send);
            this.groupBox2.Controls.Add(this.textBox1_Send);
            this.groupBox2.Controls.Add(this.label_RID_Send);
            this.groupBox2.Controls.Add(this.label_Usage_Send);
            this.groupBox2.Controls.Add(this.textBox0_Send);
            this.groupBox2.Controls.Add(this.label_UsagePage_Send);
            this.groupBox2.Controls.Add(this.button_Send);
            this.groupBox2.Controls.Add(this.label_PID_Send);
            this.groupBox2.Controls.Add(this.label_VID_Send);
            this.groupBox2.Controls.Add(this.textBox_VID_Send);
            this.groupBox2.Controls.Add(this.textBox_PID_Send);
            this.groupBox2.Controls.Add(this.textBox_UsagePage_Send);
            this.groupBox2.Controls.Add(this.textBox_RID_Send);
            this.groupBox2.Controls.Add(this.textBox_Usage_Send);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(273, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 277);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device Description:";
            // 
            // textBox6_Send
            // 
            this.textBox6_Send.Location = new System.Drawing.Point(202, 187);
            this.textBox6_Send.Name = "textBox6_Send";
            this.textBox6_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox6_Send.TabIndex = 20;
            this.textBox6_Send.TextChanged += new System.EventHandler(this.textBox6_Send_TextChanged);
            // 
            // textBox5_Send
            // 
            this.textBox5_Send.Location = new System.Drawing.Point(171, 187);
            this.textBox5_Send.Name = "textBox5_Send";
            this.textBox5_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox5_Send.TabIndex = 19;
            this.textBox5_Send.TextChanged += new System.EventHandler(this.textBox5_Send_TextChanged);
            // 
            // textBox4_Send
            // 
            this.textBox4_Send.Location = new System.Drawing.Point(140, 187);
            this.textBox4_Send.Name = "textBox4_Send";
            this.textBox4_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox4_Send.TabIndex = 18;
            this.textBox4_Send.TextChanged += new System.EventHandler(this.textBox4_Send_TextChanged);
            // 
            // textBox3_Send
            // 
            this.textBox3_Send.Location = new System.Drawing.Point(109, 187);
            this.textBox3_Send.Name = "textBox3_Send";
            this.textBox3_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox3_Send.TabIndex = 17;
            this.textBox3_Send.TextChanged += new System.EventHandler(this.textBox3_Send_TextChanged);
            // 
            // textBox2_Send
            // 
            this.textBox2_Send.Location = new System.Drawing.Point(78, 187);
            this.textBox2_Send.Name = "textBox2_Send";
            this.textBox2_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox2_Send.TabIndex = 16;
            this.textBox2_Send.TextChanged += new System.EventHandler(this.textBox2_Send_TextChanged);
            // 
            // textBox1_Send
            // 
            this.textBox1_Send.Location = new System.Drawing.Point(47, 187);
            this.textBox1_Send.Name = "textBox1_Send";
            this.textBox1_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox1_Send.TabIndex = 15;
            this.textBox1_Send.TextChanged += new System.EventHandler(this.textBox1_Send_TextChanged);
            // 
            // label_RID_Send
            // 
            this.label_RID_Send.AutoSize = true;
            this.label_RID_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RID_Send.Location = new System.Drawing.Point(15, 151);
            this.label_RID_Send.Name = "label_RID_Send";
            this.label_RID_Send.Size = new System.Drawing.Size(126, 20);
            this.label_RID_Send.TabIndex = 14;
            this.label_RID_Send.Text = "Report ID (RID):";
            // 
            // label_Usage_Send
            // 
            this.label_Usage_Send.AutoSize = true;
            this.label_Usage_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Usage_Send.Location = new System.Drawing.Point(15, 120);
            this.label_Usage_Send.Name = "label_Usage_Send";
            this.label_Usage_Send.Size = new System.Drawing.Size(60, 20);
            this.label_Usage_Send.TabIndex = 12;
            this.label_Usage_Send.Text = "Usage:";
            // 
            // textBox0_Send
            // 
            this.textBox0_Send.Location = new System.Drawing.Point(16, 187);
            this.textBox0_Send.Name = "textBox0_Send";
            this.textBox0_Send.Size = new System.Drawing.Size(25, 26);
            this.textBox0_Send.TabIndex = 14;
            this.textBox0_Send.TextChanged += new System.EventHandler(this.textBox0_Send_TextChanged);
            // 
            // label_UsagePage_Send
            // 
            this.label_UsagePage_Send.AutoSize = true;
            this.label_UsagePage_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UsagePage_Send.Location = new System.Drawing.Point(15, 88);
            this.label_UsagePage_Send.Name = "label_UsagePage_Send";
            this.label_UsagePage_Send.Size = new System.Drawing.Size(101, 20);
            this.label_UsagePage_Send.TabIndex = 10;
            this.label_UsagePage_Send.Text = "Usage Page:";
            // 
            // button_Send
            // 
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Send.ForeColor = System.Drawing.Color.White;
            this.button_Send.Location = new System.Drawing.Point(16, 219);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(208, 43);
            this.button_Send.TabIndex = 7;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label_PID_Send
            // 
            this.label_PID_Send.AutoSize = true;
            this.label_PID_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PID_Send.Location = new System.Drawing.Point(13, 57);
            this.label_PID_Send.Name = "label_PID_Send";
            this.label_PID_Send.Size = new System.Drawing.Size(130, 20);
            this.label_PID_Send.TabIndex = 6;
            this.label_PID_Send.Text = "Product ID (PID):";
            // 
            // label_VID_Send
            // 
            this.label_VID_Send.AutoSize = true;
            this.label_VID_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label_VID_Send.Location = new System.Drawing.Point(12, 26);
            this.label_VID_Send.Name = "label_VID_Send";
            this.label_VID_Send.Size = new System.Drawing.Size(132, 20);
            this.label_VID_Send.TabIndex = 5;
            this.label_VID_Send.Text = "Vendor  ID (VID):";
            // 
            // textBox_VID_Send
            // 
            this.textBox_VID_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textBox_VID_Send.Location = new System.Drawing.Point(150, 23);
            this.textBox_VID_Send.Name = "textBox_VID_Send";
            this.textBox_VID_Send.Size = new System.Drawing.Size(100, 26);
            this.textBox_VID_Send.TabIndex = 1;
            this.textBox_VID_Send.TextChanged += new System.EventHandler(this.textBox_VIDa_TextChanged);
            // 
            // textBox_PID_Send
            // 
            this.textBox_PID_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.textBox_PID_Send.Location = new System.Drawing.Point(150, 57);
            this.textBox_PID_Send.Name = "textBox_PID_Send";
            this.textBox_PID_Send.Size = new System.Drawing.Size(100, 26);
            this.textBox_PID_Send.TabIndex = 2;
            this.textBox_PID_Send.TextChanged += new System.EventHandler(this.textBox_PIDa_TextChanged);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(569, 306);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_filter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GUI";
            this.Text = "USB Communication";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.gb_filter.ResumeLayout(false);
            this.gb_filter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_VID_Read;
        private System.Windows.Forms.TextBox textBox_PID_Read;
        private System.Windows.Forms.TextBox textBox_UsagePage_Send;
        private System.Windows.Forms.TextBox textBox_Usage_Send;
        private System.Windows.Forms.TextBox textBox_RID_Send;
        private System.Windows.Forms.TextBox textBox_Read;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.Label label_PID_Read;
        private System.Windows.Forms.Label label_VID_Read;
        private System.Windows.Forms.GroupBox gb_filter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_RID_Send;
        private System.Windows.Forms.Label label_Usage_Send;
        private System.Windows.Forms.Label label_UsagePage_Send;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label_PID_Send;
        private System.Windows.Forms.Label label_VID_Send;
        private System.Windows.Forms.TextBox textBox_VID_Send;
        private System.Windows.Forms.TextBox textBox_PID_Send;
        private System.Windows.Forms.TextBox textBox0_Send;
        private System.Windows.Forms.TextBox textBox6_Send;
        private System.Windows.Forms.TextBox textBox5_Send;
        private System.Windows.Forms.TextBox textBox4_Send;
        private System.Windows.Forms.TextBox textBox3_Send;
        private System.Windows.Forms.TextBox textBox2_Send;
        private System.Windows.Forms.TextBox textBox1_Send;
    }
}

