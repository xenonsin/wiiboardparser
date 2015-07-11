namespace WiiBoardParser
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
            this.groupBox_RawWeight = new System.Windows.Forms.GroupBox();
            this.label_rwBR = new System.Windows.Forms.Label();
            this.label_rwBL = new System.Windows.Forms.Label();
            this.label_rwTR = new System.Windows.Forms.Label();
            this.label_rwTL = new System.Windows.Forms.Label();
            this.label_rwWT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox_RawWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_RawWeight
            // 
            this.groupBox_RawWeight.Controls.Add(this.label_rwBR);
            this.groupBox_RawWeight.Controls.Add(this.label_rwBL);
            this.groupBox_RawWeight.Controls.Add(this.label_rwTR);
            this.groupBox_RawWeight.Controls.Add(this.label_rwTL);
            this.groupBox_RawWeight.Controls.Add(this.label_rwWT);
            this.groupBox_RawWeight.Location = new System.Drawing.Point(62, 47);
            this.groupBox_RawWeight.Name = "groupBox_RawWeight";
            this.groupBox_RawWeight.Size = new System.Drawing.Size(150, 139);
            this.groupBox_RawWeight.TabIndex = 4;
            this.groupBox_RawWeight.TabStop = false;
            this.groupBox_RawWeight.Text = "Raw Weight";
            // 
            // label_rwBR
            // 
            this.label_rwBR.AutoSize = true;
            this.label_rwBR.Location = new System.Drawing.Point(101, 76);
            this.label_rwBR.Name = "label_rwBR";
            this.label_rwBR.Size = new System.Drawing.Size(22, 13);
            this.label_rwBR.TabIndex = 0;
            this.label_rwBR.Text = "BR";
            // 
            // label_rwBL
            // 
            this.label_rwBL.AutoSize = true;
            this.label_rwBL.Location = new System.Drawing.Point(25, 76);
            this.label_rwBL.Name = "label_rwBL";
            this.label_rwBL.Size = new System.Drawing.Size(20, 13);
            this.label_rwBL.TabIndex = 0;
            this.label_rwBL.Text = "BL";
            // 
            // label_rwTR
            // 
            this.label_rwTR.AutoSize = true;
            this.label_rwTR.Location = new System.Drawing.Point(101, 32);
            this.label_rwTR.Name = "label_rwTR";
            this.label_rwTR.Size = new System.Drawing.Size(22, 13);
            this.label_rwTR.TabIndex = 0;
            this.label_rwTR.Text = "TR";
            // 
            // label_rwTL
            // 
            this.label_rwTL.AutoSize = true;
            this.label_rwTL.Location = new System.Drawing.Point(25, 32);
            this.label_rwTL.Name = "label_rwTL";
            this.label_rwTL.Size = new System.Drawing.Size(20, 13);
            this.label_rwTL.TabIndex = 0;
            this.label_rwTL.Text = "TL";
            // 
            // label_rwWT
            // 
            this.label_rwWT.AutoSize = true;
            this.label_rwWT.Location = new System.Drawing.Point(63, 113);
            this.label_rwWT.Name = "label_rwWT";
            this.label_rwWT.Size = new System.Drawing.Size(25, 13);
            this.label_rwWT.TabIndex = 0;
            this.label_rwWT.Text = "WT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Keno\'s Balance Board to Unity Parser";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(49, 202);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(183, 48);
            this.button_Connect.TabIndex = 6;
            this.button_Connect.Text = "Connect to Wii balance board";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_RawWeight);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_RawWeight.ResumeLayout(false);
            this.groupBox_RawWeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_RawWeight;
        private System.Windows.Forms.Label label_rwBR;
        private System.Windows.Forms.Label label_rwBL;
        private System.Windows.Forms.Label label_rwTR;
        private System.Windows.Forms.Label label_rwTL;
        private System.Windows.Forms.Label label_rwWT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Connect;
    }
}

