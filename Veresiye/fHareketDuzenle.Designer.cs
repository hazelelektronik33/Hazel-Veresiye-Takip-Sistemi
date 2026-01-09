namespace Veresiye
{
    partial class fHareketDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHareketDuzenle));
            this.bKaydet = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTur = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tTutar = new System.Windows.Forms.TextBox();
            this.tAciklama = new System.Windows.Forms.TextBox();
            this.tCariAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bVazgec = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bKaydet
            // 
            this.bKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bKaydet.ForeColor = System.Drawing.Color.White;
            this.bKaydet.Image = ((System.Drawing.Image)(resources.GetObject("bKaydet.Image")));
            this.bKaydet.Location = new System.Drawing.Point(172, 195);
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(178, 65);
            this.bKaydet.TabIndex = 26;
            this.bKaydet.Text = "Kaydet";
            this.bKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bKaydet.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tTutar);
            this.splitContainer1.Panel2.Controls.Add(this.tAciklama);
            this.splitContainer1.Panel2.Controls.Add(this.tCariAdi);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.bVazgec);
            this.splitContainer1.Panel2.Controls.Add(this.bKaydet);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dtTarih);
            this.splitContainer1.Size = new System.Drawing.Size(440, 423);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTur);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 96);
            this.panel1.TabIndex = 0;
            // 
            // cbTur
            // 
            this.cbTur.FormattingEnabled = true;
            this.cbTur.Location = new System.Drawing.Point(129, 61);
            this.cbTur.Name = "cbTur";
            this.cbTur.Size = new System.Drawing.Size(221, 21);
            this.cbTur.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(88, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hareket Düzenle";
            // 
            // tTutar
            // 
            this.tTutar.Location = new System.Drawing.Point(129, 146);
            this.tTutar.Name = "tTutar";
            this.tTutar.Size = new System.Drawing.Size(221, 20);
            this.tTutar.TabIndex = 31;
            // 
            // tAciklama
            // 
            this.tAciklama.Location = new System.Drawing.Point(129, 107);
            this.tAciklama.Name = "tAciklama";
            this.tAciklama.Size = new System.Drawing.Size(221, 20);
            this.tAciklama.TabIndex = 30;
            // 
            // tCariAdi
            // 
            this.tCariAdi.Location = new System.Drawing.Point(129, 64);
            this.tCariAdi.Name = "tCariAdi";
            this.tCariAdi.ReadOnly = true;
            this.tCariAdi.Size = new System.Drawing.Size(221, 20);
            this.tCariAdi.TabIndex = 29;
            this.tCariAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tarih";
            // 
            // bVazgec
            // 
            this.bVazgec.BackColor = System.Drawing.Color.Maroon;
            this.bVazgec.ForeColor = System.Drawing.Color.White;
            this.bVazgec.Location = new System.Drawing.Point(52, 195);
            this.bVazgec.Name = "bVazgec";
            this.bVazgec.Size = new System.Drawing.Size(114, 65);
            this.bVazgec.TabIndex = 27;
            this.bVazgec.Text = "Vazgeç";
            this.bVazgec.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tutar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Açıklama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cari Hesap";
            // 
            // dtTarih
            // 
            this.dtTarih.Location = new System.Drawing.Point(129, 26);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.ShowUpDown = true;
            this.dtTarih.Size = new System.Drawing.Size(221, 20);
            this.dtTarih.TabIndex = 22;
            // 
            // fHareketDuzenle
            // 
            this.AcceptButton = this.bKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 423);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fHareketDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fHareketDuzenle";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bKaydet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tTutar;
        private System.Windows.Forms.TextBox tAciklama;
        private System.Windows.Forms.TextBox tCariAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bVazgec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.ComboBox cbTur;
    }
}