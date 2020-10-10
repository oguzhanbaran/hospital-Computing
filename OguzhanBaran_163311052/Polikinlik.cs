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
    public partial class Polikinlik : Form
    {
        private static Polikinlik polikinlikInstance = new Polikinlik();
        private Polikinlik()
        {
            InitializeComponent();
        }

        public static Polikinlik PolikinlikInstance()
        {
            if (polikinlikInstance!=null)
            {
                return polikinlikInstance;
            }
            else
            {
                return polikinlikInstance = new Polikinlik();
            }
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                PolikinlikTanitma childForm;
                if (txtPolikinlik.Text == "")
                    childForm = new PolikinlikTanitma();
                else
                    childForm = new PolikinlikTanitma(txtPolikinlik.Text);
                childForm.MdiParent = Program.Owner;
                childForm.StartPosition = FormStartPosition.CenterScreen;
                childForm.Show();
                this.Close();
            }
        }
        private void Polikinlik_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtPolikinlik.KeyPress += new
System.Windows.Forms.KeyPressEventHandler(CheckEnter);
                Veritabani.ElemanEkle("polikinlikAdi", "tblPolikinlik", "", "");
                for (int i = 0; i < Veritabani.kullaniciIsimleri.Count; i++)
                {
                    txtPolikinlik.Items.Add(Veritabani.kullaniciIsimleri[i]);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void Polikinlik_FormClosed(object sender, FormClosedEventArgs e)
        {
            polikinlikInstance = null;
        }
    }
}
