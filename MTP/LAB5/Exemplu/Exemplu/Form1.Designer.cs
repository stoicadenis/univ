namespace Exemplu
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
            this.numeTB = new System.Windows.Forms.TextBox();
            this.CNPTB = new System.Windows.Forms.TextBox();
            this.testCB = new System.Windows.Forms.ComboBox();
            this.incepeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numeTB
            // 
            this.numeTB.Location = new System.Drawing.Point(270, 41);
            this.numeTB.Name = "numeTB";
            this.numeTB.Size = new System.Drawing.Size(261, 22);
            this.numeTB.TabIndex = 0;
            // 
            // CNPTB
            // 
            this.CNPTB.Location = new System.Drawing.Point(270, 69);
            this.CNPTB.Name = "CNPTB";
            this.CNPTB.Size = new System.Drawing.Size(261, 22);
            this.CNPTB.TabIndex = 1;
            this.CNPTB.Leave += new System.EventHandler(this.CNPTB_Leave);
            // 
            // testCB
            // 
            this.testCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testCB.FormattingEnabled = true;
            this.testCB.Location = new System.Drawing.Point(270, 97);
            this.testCB.Name = "testCB";
            this.testCB.Size = new System.Drawing.Size(143, 24);
            this.testCB.TabIndex = 2;
            // 
            // incepeBtn
            // 
            this.incepeBtn.Location = new System.Drawing.Point(338, 142);
            this.incepeBtn.Name = "incepeBtn";
            this.incepeBtn.Size = new System.Drawing.Size(123, 33);
            this.incepeBtn.TabIndex = 3;
            this.incepeBtn.Text = "Incepe testul";
            this.incepeBtn.UseVisualStyleBackColor = true;
            this.incepeBtn.Click += new System.EventHandler(this.incepeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "CNP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Test";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 241);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incepeBtn);
            this.Controls.Add(this.testCB);
            this.Controls.Add(this.CNPTB);
            this.Controls.Add(this.numeTB);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numeTB;
        private System.Windows.Forms.TextBox CNPTB;
        private System.Windows.Forms.ComboBox testCB;
        private System.Windows.Forms.Button incepeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

