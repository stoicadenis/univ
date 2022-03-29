namespace Form1
{
    partial class Main
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
            this.btnParfum = new System.Windows.Forms.Button();
            this.btnCautaParfum = new System.Windows.Forms.Button();
            this.btnRaportParfum = new System.Windows.Forms.Button();
            this.btnTopClienti = new System.Windows.Forms.Button();
            this.btnVanzari = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCautare = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParfum
            // 
            this.btnParfum.Location = new System.Drawing.Point(13, 13);
            this.btnParfum.Name = "btnParfum";
            this.btnParfum.Size = new System.Drawing.Size(137, 41);
            this.btnParfum.TabIndex = 0;
            this.btnParfum.Text = "Parfumuri";
            this.btnParfum.UseVisualStyleBackColor = true;
            this.btnParfum.Click += new System.EventHandler(this.btnParfum_Click);
            // 
            // btnCautaParfum
            // 
            this.btnCautaParfum.Location = new System.Drawing.Point(345, 8);
            this.btnCautaParfum.Name = "btnCautaParfum";
            this.btnCautaParfum.Size = new System.Drawing.Size(137, 29);
            this.btnCautaParfum.TabIndex = 1;
            this.btnCautaParfum.Text = "Cauta Parfum";
            this.btnCautaParfum.UseVisualStyleBackColor = true;
            this.btnCautaParfum.Click += new System.EventHandler(this.btnCautaParfum_Click);
            // 
            // btnRaportParfum
            // 
            this.btnRaportParfum.Location = new System.Drawing.Point(13, 60);
            this.btnRaportParfum.Name = "btnRaportParfum";
            this.btnRaportParfum.Size = new System.Drawing.Size(137, 41);
            this.btnRaportParfum.TabIndex = 2;
            this.btnRaportParfum.Text = "Raport cel mai vandut parfum";
            this.btnRaportParfum.UseVisualStyleBackColor = true;
            this.btnRaportParfum.Click += new System.EventHandler(this.btnRaportParfum_Click);
            // 
            // btnTopClienti
            // 
            this.btnTopClienti.Location = new System.Drawing.Point(13, 107);
            this.btnTopClienti.Name = "btnTopClienti";
            this.btnTopClienti.Size = new System.Drawing.Size(137, 41);
            this.btnTopClienti.TabIndex = 3;
            this.btnTopClienti.Text = "Top 3 clienti";
            this.btnTopClienti.UseVisualStyleBackColor = true;
            this.btnTopClienti.Click += new System.EventHandler(this.btnTopClienti_Click);
            // 
            // btnVanzari
            // 
            this.btnVanzari.Location = new System.Drawing.Point(14, 154);
            this.btnVanzari.Name = "btnVanzari";
            this.btnVanzari.Size = new System.Drawing.Size(137, 41);
            this.btnVanzari.TabIndex = 4;
            this.btnVanzari.Text = "Vanzari parfumuri pe luna curenta";
            this.btnVanzari.UseVisualStyleBackColor = true;
            this.btnVanzari.Click += new System.EventHandler(this.btnVanzari_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(173, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(741, 395);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(173, 13);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(166, 20);
            this.txtCautare.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 450);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnVanzari);
            this.Controls.Add(this.btnTopClienti);
            this.Controls.Add(this.btnRaportParfum);
            this.Controls.Add(this.btnCautaParfum);
            this.Controls.Add(this.btnParfum);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParfum;
        private System.Windows.Forms.Button btnCautaParfum;
        private System.Windows.Forms.Button btnRaportParfum;
        private System.Windows.Forms.Button btnTopClienti;
        private System.Windows.Forms.Button btnVanzari;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCautare;
    }
}