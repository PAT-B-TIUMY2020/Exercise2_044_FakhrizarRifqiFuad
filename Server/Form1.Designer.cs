namespace Server
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
            this.label2 = new System.Windows.Forms.Label();
            this.btOff = new System.Windows.Forms.Button();
            this.btOn = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 48);
            this.label2.TabIndex = 9;
            this.label2.Text = "Server Rest Form";
            // 
            // btOff
            // 
            this.btOff.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOff.Location = new System.Drawing.Point(257, 200);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(75, 23);
            this.btOff.TabIndex = 8;
            this.btOff.Text = "OFF";
            this.btOff.UseVisualStyleBackColor = true;
            this.btOff.Click += new System.EventHandler(this.btOff_Click);
            // 
            // btOn
            // 
            this.btOn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOn.Location = new System.Drawing.Point(126, 200);
            this.btOn.Name = "btOn";
            this.btOn.Size = new System.Drawing.Size(75, 23);
            this.btOn.TabIndex = 7;
            this.btOn.Text = "ON";
            this.btOn.UseVisualStyleBackColor = true;
            this.btOn.Click += new System.EventHandler(this.btOn_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.ForeColor = System.Drawing.Color.Red;
            this.textBoxStatus.Location = new System.Drawing.Point(180, 149);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(152, 20);
            this.textBoxStatus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(483, 312);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btOff);
            this.Controls.Add(this.btOn);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label1;
    }
}

