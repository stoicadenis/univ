namespace Exemplu
{
    partial class Form2
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
            this.numeCandidatTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nr_intrebariTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.punctajTB = new System.Windows.Forms.TextBox();
            this.raspunsCorectTB = new System.Windows.Forms.TextBox();
            this.urm_intrebareBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.intreabreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numeCandidatTB
            // 
            this.numeCandidatTB.Location = new System.Drawing.Point(83, 12);
            this.numeCandidatTB.Name = "numeCandidatTB";
            this.numeCandidatTB.Size = new System.Drawing.Size(204, 22);
            this.numeCandidatTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Candidat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nr. intrebari/test";
            // 
            // nr_intrebariTB
            // 
            this.nr_intrebariTB.Location = new System.Drawing.Point(553, 12);
            this.nr_intrebariTB.Name = "nr_intrebariTB";
            this.nr_intrebariTB.Size = new System.Drawing.Size(83, 22);
            this.nr_intrebariTB.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(642, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 105);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 123);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(676, 268);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // punctajTB
            // 
            this.punctajTB.Location = new System.Drawing.Point(120, 398);
            this.punctajTB.Name = "punctajTB";
            this.punctajTB.Size = new System.Drawing.Size(100, 22);
            this.punctajTB.TabIndex = 6;
            // 
            // raspunsCorectTB
            // 
            this.raspunsCorectTB.Location = new System.Drawing.Point(695, 401);
            this.raspunsCorectTB.Name = "raspunsCorectTB";
            this.raspunsCorectTB.Size = new System.Drawing.Size(93, 22);
            this.raspunsCorectTB.TabIndex = 7;
            // 
            // urm_intrebareBtn
            // 
            this.urm_intrebareBtn.Location = new System.Drawing.Point(473, 397);
            this.urm_intrebareBtn.Name = "urm_intrebareBtn";
            this.urm_intrebareBtn.Size = new System.Drawing.Size(163, 31);
            this.urm_intrebareBtn.TabIndex = 8;
            this.urm_intrebareBtn.Text = "Urmatoarea intrebare";
            this.urm_intrebareBtn.UseVisualStyleBackColor = true;
            this.urm_intrebareBtn.Click += new System.EventHandler(this.urm_intrebareBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Punctaj";
            // 
            // intreabreLabel
            // 
            this.intreabreLabel.AutoSize = true;
            this.intreabreLabel.Location = new System.Drawing.Point(31, 100);
            this.intreabreLabel.Name = "intreabreLabel";
            this.intreabreLabel.Size = new System.Drawing.Size(65, 17);
            this.intreabreLabel.TabIndex = 10;
            this.intreabreLabel.Text = "Intrebare";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.intreabreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urm_intrebareBtn);
            this.Controls.Add(this.raspunsCorectTB);
            this.Controls.Add(this.punctajTB);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nr_intrebariTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeCandidatTB);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numeCandidatTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nr_intrebariTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox punctajTB;
        private System.Windows.Forms.TextBox raspunsCorectTB;
        private System.Windows.Forms.Button urm_intrebareBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label intreabreLabel;
    }
}