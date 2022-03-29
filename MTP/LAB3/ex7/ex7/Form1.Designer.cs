namespace ex7
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblDetalii = new System.Windows.Forms.Label();
            this.lblNume = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.lblCNP = new System.Windows.Forms.Label();
            this.lblDataNasterii = new System.Windows.Forms.Label();
            this.lblVarsta = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtCNP = new System.Windows.Forms.TextBox();
            this.txtDataNasterii = new System.Windows.Forms.TextBox();
            this.txtVarsta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Echipa";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Echipa noua";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(59, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 354);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Jucator nou";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDetalii
            // 
            this.lblDetalii.AutoSize = true;
            this.lblDetalii.Location = new System.Drawing.Point(455, 81);
            this.lblDetalii.Name = "lblDetalii";
            this.lblDetalii.Size = new System.Drawing.Size(74, 13);
            this.lblDetalii.TabIndex = 5;
            this.lblDetalii.Text = "Detalii Jucator";
            this.lblDetalii.Visible = false;
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(486, 111);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(35, 13);
            this.lblNume.TabIndex = 6;
            this.lblNume.Text = "Nume";
            this.lblNume.Visible = false;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(493, 138);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(28, 13);
            this.lblPost.TabIndex = 7;
            this.lblPost.Text = "Post";
            this.lblPost.Visible = false;
            // 
            // lblCNP
            // 
            this.lblCNP.AutoSize = true;
            this.lblCNP.Location = new System.Drawing.Point(492, 166);
            this.lblCNP.Name = "lblCNP";
            this.lblCNP.Size = new System.Drawing.Size(29, 13);
            this.lblCNP.TabIndex = 8;
            this.lblCNP.Text = "CNP";
            this.lblCNP.Visible = false;
            // 
            // lblDataNasterii
            // 
            this.lblDataNasterii.AutoSize = true;
            this.lblDataNasterii.Location = new System.Drawing.Point(455, 195);
            this.lblDataNasterii.Name = "lblDataNasterii";
            this.lblDataNasterii.Size = new System.Drawing.Size(66, 13);
            this.lblDataNasterii.TabIndex = 9;
            this.lblDataNasterii.Text = "Data nasterii";
            this.lblDataNasterii.Visible = false;
            // 
            // lblVarsta
            // 
            this.lblVarsta.AutoSize = true;
            this.lblVarsta.Location = new System.Drawing.Point(484, 224);
            this.lblVarsta.Name = "lblVarsta";
            this.lblVarsta.Size = new System.Drawing.Size(37, 13);
            this.lblVarsta.TabIndex = 10;
            this.lblVarsta.Text = "Varsta";
            this.lblVarsta.Visible = false;
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(537, 108);
            this.txtNume.Name = "txtNume";
            this.txtNume.ReadOnly = true;
            this.txtNume.Size = new System.Drawing.Size(157, 20);
            this.txtNume.TabIndex = 11;
            this.txtNume.Visible = false;
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(537, 135);
            this.txtPost.Name = "txtPost";
            this.txtPost.ReadOnly = true;
            this.txtPost.Size = new System.Drawing.Size(157, 20);
            this.txtPost.TabIndex = 12;
            this.txtPost.Visible = false;
            // 
            // txtCNP
            // 
            this.txtCNP.Location = new System.Drawing.Point(537, 163);
            this.txtCNP.Name = "txtCNP";
            this.txtCNP.ReadOnly = true;
            this.txtCNP.Size = new System.Drawing.Size(157, 20);
            this.txtCNP.TabIndex = 13;
            this.txtCNP.Visible = false;
            // 
            // txtDataNasterii
            // 
            this.txtDataNasterii.Location = new System.Drawing.Point(537, 192);
            this.txtDataNasterii.Name = "txtDataNasterii";
            this.txtDataNasterii.ReadOnly = true;
            this.txtDataNasterii.Size = new System.Drawing.Size(157, 20);
            this.txtDataNasterii.TabIndex = 14;
            this.txtDataNasterii.Visible = false;
            // 
            // txtVarsta
            // 
            this.txtVarsta.Location = new System.Drawing.Point(537, 221);
            this.txtVarsta.Name = "txtVarsta";
            this.txtVarsta.ReadOnly = true;
            this.txtVarsta.Size = new System.Drawing.Size(157, 20);
            this.txtVarsta.TabIndex = 15;
            this.txtVarsta.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtVarsta);
            this.Controls.Add(this.txtDataNasterii);
            this.Controls.Add(this.txtCNP);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lblVarsta);
            this.Controls.Add(this.lblDataNasterii);
            this.Controls.Add(this.lblCNP);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.lblDetalii);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "S";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblDetalii;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label lblCNP;
        private System.Windows.Forms.Label lblDataNasterii;
        private System.Windows.Forms.Label lblVarsta;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.TextBox txtCNP;
        private System.Windows.Forms.TextBox txtDataNasterii;
        private System.Windows.Forms.TextBox txtVarsta;
    }
}

