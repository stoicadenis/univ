namespace Form1
{
    partial class AdaugaParfum
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
            this.lblNume = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtDescriere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValUnitara = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataExpirare = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNume.Location = new System.Drawing.Point(84, 24);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(48, 16);
            this.lblNume.TabIndex = 0;
            this.lblNume.Text = "Nume";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(139, 24);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(123, 20);
            this.txtNume.TabIndex = 1;
            // 
            // txtDescriere
            // 
            this.txtDescriere.Location = new System.Drawing.Point(139, 49);
            this.txtDescriere.Name = "txtDescriere";
            this.txtDescriere.Size = new System.Drawing.Size(123, 20);
            this.txtDescriere.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descriere";
            // 
            // txtStoc
            // 
            this.txtStoc.Location = new System.Drawing.Point(139, 75);
            this.txtStoc.Name = "txtStoc";
            this.txtStoc.Size = new System.Drawing.Size(123, 20);
            this.txtStoc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stoc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Expirare";
            // 
            // txtValUnitara
            // 
            this.txtValUnitara.Location = new System.Drawing.Point(139, 128);
            this.txtValUnitara.Name = "txtValUnitara";
            this.txtValUnitara.Size = new System.Drawing.Size(123, 20);
            this.txtValUnitara.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valoare Unitara";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 46);
            this.button1.TabIndex = 10;
            this.button1.Text = "Adauga Parfum";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataExpirare
            // 
            this.dataExpirare.CustomFormat = "yyyy-MM-dd";
            this.dataExpirare.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataExpirare.Location = new System.Drawing.Point(139, 102);
            this.dataExpirare.Name = "dataExpirare";
            this.dataExpirare.Size = new System.Drawing.Size(123, 20);
            this.dataExpirare.TabIndex = 11;
            this.dataExpirare.Value = new System.DateTime(2022, 1, 2, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 41);
            this.label5.TabIndex = 12;
            this.label5.Text = "Arunca fisierul aici pentru incarcarea automata a campurilor!";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.DragDrop += new System.Windows.Forms.DragEventHandler(this.label5_DragDrop);
            this.label5.DragOver += new System.Windows.Forms.DragEventHandler(this.label5_DragOver);
            // 
            // AdaugaParfum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 275);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataExpirare);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtValUnitara);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescriere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lblNume);
            this.Name = "AdaugaParfum";
            this.Text = "AdaugaParfum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValUnitara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dataExpirare;
        private System.Windows.Forms.Label label5;
    }
}