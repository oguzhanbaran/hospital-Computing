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
    public partial class HastaBilgileri : Form
    {
        bool dosyaNoVarmi;
        string dosyaNo;
        public HastaBilgileri()
        {
            InitializeComponent();
            dosyaNoVarmi = false;
        }
        public HastaBilgileri(string dosyaNo)
        {
            this.dosyaNo = dosyaNo;
            dosyaNoVarmi = true;
            InitializeComponent();
        }
        private void HastaBilgileri_Load(object sender, EventArgs e)
        {
            Hasta hastaBilgisi;
            if (dosyaNoVarmi==true)
            {
                btnYeni.Enabled = false;
                txtTcKimlik.Enabled = false;
                hastaBilgisi = Veritabani.HastaIslemleriGetir(dosyaNo);
                txtDosyaNo.Text = dosyaNo;
                txtTcKimlik.Text = hastaBilgisi.TcNo;
                txtAdi.Text = hastaBilgisi.Adi;
                txtSoyad.Text = hastaBilgisi.Soyadi;
                txtDogumYeri.Text = hastaBilgisi.DogumYeri;
                txtDogumTarihi.Value = hastaBilgisi.DogumTarihi;
                txtBabaAdi.Text = hastaBilgisi.BabaAdi;
                txtAnneAdi.Text = hastaBilgisi.AnneAdi;
                txtCinsiyet.Text = hastaBilgisi.Cinsiyet.ToString();
                txtMedeniHali.Text = hastaBilgisi.MedeniDurum.ToString();
                txtKanGrubu.Text = hastaBilgisi.KanGrubu;
                txtAdres.Text = hastaBilgisi.Adres;
                txtTel.Text = hastaBilgisi.TelefonNo;
                txtYakınNo.Text = hastaBilgisi.YakinNo;
                txtKurumSicilNo.Text = hastaBilgisi.KurumSicilNo;
                txtKurumAdi.Text = hastaBilgisi.KurumAdi;
                txtYakınKurumSicilNo.Text = hastaBilgisi.YakinKurumSicilNo;
                txtYakinKurumAdi.Text = hastaBilgisi.YakinKurumAdi;
            }
            else
            {
                int yeniDosyaNo = Convert.ToInt32(Veritabani.maxVeri("dosyaNo","tblHasta"));
                yeniDosyaNo++;
                txtDosyaNo.Text = yeniDosyaNo.ToString();
                btnGuncelle.Enabled = false;
                btnSil.Enabled = false;
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Hasta BilgiDoldur()
        {
            Hasta guncelHasta = new Hasta()
            {
                DosyaNo = txtDosyaNo.Text,
                Adi = txtAdi.Text,
                Soyadi = txtSoyad.Text,
                TcNo = txtTcKimlik.Text,
                DogumYeri = txtDogumYeri.Text,
                DogumTarihi = txtDogumTarihi.Value,
                BabaAdi = txtBabaAdi.Text,
                AnneAdi = txtAnneAdi.Text,
                Cinsiyet = txtCinsiyet.Text,
                MedeniDurum = txtMedeniHali.Text,
                KanGrubu = txtKanGrubu.Text,
                Adres = txtAdres.Text,
                TelefonNo = txtTel.Text,
                YakinNo = txtYakınNo.Text,
                KurumSicilNo = txtKurumSicilNo.Text,
                KurumAdi = txtKurumAdi.Text,
                YakinKurumAdi = txtYakinKurumAdi.Text,
                YakinKurumSicilNo = txtYakınKurumSicilNo.Text
            };
            
            return guncelHasta;
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
        }
        bool Kontrol()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    if (tbox.Text == "")
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
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kontrol())
                {
                    Veritabani.HastaGuncelle(BilgiDoldur(), "Guncelle", txtDosyaNo.Text);
                    MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
        }

        private void BtnYeni_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kontrol())
                {
                    Veritabani.HastaGuncelle(BilgiDoldur(), "Ekle", "");
                    MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
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
                    Veritabani.VeriSil("tblHasta", "dosyaNo", txtDosyaNo.Text, "", "");
                    MessageBox.Show("Veri silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
        }
    }
}
