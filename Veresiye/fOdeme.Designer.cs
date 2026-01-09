namespace Veresiye
{
    partial class fOdeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOdeme));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tTutarOdeme = new System.Windows.Forms.TextBox();
            this.tAciklamaOdeme = new System.Windows.Forms.TextBox();
            this.tCariAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bVazgec = new System.Windows.Forms.Button();
            this.bKaydet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.tTutarOdeme);
            this.splitContainer1.Panel2.Controls.Add(this.tAciklamaOdeme);
            this.splitContainer1.Panel2.Controls.Add(this.tCariAdi);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.bVazgec);
            this.splitContainer1.Panel2.Controls.Add(this.bKaydet);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Size = new System.Drawing.Size(403, 400);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 82);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(105, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ödeme (Yeni)";
            // 
            // tTutarOdeme
            // 
            this.tTutarOdeme.Location = new System.Drawing.Point(128, 151);
            this.tTutarOdeme.Name = "tTutarOdeme";
            this.tTutarOdeme.Size = new System.Drawing.Size(221, 24);
            this.tTutarOdeme.TabIndex = 21;
            // 
            // tAciklamaOdeme
            // 
            this.tAciklamaOdeme.Location = new System.Drawing.Point(128, 112);
            this.tAciklamaOdeme.Name = "tAciklamaOdeme";
            this.tAciklamaOdeme.Size = new System.Drawing.Size(221, 24);
            this.tAciklamaOdeme.TabIndex = 20;
            // 
            // tCariAdi
            // 
            this.tCariAdi.Location = new System.Drawing.Point(128, 69);
            this.tCariAdi.Name = "tCariAdi";
            this.tCariAdi.ReadOnly = true;
            this.tCariAdi.Size = new System.Drawing.Size(221, 24);
            this.tCariAdi.TabIndex = 19;
            this.tCariAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tarih";
            // 
            // bVazgec
            // 
            this.bVazgec.BackColor = System.Drawing.Color.Maroon;
            this.bVazgec.ForeColor = System.Drawing.Color.White;
            this.bVazgec.Location = new System.Drawing.Point(51, 200);
            this.bVazgec.Name = "bVazgec";
            this.bVazgec.Size = new System.Drawing.Size(114, 65);
            this.bVazgec.TabIndex = 17;
            this.bVazgec.Text = "Vazgeç";
            this.bVazgec.UseVisualStyleBackColor = false;
            this.bVazgec.Click += new System.EventHandler(this.bVazgec_Click);
            // 
            // bKaydet
            // 
            this.bKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bKaydet.ForeColor = System.Drawing.Color.White;
            this.bKaydet.Image = ((System.Drawing.Image)(resources.GetObject("bKaydet.Image")));
            this.bKaydet.Location = new System.Drawing.Point(171, 200);
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(178, 65);
            this.bKaydet.TabIndex = 16;
            this.bKaydet.Text = "Kaydet";
            this.bKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bKaydet.UseVisualStyleBackColor = false;
            this.bKaydet.Click += new System.EventHandler(this.bKaydet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tutar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Açıklama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cari Hesap";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(128, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 24);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // fOdeme
            // 
            this.AcceptButton = this.bKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 400);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fOdeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme Yap";
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

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tTutarOdeme;
        private System.Windows.Forms.TextBox tAciklamaOdeme;
        private System.Windows.Forms.TextBox tCariAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bVazgec;
        private System.Windows.Forms.Button bKaydet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}