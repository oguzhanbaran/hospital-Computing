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
    public partial class KullaniciTanitma : Form
    {
        static Kullanici kullaniciVerisi;
        private string userName;
        bool kontrol;
        public KullaniciTanitma()
        {
            InitializeComponent();
            kontrol = false;
        }
        public KullaniciTanitma(string userName)
        {
            
            InitializeComponent();
            this.userName = userName;
            kontrol = true;
        }
        public Kullanici kullaniciDoldur()
        {
            Kullanici yeniKullanici = new Kullanici();
            yeniKullanici.Ad = txtAdi.Text;
            yeniKullanici.Soyad = txtSoyad.Text;
            yeniKullanici.Kodu = txtKullanıcıKodu.Text;
            yeniKullanici.AnneAd = txtAnneAdi.Text;
            yeniKullanici.BabaAd = txtBabaAdi.Text;
            yeniKullanici.Cinsiyet =txtCinsiyet.Text;
            yeniKullanici.DogumTarihi = Convert.ToDateTime(txtDogumTarihi.Text);
            yeniKullanici.Maas = txtMaas.Text;
            yeniKullanici.Sifre = txtSifre.Text;
            yeniKullanici.TcKimlikNo = txtTcKimlik.Text;
            yeniKullanici.EvTel = txtTel.Text;
            yeniKullanici.CepTel = txtGsm.Text;
            yeniKullanici.IseBaslama = Convert.ToDateTime(txtIseBaslama.Text);
            yeniKullanici.KanGrubu = txtKanGrubu.Text;
            yeniKullanici.UserName = txtKullaniciAdi.Text;
            yeniKullanici.Unvan = txtUnvan.Text;
            yeniKullanici.DogumYeri = txtDogumYeri.Text;
            yeniKullanici.Adres = txtAdres.Text;
            yeniKullanici.MedeniHal = txtMedeniHali.Text;
            if (chckYetki.Checked==true)
            {
                yeniKullanici.Yetki = "true";
            }
            else
            {
                yeniKullanici.Yetki = "false";
            }

            return yeniKullanici;
        }
        public void txtDoldur()
        {
            txtKullanıcıKodu.Text = kullaniciVerisi.Kodu;
            txtAdi.Text = kullaniciVerisi.Ad;
            txtSoyad.Text = kullaniciVerisi.Soyad;
            txtAnneAdi.Text = kullaniciVerisi.AnneAd;
            txtBabaAdi.Text = kullaniciVerisi.BabaAd;
            txtCinsiyet.Text = kullaniciVerisi.Cinsiyet;
            txtDogumTarihi.Text = kullaniciVerisi.DogumTarihi.ToString();
            txtMaas.Text = kullaniciVerisi.Maas;
            txtMedeniHali.Text = kullaniciVerisi.MedeniHal.ToString();
            txtSifre.Text = kullaniciVerisi.Sifre;
            txtTcKimlik.Text = kullaniciVerisi.TcKimlikNo;
            txtTel.Text = kullaniciVerisi.EvTel;
            txtGsm.Text = kullaniciVerisi.CepTel;
            txtIseBaslama.Text = kullaniciVerisi.IseBaslama.ToString();
            txtKanGrubu.Text = kullaniciVerisi.KanGrubu;
            txtUnvan.Text = kullaniciVerisi.Unvan;
            txtDogumYeri.Text = kullaniciVerisi.DogumYeri;
            txtKullaniciAdi.Text = userName;
            txtAdres.Text = kullaniciVerisi.Adres;
            if (kullaniciVerisi.Yetki=="true")
            {
                chckYetki.Checked = true;
            }
        }
        bool Kontrol()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    if (tbox.Text=="")
                    {
                        return false;
                    }
                }
                if (item is ComboBox)
                {
                    ComboBox cbox = (ComboBox)item;
                    if (cbox.Text == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void KullaniciTanitma_Load(object sender, EventArgs e)
        {
            if (kontrol==true)
            {
                txtKullaniciAdi.Enabled = false;
                txtKullanıcıKodu.Enabled = false;
                kullaniciVerisi = new Kullanici();
                kullaniciVerisi =Veritabani.KullaniciBilgileri(userName);
                txtDoldur();
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                btnEkle.Enabled = false;
            }
            else
            {
                txtKullanıcıKodu.Enabled = false;
                string dosyaNo = Veritabani.maxVeri("kodu", "tblKullanici");
                int yeniDosyaNo = Convert.ToInt32(dosyaNo);
                yeniDosyaNo++;
                txtKullanıcıKodu.Text = yeniDosyaNo.ToString();
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
                btnEkle.Enabled = true;
            }
        }
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dtime = (DateTimePicker)item;
                    dtime.ResetText();
                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox mtbox = (MaskedTextBox)item;
                    mtbox.Clear();
                }
                else if (item is ComboBox)
                {
                    ComboBox cmbox = (ComboBox)item;
                    cmbox.Text = "";
                }
            }
            txtSifre.Clear();
            txtKullaniciAdi.Clear();
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kontrol())
                {
                    Kullanici yeniKullanici = kullaniciDoldur();
                    Veritabani.KullaniciKaydetGuncelle(yeniKullanici, "Ekle", "");
                    MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kontrol())
                {
                    Kullanici yeniKullanici = kullaniciDoldur();
                    Veritabani.KullaniciKaydetGuncelle(yeniKullanici, "Guncelle", txtKullaniciAdi.Text);
                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult durum = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == durum)
                {
                    Veritabani.VeriSil("tblKullanici", "kodu", txtKullanıcıKodu.Text, "", "");
                    MessageBox.Show("Veri silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    this.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
