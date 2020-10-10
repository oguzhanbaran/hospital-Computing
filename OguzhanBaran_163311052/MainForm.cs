using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OguzhanBaran_163311052
{
    
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }
        public static MainForm menuStrip;
        private void OpenHastaIslemleri()
        {
            HastaIslemleri childForm = HastaIslemleri.HastaIslemleriInstance();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }
        private void CheckF12(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)123 && hastakabul.Enabled == true)
            {
                OpenHastaIslemleri();
            }
            else
            {
                MessageBox.Show("Öncelikle giriş yapmalısınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            this.KeyPress += new
System.Windows.Forms.KeyPressEventHandler(CheckF12);
            Program.Owner = this;
            menuStrip = this;
            LoginForm childForm = new LoginForm();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void HastaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHastaIslemleri();
        }

        private void KullanıcıTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] formlar = Program.Owner.MdiChildren;
            for (int i = 0; i < formlar.Length; i++)
            {
                if (formlar[i].Name == "Polikinlik")
                {
                    formlar[i].Close();
                }
            }
            KullaniciTanitmaLogin childForm = KullaniciTanitmaLogin.kullaniciTanitmaLogin();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void PolikinlikTanimlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form [] formlar= Program.Owner.MdiChildren;
            for (int i = 0; i < formlar.Length; i++)
            {
                if (formlar[i].Name=="KullaniciTanitmaLogin")
                {
                    formlar[i].Close();
                }
            }
            
            Polikinlik childForm = Polikinlik.PolikinlikInstance();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void ÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Raporlar_Click(object sender, EventArgs e)
        {
            Rapor yeniMdi = Rapor.RaporInstance();
            yeniMdi.MdiParent = Program.Owner;
            yeniMdi.Show();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
