namespace OguzhanBaran_163311052
{
    partial class DosyaBul
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
            this.txtKriter = new System.Windows.Forms.ComboBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.txtSorgu = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama Kriteri:";
            // 
            // txtKriter
            // 
            this.txtKriter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtKriter.FormattingEnabled = true;
            this.txtKriter.Items.AddRange(new object[] {
            "Adı",
            "Soyadı",
            "Kimlik No",
            "Kurum Sicil No",
            "Dosya No"});
            this.txtKriter.Location = new System.Drawing.Point(87, 13);
            this.txtKriter.Name = "txtKriter";
            this.txtKriter.Size = new System.Drawing.Size(121, 21);
            this.txtKriter.TabIndex = 1;
            // 
            // btnBul
            // 
            this.btnBul.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBul.Location = new System.Drawing.Point(442, 12);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(75, 23);
            this.btnBul.TabIndex = 2;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = false;
            this.btnBul.Click += new System.EventHandler(this.BtnBul_Click);
            // 
            // txtSorgu
            // 
            this.txtSorgu.Location = new System.Drawing.Point(214, 14);
            this.txtSorgu.Name = "txtSorgu";
            this.txtSorgu.Size = new System.Drawing.Size(222, 20);
            this.txtSorgu.TabIndex = 3;
            this.txtSorgu.TextChanged += new System.EventHandler(this.TxtSorgu_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(529, 241);
            this.dataGridView1.TabIndex = 4;
            // 
            // DosyaBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(529, 281);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSorgu);
            this.Controls.Add(this.btnBul);
            this.Controls.Add(this.txtKriter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DosyaBul";
            this.Text = "< Dosya Bul >";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DosyaBul_FormClosed);
            this.Load += new System.EventHandler(this.DosyaBul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtKriter;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.TextBox txtSorgu;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}