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
    public partial class Taburcu : Form
    {
        int sevkID;
        string dosyaNo;
        string sevkTarihi;
        string toplamTutar;
        public Taburcu(string dosyaNo,string sevkTarihi,string toplamTutar,int sevkid)
        {
            this.sevkID = sevkid;
            this.dosyaNo = dosyaNo;
            this.sevkTarihi = sevkTarihi;
            this.toplamTutar = toplamTutar;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Veritabani.TaburcuEt(sevkID);
                Cikis yeniCikis = new Cikis()
                {
                    CikisSaati = DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                    DosyaNo = txtDosyaNo.Text,
                    SevkTarihi = txtSevkTarihi.Text,
                    Odeme = txtOdeme.Text,
                    ToplamTutar = txtTutar.Text
                };
                Veritabani.cikisKaydet(yeniCikis);
                MessageBox.Show("Hasta taburcu edildi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Taburcu_Load(object sender, EventArgs e)
        {
            txtDosyaNo.Text = dosyaNo;
            txtSevkTarihi.Text = sevkTarihi;
            txtTutar.Text = toplamTutar;
            txtCikisTarihi.Value = DateTime.Today;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtTutar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
