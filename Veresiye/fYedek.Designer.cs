namespace Veresiye
{
    partial class fYedek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fYedek));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bYedekAl = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKlasoruAc = new System.Windows.Forms.Button();
            this.btnYedekSil = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lstBackups = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 219);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.lblLastBackup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bYedekAl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Yedek Al";
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.AutoSize = true;
            this.lblLastBackup.Location = new System.Drawing.Point(10, 168);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(35, 13);
            this.lblLastBackup.TabIndex = 5;
            this.lblLastBackup.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Verilerinizin güvenliği için düzenli yedek almanız önerilir.";
            // 
            // bYedekAl
            // 
            this.bYedekAl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bYedekAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.bYedekAl.FlatAppearance.BorderSize = 0;
            this.bYedekAl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.bYedekAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bYedekAl.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bYedekAl.ForeColor = System.Drawing.Color.White;
            this.bYedekAl.Image = ((System.Drawing.Image)(resources.GetObject("bYedekAl.Image")));
            this.bYedekAl.Location = new System.Drawing.Point(166, 79);
            this.bYedekAl.Name = "bYedekAl";
            this.bYedekAl.Size = new System.Drawing.Size(81, 67);
            this.bYedekAl.TabIndex = 3;
            this.bYedekAl.Text = "Yedek Al";
            this.bYedekAl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bYedekAl.UseVisualStyleBackColor = false;
            this.bYedekAl.Click += new System.EventHandler(this.bYedekAl_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.btnKlasoruAc);
            this.groupBox2.Controls.Add(this.btnYedekSil);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(400, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 213);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yedek Yükle";
            // 
            // btnKlasoruAc
            // 
            this.btnKlasoruAc.BackColor = System.Drawing.Color.DeepPink;
            this.btnKlasoruAc.FlatAppearance.BorderSize = 0;
            this.btnKlasoruAc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnKlasoruAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKlasoruAc.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKlasoruAc.ForeColor = System.Drawing.Color.White;
            this.btnKlasoruAc.Image = ((System.Drawing.Image)(resources.GetObject("btnKlasoruAc.Image")));
            this.btnKlasoruAc.Location = new System.Drawing.Point(195, 79);
            this.btnKlasoruAc.Name = "btnKlasoruAc";
            this.btnKlasoruAc.Size = new System.Drawing.Size(81, 67);
            this.btnKlasoruAc.TabIndex = 6;
            this.btnKlasoruAc.Text = "Klasör Aç";
            this.btnKlasoruAc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKlasoruAc.UseVisualStyleBackColor = false;
            this.btnKlasoruAc.Click += new System.EventHandler(this.btnKlasoruAc_Click);
            // 
            // btnYedekSil
            // 
            this.btnYedekSil.BackColor = System.Drawing.Color.DimGray;
            this.btnYedekSil.FlatAppearance.BorderSize = 0;
            this.btnYedekSil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnYedekSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYedekSil.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYedekSil.ForeColor = System.Drawing.Color.White;
            this.btnYedekSil.Image = ((System.Drawing.Image)(resources.GetObject("btnYedekSil.Image")));
            this.btnYedekSil.Location = new System.Drawing.Point(102, 79);
            this.btnYedekSil.Name = "btnYedekSil";
            this.btnYedekSil.Size = new System.Drawing.Size(81, 67);
            this.btnYedekSil.TabIndex = 5;
            this.btnYedekSil.Text = "Yedek Sil";
            this.btnYedekSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnYedekSil.UseVisualStyleBackColor = false;
            this.btnYedekSil.Click += new System.EventHandler(this.btnYedekSil_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.Location = new System.Drawing.Point(9, 79);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(81, 67);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Yedek Yükle";
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lstBackups, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 219);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lstBackups
            // 
            this.lstBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lstBackups.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lstBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBackups.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lstBackups.Location = new System.Drawing.Point(3, 3);
            this.lstBackups.Name = "lstBackups";
            this.lstBackups.Size = new System.Drawing.Size(788, 103);
            this.lstBackups.TabIndex = 0;
            this.lstBackups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lstBackups_CellContentClick);
            // 
            // fYedek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fYedek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedek Al";
            this.Load += new System.EventHandler(this.fYedek_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBackups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bYedekAl;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKlasoruAc;
        private System.Windows.Forms.Button btnYedekSil;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView lstBackups;
    }
}