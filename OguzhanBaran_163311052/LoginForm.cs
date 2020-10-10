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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        
       
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Login()
        {
            try
            {
                Kullanici yeniGirisKullanici = new Kullanici();
                if (Veritabani.Login(txtUsername.Text, txtPass.Text))
                {
                    Kullanici yeniLogin = new Kullanici();
                    yeniLogin = Veritabani.KullaniciBilgileri(txtUsername.Text);
                    yeniGirisKullanici = Veritabani.KullaniciBilgileri(txtUsername.Text);
                    MessageBox.Show("Hoşgeldiniz "+yeniGirisKullanici.Ad +" "+ yeniGirisKullanici.Soyad+"!","GİRİŞ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    if (yeniGirisKullanici.Yetki == "true")
                    {
                        
                        MainForm.menuStrip.referanslar.DropDownItems[1].Enabled = true;
                        MainForm.menuStrip.referanslar.DropDownItems[2].Enabled = true;
                    }
                    this.Hide();
                    MainForm.menuStrip.referanslar.Visible = true;
                    MainForm.menuStrip.hastakabul.Enabled = true;
                    MainForm.menuStrip.raporlar.Enabled = true;
                }
                else
                    MessageBox.Show("Yanlış kullanıcı adı ve/veya şifre.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUsername.Clear();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.txtPass.KeyPress += new
System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }

        private void BtnClear_Click_1(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUsername.Clear();

        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
