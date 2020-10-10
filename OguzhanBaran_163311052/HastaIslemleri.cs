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
using System.Collections;
using System.Drawing.Printing;

namespace OguzhanBaran_163311052
{
    public partial class HastaIslemleri : Form
    {
        Hasta hastaBilgisi;
        DataTable veriTablo = new DataTable();
        private static HastaIslemleri hastaIslemleriInstance = new HastaIslemleri();
        private HastaIslemleri()
        {
            InitializeComponent();
        }
        public static HastaIslemleri HastaIslemleriInstance()
        {
            if (hastaIslemleriInstance!=null)
            {
                return hastaIslemleriInstance;
            }
            else
            {
                return hastaIslemleriInstance = new HastaIslemleri();
            }
        }
        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            Doldur();
        }

        private void HastaIslemleri_Load(object sender, EventArgs e)
        {
            try
            {
                veriTablo.Columns.Add("polikinlik", typeof(string));
                veriTablo.Columns.Add("sira", typeof(string));
                veriTablo.Columns.Add("drKod", typeof(string));
                veriTablo.Columns.Add("saat", typeof(string));
                veriTablo.Columns.Add("yapilanIslem", typeof(string));
                veriTablo.Columns.Add("miktar", typeof(string));
                veriTablo.Columns.Add("birimFiyat", typeof(string));
                veriTablo.Columns.Add("dosyaNo", typeof(string));
                veriTablo.Columns.Add("sevkTarihi", typeof(string));
                this.txtDosyaNo.KeyPress += new
    System.Windows.Forms.KeyPressEventHandler(CheckEnter);
                Veritabani.ElemanEkle("polikinlikAdi", "tblPolikinlik", "True", "durum");
                for (int i = 0; i < Veritabani.kullaniciIsimleri.Count; i++)
                {
                    txtPolikinlik.Items.Add(Veritabani.kullaniciIsimleri[i]);
                }
                Veritabani.ElemanEkle("islemAdi", "tblIslem", "", "");
                for (int i = 0; i < Veritabani.kullaniciIsimleri.Count; i++)
                {
                    txtYapilanIslem.Items.Add(Veritabani.kullaniciIsimleri[i]);
                }
                Veritabani.ElemanEkle("kodu", "tblKullanici", "Doktor", "unvan");
                for (int i = 0; i < Veritabani.kullaniciIsimleri.Count; i++)
                {
                    txtDrKodu.Items.Add(Veritabani.kullaniciIsimleri[i]);
                }
                txtPolikinlik.Text = txtPolikinlik.Items[0].ToString();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            

        }
        private void Doldur()
        {
            try
            {
                string deger = Veritabani.VeriAra("tblHasta", "dosyaNo", txtDosyaNo.Text, "dosyaNo");
                if (deger != "")
                {
                    hastaBilgisi = Veritabani.HastaIslemleriGetir(txtDosyaNo.Text);
                    txtHastaAdi.Text = hastaBilgisi.Adi;
                    txtHastaSoyadi.Text = hastaBilgisi.Soyadi;
                    txtKurumAdi.Text = hastaBilgisi.KurumAdi;
                    for (int i = 0; i < hastaBilgisi.sevkTarihleri.Count; i++)
                    {
                        if (!txtOncekiIslem.Items.Contains(hastaBilgisi.sevkTarihleri[i]))
                            txtOncekiIslem.Items.Add(hastaBilgisi.sevkTarihleri[i]);

                    }
                }
                else if (deger == "" && txtDosyaNo.Text != "")
                {
                    MessageBox.Show("Bu dosya numarasına sahip hasta bulunamadı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DosyaBul childForm = DosyaBul.DosyaBulInstance();
                    childForm.BringToFront();
                    childForm.MdiParent = Program.Owner;
                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Show();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
            
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            txtOncekiIslem.Items.Clear();
            if (e.KeyChar == (char)13)
            {
                    toplam = 0;
                    Doldur();
            }
        }
        string drKodu;
        private void BtnGit_Click(object sender, EventArgs e)
        {
            try
            {
                BtnTaburcu.Enabled = true;
                btnSecSil.Enabled = true;
                int z = 0;
                lblFiyat.Text = "";
                Hasta hastaBilgisi = Veritabani.TaburcuKontrol(txtOncekiIslem.Text, txtDosyaNo.Text);
                dataGridView1.DataSource = Veritabani.IslemAra("tblSevk", txtOncekiIslem.Text, txtDosyaNo.Text).Tables[0];
                if (dataGridView1.Rows.Count > 0)
                {
                        
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        
                        DataGridViewCellStyle renk = new DataGridViewCellStyle();
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["taburcu"].Value) == true)
                        {

                            renk.BackColor = Color.White;
                            renk.ForeColor = Color.Black;
                        }
                        else
                        {
                            z++;
                            renk.BackColor = Color.Red;
                            renk.ForeColor = Color.Black;
                        }
                        dataGridView1.Rows[i].DefaultCellStyle = renk;
                    }
                }

                if (z == 0)
                {
                    MessageBox.Show("Hasta bu sevkten taburcu edilmiş.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnTaburcu.Enabled = false;
                }
                else
                {
                    BtnTaburcu.Enabled = true;
                    lblFiyat.Text = Veritabani.FiyatHesapla(txtDosyaNo.Text, txtOncekiIslem.Text).ToString();
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
            
        }

        private void TxtYapilanIslem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtBirimFiyat.Text = Veritabani.VeriAra("tblIslem", "islemAdi", txtYapilanIslem.Text, "birimFiyat");
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void HastaBilgileriAc()
        {
            try
            {
                if (txtDosyaNo.Text == "")
                {
                    HastaBilgileri childForm = new HastaBilgileri();
                    childForm.MdiParent = Program.Owner;
                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Show();
                }
                else
                {
                    string deger = Veritabani.VeriAra("tblHasta", "dosyaNo", txtDosyaNo.Text, "dosyaNo");
                    if (deger != "")
                    {
                        HastaBilgileri childForm = new HastaBilgileri(txtDosyaNo.Text);
                        childForm.MdiParent = Program.Owner;
                        childForm.StartPosition = FormStartPosition.CenterScreen;
                        childForm.Show();
                    }
                    else
                        MessageBox.Show("Bu dosya numarasına sahip bir kullanıcı bulunmamaktadır.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
        private void TxtHastaBilgileri_Click(object sender, EventArgs e)
        {

            HastaBilgileriAc();

        }

        private void BtnYeni_Click(object sender, EventArgs e)
        {
            txtDosyaNo.Text = "";
            HastaBilgileriAc();
        }

        private void TxtPolikinlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int siraNo = Convert.ToInt32(Veritabani.SiraNoVer(txtPolikinlik.Text, txtSevkTarihi.Text));
                siraNo++;
                txtSiraNo.Text = siraNo.ToString();
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void BtnTaburcu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int sevkID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["sevkID"].Value);
                    string deger = dataGridView1.CurrentRow.Cells["dosyaNo"].Value.ToString();
                    string sevkTarihi = dataGridView1.CurrentRow.Cells["sevkTarihi"].Value.ToString();
                    string toplamTutar = lblFiyat.Text;
                    Taburcu childForm = new Taburcu(deger, sevkTarihi, toplamTutar, sevkID);
                    childForm.MdiParent = Program.Owner;
                    childForm.StartPosition = FormStartPosition.CenterScreen;
                    childForm.Show();
                    Temizle();
                }
                dataGridView1.DataSource = "";
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       
        }

        private void BtnSecSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    string dosyaNo = dataGridView1.CurrentRow.Cells["dosyaNo"].Value.ToString();
                    string sevkID = dataGridView1.CurrentRow.Cells["sevkID"].Value.ToString();
                    DialogResult durum = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == durum)
                    {
                        Veritabani.VeriSil("tblSevk", "dosyaNo", dosyaNo, "sevkID", sevkID);
                        MessageBox.Show("Veri silindi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                dataGridView1.DataSource = Veritabani.IslemAra("tblSevk", txtOncekiIslem.Text, txtDosyaNo.Text).Tables[0];
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        int toplam = 0;
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
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
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                BtnTaburcu.Enabled = false;
                btnSecSil.Enabled = false;
                if (txtPolikinlik.Text == "" || txtDrKodu.Text == "" || txtYapilanIslem.Text == "" || txtDosyaNo.Text == "" || txtSiraNo.Text=="")
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblFiyat.Text = "";
                    Sevk yeniSevk = new Sevk()
                    {
                        SevkTarihi = txtSevkTarihi.Text,
                        DosyaNo = txtDosyaNo.Text,
                        Polikinlik = txtPolikinlik.Text,
                        Saat = DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                        YapilanIslem = txtYapilanIslem.Text,
                        DrKod = txtDrKodu.Text,
                        Miktar = txtMiktar.Value.ToString(),
                        BirimFiyat = txtBirimFiyat.Text,
                        Sira = txtSiraNo.Text,
                        Taburcu = "false"
                    };
                    Veritabani.SevkEkle(yeniSevk);

                    veriTablo.Rows.Add(yeniSevk.Polikinlik, yeniSevk.Sira, yeniSevk.DrKod, yeniSevk.Saat, yeniSevk.YapilanIslem, yeniSevk.Miktar, yeniSevk.BirimFiyat, yeniSevk.DosyaNo, yeniSevk.SevkTarihi);
                    dataGridView1.DataSource = veriTablo;

                    int birimFiyat = Convert.ToInt32(yeniSevk.BirimFiyat);
                    int miktar = Convert.ToInt32(yeniSevk.Miktar);
                    toplam += birimFiyat * miktar;
                    lblFiyat.Text = toplam.ToString();
                    Temizle();
                    txtSiraNo.Text = "";
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
      
        }

        private void BtnBaski_Click(object sender, EventArgs e)
        {
            pdDialog.ShowDialog();
            
            
        }
        
        Font baslik = new Font("Verdana", 12,FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        

        private void PdDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int iTopMargin = 0;
            StringFormat sformat = new StringFormat();
            sformat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString((DateTime.Now.ToShortDateString()), govde, sb, 700, 50);
            e.Graphics.DrawString("Selçuk Üniversitesi Tıp Fakültesi Hastanesi", baslik,sb,250,220);
            Image aImg = Image.FromFile(@"logo.png");
            e.Graphics.DrawImage(aImg, 20, 40, 220, 170);
            try
            {
                int iLeftMargin = 100;
                iTopMargin = 0;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            iTopMargin = 250;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            
                                if (Cel.Value != null)
                                {
                                    e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                                new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                                (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                                }

                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                                iCount++;
                            
                            
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }


                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            e.Graphics.DrawString("Toplam tutar:"+ Veritabani.FiyatHesapla(txtDosyaNo.Text, txtOncekiIslem.Text).ToString(), baslik, sb,600, iTopMargin+10);
            e.Graphics.DrawString(Veritabani.doktorIsmi(drKodu), baslik, sb, 550, iTopMargin + 60);
            e.Graphics.DrawString("İmza", baslik, sb, 550, iTopMargin + 80);
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), baslik, sb, 550, iTopMargin + 100);

        }

        private void PdDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYazdir_Click(object sender, EventArgs e)
        {
            pdDocument.Print();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                drKodu = dataGridView1.CurrentRow.Cells["drKod"].Value.ToString();
                if (dataGridView1.Rows.Count > 0)
                {
                    lblFiyat.Text = "";
                    string dosyaNo = dataGridView1.CurrentRow.Cells["taburcu"].Value.ToString();
                    string tutar = dataGridView1.CurrentRow.Cells["toplamTutar"].Value.ToString();
                    if (dosyaNo == "true")
                    {
                        BtnTaburcu.Enabled = false;

                    }
                    else
                    {
                        lblFiyat.Text = tutar;
                        BtnTaburcu.Enabled = true;
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Bir hata oluştu:" + a.Message, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
        }

        private void HastaIslemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            hastaIslemleriInstance = null;
        }
    }
}
