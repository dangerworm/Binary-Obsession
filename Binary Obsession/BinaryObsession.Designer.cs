namespace Binary_Obsession
{
    partial class BinaryObsession
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
            this.btnRun = new System.Windows.Forms.Button();
            this.txtGroupSize = new System.Windows.Forms.TextBox();
            this.lblGroupSize = new System.Windows.Forms.Label();
            this.lblTosses = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(268, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(59, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run!";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtGroupSize
            // 
            this.txtGroupSize.Location = new System.Drawing.Point(235, 12);
            this.txtGroupSize.Name = "txtGroupSize";
            this.txtGroupSize.Size = new System.Drawing.Size(27, 20);
            this.txtGroupSize.TabIndex = 2;
            this.txtGroupSize.Text = "7";
            // 
            // lblGroupSize
            // 
            this.lblGroupSize.AutoSize = true;
            this.lblGroupSize.Location = new System.Drawing.Point(167, 15);
            this.lblGroupSize.Name = "lblGroupSize";
            this.lblGroupSize.Size = new System.Drawing.Size(62, 13);
            this.lblGroupSize.TabIndex = 3;
            this.lblGroupSize.Text = "Group Size:";
            // 
            // lblTosses
            // 
            this.lblTosses.AutoSize = true;
            this.lblTosses.Location = new System.Drawing.Point(167, 36);
            this.lblTosses.Name = "lblTosses";
            this.lblTosses.Size = new System.Drawing.Size(0, 13);
            this.lblTosses.TabIndex = 4;
            // 
            // BinaryObsession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 46);
            this.Controls.Add(this.lblTosses);
            this.Controls.Add(this.lblGroupSize);
            this.Controls.Add(this.txtGroupSize);
            this.Controls.Add(this.btnRun);
            this.Name = "BinaryObsession";
            this.Text = "Binary Obsession";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtGroupSize;
        private System.Windows.Forms.Label lblGroupSize;
        private System.Windows.Forms.Label lblTosses;



    }
}

