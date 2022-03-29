namespace ex5
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
            this.textUser = new System.Windows.Forms.TextBox();
            this.textX = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(13, 13);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(202, 20);
            this.textUser.TabIndex = 0;
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(13, 49);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(202, 20);
            this.textX.TabIndex = 1;
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(13, 85);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(202, 20);
            this.textY.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(13, 122);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(202, 46);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(239, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(549, 425);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.Controls.Add(this.textUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

