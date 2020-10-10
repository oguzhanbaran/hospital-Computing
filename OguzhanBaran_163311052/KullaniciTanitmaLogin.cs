using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOHATS;


namespace OguzhanBaran_163311052
{
    public partial class KullaniciTanitmaLogin : Form
    {
        private static KullaniciTanitmaLogin kullaniciTanitmaLog = new KullaniciTanitmaLogin();

        public static KullaniciTanitmaLogin kullaniciTanitmaLogin()
        {
            if (kullaniciTanitmaLog!=null)
            {
                return kullaniciTanitmaLog;
            }
            else
            {
                return kullaniciTanitmaLog = new KullaniciTanitmaLogin();
            }
        }

        private KullaniciTanitmaLogin()
        {
            InitializeComponent();
        }
        private void KullaniciBilgi()
        {
            KullaniciTanitma childForm;
            if (txtKullanici.Text == "")
                childForm = new KullaniciTanitma();
            else
                childForm = new KullaniciTanitma(txtKullanici.Text);
            childForm.MdiParent = Program.Owner;
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
            this.Close();
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            KullaniciBilgi();
        }

        private void KullaniciTanitmaLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtKullanici.KeyPress += new
System.Windows.Forms.KeyPressEventHandler(CheckEnter);
                Veritabani.ElemanEkle("userName", "tblKullanici", "", "");
                for (int i = 0; i < Veritabani.kullaniciIsimleri.Count; i++)
                {
                    txtKullanici.Items.Add(Veritabani.kullaniciIsimleri[i]);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                KullaniciBilgi();
            }
        }

        private void KullaniciTanitmaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            kullaniciTanitmaLog = null;
        }
    }
}
