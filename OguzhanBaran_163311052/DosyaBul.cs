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
    public partial class DosyaBul : Form
    {
        private static DosyaBul DosyabulInstance = new DosyaBul();

        public static DosyaBul DosyaBulInstance()
        {
            if (DosyabulInstance!=null)
            {
                return DosyabulInstance;
            }
            else
            {
                return DosyabulInstance = new DosyaBul();
            }
        }

        private DosyaBul()
        {
            InitializeComponent();
        }
        public void Ara()
        {
            try
            {
                string kriter = "ad";
                if (txtKriter.Text == "Adı")
                kriter = "ad";
                else if (txtKriter.Text == "Soyadı")
                kriter = "soyad";
                else if (txtKriter.Text == "Kimlik No")
                kriter = "tcKimlikNo";
                else if (txtKriter.Text == "Kurum Sicil No")
                kriter = "kurumSicilNo";
                else if (txtKriter.Text == "Dosya No")
                kriter = "dosyaNo";
            dataGridView1.DataSource = Veritabani.Ara("tblHasta", kriter, txtSorgu.Text).Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Bir hata oluştu:"+e.Message,"UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void TxtSorgu_TextChanged(object sender, EventArgs e)
        {
            Ara();
        }

        private void DosyaBul_Load(object sender, EventArgs e)
        {

        }

        private void DosyaBul_FormClosed(object sender, FormClosedEventArgs e)
        {
            DosyabulInstance = null;
        }
    }
}
