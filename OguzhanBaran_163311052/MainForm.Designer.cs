namespace OguzhanBaran_163311052
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.referanslar = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polikinlikTanimlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciTanimlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastakabul = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referanslar,
            this.hastakabul,
            this.raporlar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // referanslar
            // 
            this.referanslar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.polikinlikTanimlamaToolStripMenuItem,
            this.kullaniciTanimlamaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.referanslar.Name = "referanslar";
            this.referanslar.Size = new System.Drawing.Size(77, 20);
            this.referanslar.Text = "Referanslar";
            this.referanslar.Visible = false;
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // polikinlikTanimlamaToolStripMenuItem
            // 
            this.polikinlikTanimlamaToolStripMenuItem.Enabled = false;
            this.polikinlikTanimlamaToolStripMenuItem.Name = "polikinlikTanimlamaToolStripMenuItem";
            this.polikinlikTanimlamaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.polikinlikTanimlamaToolStripMenuItem.Text = "Polikinlik Tanımlama";
            this.polikinlikTanimlamaToolStripMenuItem.Click += new System.EventHandler(this.PolikinlikTanimlamaToolStripMenuItem_Click);
            // 
            // kullaniciTanimlamaToolStripMenuItem
            // 
            this.kullaniciTanimlamaToolStripMenuItem.Enabled = false;
            this.kullaniciTanimlamaToolStripMenuItem.Name = "kullaniciTanimlamaToolStripMenuItem";
            this.kullaniciTanimlamaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.kullaniciTanimlamaToolStripMenuItem.Text = "Kullanıcı Tanımlama";
            this.kullaniciTanimlamaToolStripMenuItem.Click += new System.EventHandler(this.KullanıcıTanımlamaToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.ÇıkışToolStripMenuItem_Click);
            // 
            // hastakabul
            // 
            this.hastakabul.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hastaİşlemleriToolStripMenuItem});
            this.hastakabul.Enabled = false;
            this.hastakabul.Name = "hastakabul";
            this.hastakabul.Size = new System.Drawing.Size(82, 20);
            this.hastakabul.Text = "Hasta Kabul";
            // 
            // hastaİşlemleriToolStripMenuItem
            // 
            this.hastaİşlemleriToolStripMenuItem.Name = "hastaİşlemleriToolStripMenuItem";
            this.hastaİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.hastaİşlemleriToolStripMenuItem.Text = "Hasta İşlemleri   F2";
            this.hastaİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.HastaİşlemleriToolStripMenuItem_Click);
            // 
            // raporlar
            // 
            this.raporlar.Enabled = false;
            this.raporlar.Name = "raporlar";
            this.raporlar.Size = new System.Drawing.Size(63, 20);
            this.raporlar.Text = "Raporlar";
            this.raporlar.Click += new System.EventHandler(this.Raporlar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 811);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sağlık Ocağı Hasta Takip Sistemi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polikinlikTanimlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciTanimlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastaİşlemleriToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem hastakabul;
        public System.Windows.Forms.ToolStripMenuItem raporlar;
        public System.Windows.Forms.ToolStripMenuItem referanslar;
    }
}

