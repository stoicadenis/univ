namespace Form1
{
    partial class CumparaParfum
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
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lblNume = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantitate = new System.Windows.Forms.TextBox();
            this.btnContinua = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtNume
            // 
            this.txtNume.Enabled = false;
            this.txtNume.Location = new System.Drawing.Point(171, 6);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(100, 20);
            this.txtNume.TabIndex = 0;
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNume.Location = new System.Drawing.Point(65, 9);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(100, 16);
            this.lblNume.TabIndex = 1;
            this.lblNume.Text = "Nume Parfum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pret";
            // 
            // txtPret
            // 
            this.txtPret.Enabled = false;
            this.txtPret.Location = new System.Drawing.Point(171, 32);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(100, 20);
            this.txtPret.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantitate";
            // 
            // txtCantitate
            // 
            this.txtCantitate.Location = new System.Drawing.Point(171, 58);
            this.txtCantitate.Name = "txtCantitate";
            this.txtCantitate.Size = new System.Drawing.Size(100, 20);
            this.txtCantitate.TabIndex = 4;
            this.txtCantitate.TextChanged += new System.EventHandler(this.txtCantitate_TextChanged);
            // 
            // btnContinua
            // 
            this.btnContinua.Enabled = false;
            this.btnContinua.Location = new System.Drawing.Point(132, 94);
            this.btnContinua.Name = "btnContinua";
            this.btnContinua.Size = new System.Drawing.Size(139, 23);
            this.btnContinua.TabIndex = 6;
            this.btnContinua.Text = "Continua spre detalii client";
            this.btnContinua.UseVisualStyleBackColor = true;
            this.btnContinua.Click += new System.EventHandler(this.btnContinua_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(68, 135);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 297);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // CumparaParfum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnContinua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantitate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.txtNume);
            this.Name = "CumparaParfum";
            this.Text = "CumparaParfum";
            this.Load += new System.EventHandler(this.CumparaParfum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantitate;
        private System.Windows.Forms.Button btnContinua;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}