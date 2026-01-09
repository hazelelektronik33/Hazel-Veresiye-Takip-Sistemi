
namespace Veresiye
{
    partial class fLojin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLojin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tKullaniciAdi = new System.Windows.Forms.TextBox();
            this.tParola = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bCikis = new System.Windows.Forms.Button();
            this.bGiris = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tKullaniciAdi
            // 
            this.tKullaniciAdi.Location = new System.Drawing.Point(408, 121);
            this.tKullaniciAdi.Name = "tKullaniciAdi";
            this.tKullaniciAdi.Size = new System.Drawing.Size(221, 26);
            this.tKullaniciAdi.TabIndex = 1;
            // 
            // tParola
            // 
            this.tParola.Location = new System.Drawing.Point(408, 181);
            this.tParola.Name = "tParola";
            this.tParola.PasswordChar = '*';
            this.tParola.Size = new System.Drawing.Size(221, 26);
            this.tParola.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(171, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hazel Veresiye Defteri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(258, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kullanıcı Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(320, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parola :";
            // 
            // bCikis
            // 
            this.bCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.bCikis.FlatAppearance.BorderSize = 0;
            this.bCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCikis.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCikis.ForeColor = System.Drawing.Color.White;
            this.bCikis.Location = new System.Drawing.Point(280, 245);
            this.bCikis.Name = "bCikis";
            this.bCikis.Size = new System.Drawing.Size(97, 88);
            this.bCikis.TabIndex = 6;
            this.bCikis.Text = "Vazgeç";
            this.bCikis.UseVisualStyleBackColor = false;
            this.bCikis.Click += new System.EventHandler(this.bCikis_Click);
            // 
            // bGiris
            // 
            this.bGiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.bGiris.FlatAppearance.BorderSize = 0;
            this.bGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGiris.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bGiris.ForeColor = System.Drawing.Color.White;
            this.bGiris.Location = new System.Drawing.Point(408, 245);
            this.bGiris.Name = "bGiris";
            this.bGiris.Size = new System.Drawing.Size(221, 88);
            this.bGiris.TabIndex = 7;
            this.bGiris.Text = "Giriş Yap";
            this.bGiris.UseVisualStyleBackColor = false;
            this.bGiris.Click += new System.EventHandler(this.bGiris_Click);
            // 
            // fLojin
            // 
            this.AcceptButton = this.bGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 385);
            this.Controls.Add(this.bGiris);
            this.Controls.Add(this.bCikis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tParola);
            this.Controls.Add(this.tKullaniciAdi);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fLojin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hazel Veresiye Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tKullaniciAdi;
        private System.Windows.Forms.TextBox tParola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bCikis;
        private System.Windows.Forms.Button bGiris;
    }
}

