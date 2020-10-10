using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SOHATS
{
    
    public class Veritabani
    {
        static readonly SqlConnection con = new SqlConnection("server=DESKTOP-Q4S1PAK\\SQLEXPRESS; Initial Catalog=SOHATS;Integrated Security=SSPI");
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static Polikinlikler yeniPolikinlik;
        public static List<string> kullaniciIsimleri;

        public static bool Login(string username,string pass)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblKullanici where userName='" + username + "' AND sifre='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            con.Close();
            return false;
        }
        
        public static void KullaniciKaydetGuncelle(Kullanici yeniKullanici,string yapilacakIs,string guncellemeUser)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@kod", yeniKullanici.Kodu);
            cmd.Parameters.AddWithValue("@ad", yeniKullanici.Ad);
            cmd.Parameters.AddWithValue("@soyad", yeniKullanici.Soyad);
            cmd.Parameters.AddWithValue("@sifre", yeniKullanici.Sifre);
            cmd.Parameters.AddWithValue("@yetki", yeniKullanici.Yetki);
            cmd.Parameters.AddWithValue("@evtel", yeniKullanici.EvTel);
            cmd.Parameters.AddWithValue("@ceptel", yeniKullanici.CepTel);
            cmd.Parameters.AddWithValue("@adres", yeniKullanici.Adres);
            cmd.Parameters.AddWithValue("@unvan", yeniKullanici.Unvan);
            cmd.Parameters.AddWithValue("@isebaslama", yeniKullanici.IseBaslama);
            cmd.Parameters.AddWithValue("@maas", yeniKullanici.Maas);
            cmd.Parameters.AddWithValue("@dogumyeri", yeniKullanici.DogumYeri);
            cmd.Parameters.AddWithValue("@annead", yeniKullanici.AnneAd);
            cmd.Parameters.AddWithValue("@babaad", yeniKullanici.BabaAd);
            cmd.Parameters.AddWithValue("@cinsiyet", yeniKullanici.Cinsiyet);
            cmd.Parameters.AddWithValue("@kangrubu", yeniKullanici.KanGrubu);
            cmd.Parameters.AddWithValue("@medenihal", yeniKullanici.MedeniHal);
            cmd.Parameters.AddWithValue("@dogumtarihi", yeniKullanici.DogumTarihi);
            cmd.Parameters.AddWithValue("@tckimlik", yeniKullanici.TcKimlikNo);
            cmd.Parameters.AddWithValue("@username", yeniKullanici.UserName);
            if (yapilacakIs=="Guncelle")
            {
                cmd.CommandText = "update tblKullanici set kodu=@kod,ad=@ad,soyad=@soyad,sifre=@sifre,yetki=@yetki," +
                    "evTel=@evtel,ceptel=@ceptel,adres=@adres,unvan=@unvan,iseBaslama=@isebaslama,maas=@maas,dogumYeri=@dogumYeri,anneAd=@annead," +
                    "babaAd=@babaad,cinsiyet=@cinsiyet,kanGrubu=@kangrubu,medeniHal=@medenihal,dogumTarihi=@dogumtarihi,tcKimlikNo=@tckimlik,userName=@username" +
                    " where userName='" + guncellemeUser + "'";

            }
            else if (yapilacakIs=="Ekle")
            {
                cmd.CommandText = "insert into tblKullanici(kodu,ad,soyad,sifre,yetki," +
                "evTel,cepTel,adres,unvan,iseBaslama,maas,dogumYeri,anneAd," +
                "babaAd,cinsiyet,kanGrubu,medeniHal,dogumTarihi,tcKimlikNo,userName)" +
                "values(@kod,@ad,@soyad,@sifre,@yetki,@evtel,@ceptel,@adres,@unvan,@isebaslama,@maas,@dogumyeri,@annead,@babaad," +
                "@cinsiyet,@kangrubu,@medenihal,@dogumtarihi,@tckimlik,@username)";
            }
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void PolikinlikKaydetGuncelle(Polikinlikler guncelPol,string yapilacakIs)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@aciklama", guncelPol.Aciklama);
            cmd.Parameters.AddWithValue("@durum", guncelPol.Durum);
            cmd.Parameters.AddWithValue("@polikinlikAdi", guncelPol.PolikinlikAdi);
            if (yapilacakIs=="Guncelle")
            {
                cmd.CommandText = "update tblPolikinlik set polikinlikAdi=@polikinlikAdi,durum=@durum,aciklama=@aciklama" +
                    " where polikinlikAdi='" + guncelPol.PolikinlikAdi + "'";
            }
            else if(yapilacakIs=="Ekle")
            {
                cmd.CommandText = "insert into tblPolikinlik(polikinlikAdi,durum,aciklama) values(@polikinlikAdi,@durum,@aciklama)";
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void ElemanEkle(string sorgu,string tablo,string kosul,string aramaDeger)
        {

            cmd = new SqlCommand();
            kullaniciIsimleri = new List<string>();
            con.Open();
            cmd.Connection = con;
            if (kosul=="")
            {
                cmd.CommandText = "SELECT " + sorgu + " FROM " + tablo + "";
            }
            else
            {
                cmd.CommandText = "SELECT " + sorgu + " FROM " + tablo + " where "+aramaDeger+"='" + kosul + "'";
            }
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                kullaniciIsimleri.Add(dr[sorgu].ToString());
            }
            con.Close();
        }
        public static Kullanici KullaniciBilgileri(string userName)
        {
            Kullanici kullaniciBilgileri = new Kullanici();
            cmd = new SqlCommand();
            if (con.State==System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblKullanici where userName='"+userName+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                kullaniciBilgileri.Kodu = dr["kodu"].ToString();
                kullaniciBilgileri.Ad = dr["ad"].ToString();
                kullaniciBilgileri.Soyad = dr["soyad"].ToString();
                kullaniciBilgileri.Sifre = dr["sifre"].ToString();
                kullaniciBilgileri.Yetki = dr["yetki"].ToString();
                kullaniciBilgileri.EvTel = dr["evTel"].ToString();
                kullaniciBilgileri.CepTel = dr["cepTel"].ToString();
                kullaniciBilgileri.Adres = dr["adres"].ToString();
                kullaniciBilgileri.Unvan = dr["unvan"].ToString();
                kullaniciBilgileri.IseBaslama =Convert.ToDateTime(dr["iseBaslama"]);
                kullaniciBilgileri.Maas = dr["maas"].ToString();
                kullaniciBilgileri.DogumYeri = dr["dogumYeri"].ToString();
                kullaniciBilgileri.AnneAd = dr["anneAd"].ToString();
                kullaniciBilgileri.BabaAd = dr["babaAd"].ToString();
                kullaniciBilgileri.Cinsiyet = dr["cinsiyet"].ToString();
                kullaniciBilgileri.KanGrubu = dr["kanGrubu"].ToString();
                kullaniciBilgileri.MedeniHal = dr["medeniHal"].ToString();
                kullaniciBilgileri.DogumTarihi = Convert.ToDateTime(dr["dogumTarihi"]);
                kullaniciBilgileri.TcKimlikNo = dr["tcKimlikNo"].ToString();
            }
            con.Close();
            return kullaniciBilgileri;
        }
        public static Polikinlikler PolikinlikBilgisi(string polikinlikAdi)
        {
            yeniPolikinlik = new Polikinlikler();
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblPolikinlik where polikinlikAdi='" + polikinlikAdi + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                yeniPolikinlik.Aciklama = dr["aciklama"].ToString();
                yeniPolikinlik.Durum = dr["durum"].ToString();
            }
            con.Close();
            return yeniPolikinlik;
        }
        public static void VeriSil(string tabloAdi,string sorgu,string deger,string sorgu2,string deger2)
        {
            
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@deger", deger);
            cmd.Parameters.AddWithValue("@deger2", deger2);
            if (sorgu2=="" || deger2=="")
            {
                cmd.CommandText = "DELETE from " + tabloAdi + " where " + sorgu + "=@deger";
            }
            else
            {
                cmd.CommandText = "DELETE from " + tabloAdi + " where " + sorgu + "=@deger and "+sorgu2+"=@deger2";
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static string VeriAra(string tabloAdi,string sorgu,string deger,string arananSutun)
        {
            string veri = "";
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM " + tabloAdi + " where "+sorgu+"='"+deger+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                veri = dr[arananSutun].ToString();
            }
            con.Close();
            return veri;
        }
        public static DataSet Ara(string tabloAdi,string parametre,string aranacakKelime)
        {
            con.Open();
            string sorgu = "Select * from "+tabloAdi+" where "+parametre+" Like '%" + aranacakKelime + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, tabloAdi);
            con.Close();
            return ds;
        }
        public static DataSet IslemAra(string tabloAdi, string sevkTarihi, string dosyaNo)
        {
            con.Open();

            string sorgu = "Select * from " + tabloAdi + " where sevkTarihi='"+sevkTarihi+"' and dosyaNo='"+dosyaNo+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, tabloAdi);
            con.Close();
            return ds;
        }
        public static Hasta HastaIslemleriGetir(string dosyaNo)
        {

            int uzunluk = 0;
            Hasta yeniHasta = new Hasta();
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) as uzunluk from tblSevk where dosyaNo='" + dosyaNo + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                uzunluk = Convert.ToInt32(dr["uzunluk"]);
            }
            con.Close();
            con.Open();
            if (uzunluk > 0)
            {
                cmd.CommandText = "SELECT * FROM tblSevk,tblHasta where tblHasta.dosyaNo=" + dosyaNo + " and tblSevk.dosyaNo=" + dosyaNo + "";
                dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    
                    yeniHasta.sevkTarihleri.Add(dr["sevkTarihi"].ToString());
                    yeniHasta.hastaIslem.SevkTarihi = dr["sevkTarihi"].ToString();
                    yeniHasta.Adi = dr["ad"].ToString();
                    yeniHasta.Soyadi = dr["soyad"].ToString();
                    yeniHasta.KurumAdi = dr["kurumAdi"].ToString();
                    yeniHasta.hastaIslem.Taburcu = dr["taburcu"].ToString();
                    yeniHasta.TcNo = dr["tcKimlikNo"].ToString();
                    yeniHasta.TelefonNo = dr["tel"].ToString();
                    yeniHasta.DogumYeri = dr["dogumYeri"].ToString();
                    yeniHasta.DogumTarihi = Convert.ToDateTime(dr["dogumTarihi"]);
                    yeniHasta.BabaAdi = dr["babaAdi"].ToString();
                    yeniHasta.AnneAdi = dr["anneAdi"].ToString();
                    yeniHasta.Cinsiyet = (dr["cinsiyet"]).ToString();
                    yeniHasta.KanGrubu = dr["kanGrubu"].ToString();
                    yeniHasta.MedeniDurum = (dr["medeniHal"]).ToString();
                    yeniHasta.Adres = dr["adres"].ToString();
                    yeniHasta.KurumSicilNo = dr["kurumSicilNo"].ToString();
                    yeniHasta.YakinNo = dr["yakinTel"].ToString();
                    yeniHasta.YakinKurumAdi = dr["yakinKurumAdi"].ToString();
                    yeniHasta.YakinKurumSicilNo = dr["yakinKurumSicilNo"].ToString();
                }
                con.Close();
            }
            else
            {
                cmd.CommandText = "select * from tblHasta where dosyaNo='"+dosyaNo+"'";
                dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    yeniHasta.Adi = dr["ad"].ToString();
                    yeniHasta.Soyadi = dr["soyad"].ToString();
                    yeniHasta.KurumAdi = dr["kurumAdi"].ToString();
                    yeniHasta.TcNo = dr["tcKimlikNo"].ToString();
                    yeniHasta.TelefonNo = dr["tel"].ToString();
                    yeniHasta.DogumYeri = dr["dogumYeri"].ToString();
                    yeniHasta.DogumTarihi = Convert.ToDateTime(dr["dogumTarihi"]);
                    yeniHasta.BabaAdi = dr["babaAdi"].ToString();
                    yeniHasta.AnneAdi = dr["anneAdi"].ToString();
                    yeniHasta.Cinsiyet = (dr["cinsiyet"]).ToString();
                    yeniHasta.KanGrubu = dr["kanGrubu"].ToString();
                    yeniHasta.MedeniDurum = (dr["medeniHal"]).ToString();
                    yeniHasta.Adres = dr["adres"].ToString();
                    yeniHasta.KurumSicilNo = dr["kurumSicilNo"].ToString();
                    yeniHasta.YakinNo = dr["yakinTel"].ToString();
                    yeniHasta.YakinKurumAdi = dr["yakinKurumAdi"].ToString();
                    yeniHasta.YakinKurumSicilNo = dr["yakinKurumSicilNo"].ToString();
                }
                con.Close();
            }
            con.Close();
            return yeniHasta;
        }
        public static Hasta TaburcuKontrol(string islemTarihi,string dosyaNo)
        {
            
            Hasta yeniHasta = new Hasta();
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT taburcu,toplamTutar FROM tblSevk where sevkTarihi='" + islemTarihi + "' and dosyaNo='" + dosyaNo + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                yeniHasta.hastaIslem.Taburcu=dr["taburcu"].ToString();
                yeniHasta.hastaIslem.ToplamTutar = dr["toplamTutar"].ToString();
            }
            con.Close();
            return yeniHasta;
        }
        public static void HastaGuncelle(Hasta yeniHasta,string yapilacakIs,string guncellenenDosyaNo)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@tcKimlikNo", yeniHasta.TcNo);
            cmd.Parameters.AddWithValue("@ad", yeniHasta.Adi);
            cmd.Parameters.AddWithValue("@soyad", yeniHasta.Soyadi);
            cmd.Parameters.AddWithValue("@dosyaNo", yeniHasta.DosyaNo);
            cmd.Parameters.AddWithValue("@dogumYeri", yeniHasta.DogumYeri);
            cmd.Parameters.AddWithValue("@dogumTarihi", yeniHasta.DogumTarihi);
            cmd.Parameters.AddWithValue("@babaAdi", yeniHasta.BabaAdi);
            cmd.Parameters.AddWithValue("@anneAdi", yeniHasta.AnneAdi);
            cmd.Parameters.AddWithValue("@cinsiyet", yeniHasta.Cinsiyet);
            cmd.Parameters.AddWithValue("@kanGrubu", yeniHasta.KanGrubu);
            cmd.Parameters.AddWithValue("@medeniHal", yeniHasta.MedeniDurum);
            cmd.Parameters.AddWithValue("@adres", yeniHasta.Adres);
            cmd.Parameters.AddWithValue("@tel", yeniHasta.TelefonNo);
            cmd.Parameters.AddWithValue("@kurumSicilNo", yeniHasta.KurumSicilNo);
            cmd.Parameters.AddWithValue("@kurumAdi", yeniHasta.KurumAdi);
            cmd.Parameters.AddWithValue("@yakinTel", yeniHasta.YakinNo);
            cmd.Parameters.AddWithValue("@yakinKurumSicilNo", yeniHasta.YakinKurumSicilNo);
            cmd.Parameters.AddWithValue("@yakinKurumAdi", yeniHasta.YakinKurumAdi);
            if (yapilacakIs == "Guncelle")
            {
                cmd.CommandText = "update tblHasta set tcKimlikNo=@tcKimlikNo,ad=@ad," +
                    "soyad=@soyad,dogumYeri=@dogumYeri,dogumTarihi=@dogumTarihi," +
                    "babaAdi=@babaAdi,anneAdi=@anneAdi,cinsiyet=@cinsiyet,kanGrubu=@kanGrubu," +
                    "medeniHal=@medeniHal,adres=@adres,tel=@tel," +
                    "kurumSicilNo=@kurumSicilNo," +
                    "kurumAdi=@kurumAdi,yakinTel=@yakinTel,yakinKurumSicilNo=@yakinKurumSicilNo,yakinKurumAdi=@yakinKurumAdi" +
                    " where dosyaNo='" + guncellenenDosyaNo + "'";

            }
            else if (yapilacakIs == "Ekle")
            {
                cmd.CommandText = "insert into tblHasta(dosyaNo,tcKimlikNo,ad,soyad,dogumYeri,dogumTarihi," +
                "babaAdi,anneAdi,cinsiyet,kanGrubu,medeniHal,adres,tel,kurumSicilNo," +
                "kurumAdi,yakinTel,yakinKurumSicilNo,yakinKurumAdi)" +
                "values(@dosyaNo,@tcKimlikNo,@ad,@soyad,@dogumYeri,@dogumTarihi,@babaAdi,@anneAdi,@cinsiyet,@kanGrubu,@medeniHal,@adres,@tel,@kurumSicilNo,@kurumAdi," +
                "@yakinTel,@yakinKurumSicilNo,@yakinKurumAdi)";
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static string maxVeri(string aranacakmaxveri,string tbl)
        {
            string dosyaNo = "";
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select max("+aranacakmaxveri+") as maxDosyaNo from "+tbl+"";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                dosyaNo = dr["maxDosyaNo"].ToString();
            }
            con.Close();
            return dosyaNo;
        }
        public static string SiraNoVer(string polikinlik,string tarih)
        {
            string sira = "";
            string deger = "0";
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText="select count(*) as siraSayisi from tblSevk where sevkTarihi='"+tarih+"'";
            dr = cmd.ExecuteReader();
            while(dr.Read()==true)
            {
                sira = dr["siraSayisi"].ToString();
            }
            con.Close();
            int siraSayisi = Convert.ToInt32(sira);
            if (siraSayisi>0)
            {
                con.Open();
                cmd.CommandText = "select max(sira) as siraNo from tblSevk where polikinlik='" + polikinlik + "' and sevkTarihi='"+tarih+"' ";
                dr = cmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    deger = dr["siraNo"].ToString();
                }
                con.Close();
                if (deger=="")
                {
                    deger = "0";
                }
                return deger;
            }
            else
            {
                return deger;
            }
        }
        public static void TaburcuEt(int sevkid)
        {
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update tblSevk set taburcu='true' where sevkID='" + sevkid+ "'";
            dr = cmd.ExecuteReader();
        }
        public static void SevkEkle(Sevk yeniSevk)
        {
            int toplamtutar = Convert.ToInt32(yeniSevk.BirimFiyat) * Convert.ToInt32(yeniSevk.Miktar);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@sevkTarihi", yeniSevk.SevkTarihi);
            cmd.Parameters.AddWithValue("@dosyaNo", yeniSevk.DosyaNo);
            cmd.Parameters.AddWithValue("@polikinlik", yeniSevk.Polikinlik);
            cmd.Parameters.AddWithValue("@saat", yeniSevk.Saat);
            cmd.Parameters.AddWithValue("@yapilanIslem", yeniSevk.YapilanIslem);
            cmd.Parameters.AddWithValue("@drKod", yeniSevk.DrKod);
            cmd.Parameters.AddWithValue("@miktar", yeniSevk.Miktar);
            cmd.Parameters.AddWithValue("@birimFiyat", yeniSevk.BirimFiyat);
            cmd.Parameters.AddWithValue("@sira", yeniSevk.Sira);
            cmd.Parameters.AddWithValue("@toplamTutar", toplamtutar.ToString());
            cmd.Parameters.AddWithValue("@taburcu", yeniSevk.Taburcu);
            cmd.CommandText = "insert into tblSevk(sevkTarihi,dosyaNo,polikinlik,saat,yapilanIslem,drKod,miktar,birimFiyat,sira,toplamTutar,taburcu) " +
                "values(@sevkTarihi,@dosyaNo,@polikinlik,@saat,@yapilanIslem,@drKod,@miktar,@birimFiyat,@sira,@toplamTutar,@taburcu)";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static int FiyatHesapla(string dosyaNo,string sevkTarihi)
        {
            
            int toplamTutar = 0;
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT toplamTutar FROM tblSevk where sevkTarihi='" + sevkTarihi + "' and dosyaNo='" + dosyaNo + "' and taburcu='false'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                toplamTutar += Convert.ToInt32(dr["toplamTutar"]);
            }
            con.Close();
            return toplamTutar;
        }
        public static string doktorIsmi(string drNo)
        {
            string adisoyadi = "";
            cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ad,soyad FROM tblKullanici where kodu='"+drNo+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                adisoyadi = dr["ad"].ToString() + " " + dr["soyad"].ToString();
            }
            con.Close();
            return adisoyadi;
        }
        public static void cikisKaydet(Cikis yeniCikis)
        {
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@dosyaNo",yeniCikis.DosyaNo);
            cmd.Parameters.AddWithValue("@sevkTarihi",yeniCikis.SevkTarihi);
            cmd.Parameters.AddWithValue("@cikisSaati",yeniCikis.CikisSaati);
            cmd.Parameters.AddWithValue("@odeme",yeniCikis.Odeme);
            cmd.Parameters.AddWithValue("@toplamTutar",yeniCikis.ToplamTutar);
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tblCikis(dosyaNo,sevkTarihi,cikisSaati,odeme,toplamTutar) values(@dosyaNo,@sevkTarihi" +
                 ",@cikisSaati,@odeme,@toplamTutar)";

            dr = cmd.ExecuteReader();
            con.Close();
        }
        public static DataSet Sorgula(string baslangic,string bitis,string taburcu)
        {
            con.Open();
            string sorgu = "";
            if (taburcu=="Hepsi")
            {
                sorgu = "Select * from tblSevk where sevkTarihi BETWEEN '" + baslangic + "' AND '" + bitis + "'";
            }
            else if (taburcu=="Taburcu olanlar")
            {
                sorgu = "Select * from tblSevk where (sevkTarihi BETWEEN '" + baslangic + "' AND '" + bitis + "') and taburcu='true'";
            }
            else
            {
                sorgu = "Select * from tblSevk where (sevkTarihi BETWEEN '" + baslangic + "' AND '" + bitis + "') and taburcu='false'";
            }
            SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, "tblSevk");
            con.Close();
            return ds;
        }
    }
}
