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
    public partial class PolikinlikTanitma : Form
    {
        string polikinlikAdi;
        bool butonKontrol;
        public PolikinlikTanitma()
        {
            InitializeComponent();
            butonKontrol = false;
        }
        public PolikinlikTanitma(string polikinlikAdi)
        {
            InitializeComponent();
            this.polikinlikAdi = polikinlikAdi;
            butonKontrol = true;
        }

        private void PolikinlikTanitma_Load(object sender, EventArgs e)
        {
            try
            {
                if (butonKontrol == false)
                {
                    btnEkle.Enabled = true;
                    btnGuncelle.Enabled = false;
                    btnSil.Enabled = false;
                }
                else
                {
                    btnEkle.Enabled = false;
                    btnGuncelle.Enabled = true;
                    btnSil.Enabled = true;
                    Veritabani.PolikinlikBilgisi(polikinlikAdi);
                    txtAciklama.Text = Veritabani.yeniPolikinlik.Aciklama;
                    txtPolikinlikAdi.Text = polikinlikAdi;
                    if (Veritabani.yeniPolikinlik.Durum == "True")
                    {
                        chkDurum.Checked = true;
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
        private bool Kontrol()
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
            }
            return true;
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
                    Polikinlikler yeniPol = new Polikinlikler();
                    yeniPol.Aciklama = txtAciklama.Text;
                    if (chkDurum.Checked)
                        yeniPol.Durum = "True";
                    else
                        yeniPol.Durum = "False";
                    yeniPol.PolikinlikAdi = txtPolikinlikAdi.Text;
                    Veritabani.PolikinlikKaydetGuncelle(yeniPol, "Ekle");
                    MessageBox.Show("Polikinlik başarıyla kaydedildi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    txtPolikinlikAdi.Clear();
                    txtAciklama.Clear();
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Polikinlikler yeniPol = new Polikinlikler();
                    yeniPol.Aciklama = txtAciklama.Text;
                    yeniPol.Durum = chkDurum.Checked.ToString();
                    yeniPol.PolikinlikAdi = txtPolikinlikAdi.Text;
                    Veritabani.PolikinlikKaydetGuncelle(yeniPol, "Guncelle");
                    MessageBox.Show("Polikinlik başarıyla güncellendi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    txtPolikinlikAdi.Clear();
                    txtAciklama.Clear();
                    chkDurum.Checked = false;
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Veritabani.VeriSil("tblPolikinlik", "polikinlikAdi", txtPolikinlikAdi.Text, "", "");
                    MessageBox.Show("Veri silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAciklama.Clear();
                    txtPolikinlikAdi.Clear();
                    chkDurum.Checked = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
