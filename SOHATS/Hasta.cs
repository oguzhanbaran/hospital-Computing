using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHATS
{
    public class Hasta
    {
        public Islem hastaIslem = new Islem();
        public List<string> sevkTarihleri = new List<string>();
        public Hasta(string tcNo,string dosyaNo)
        {
            this.tcNo = tcNo;
            this.dosyaNo = dosyaNo;
        }
        public Hasta()
        {

        }
        private string dosyaNo, adi, soyadi, tcNo, dogumYeri, babaAdi, anneAdi, adres,
            telefonNo, yakinNo, kurumSicilNo, yakinKurumSicilNo, kurumAdi, yakinKurumAdi,
            kanGrubu;
        private DateTime dogumTarihi;
        private string cinsiyet, medeniDurum;

        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public string MedeniDurum { get => medeniDurum; set => medeniDurum = value; }
        public DateTime DogumTarihi { get => dogumTarihi; set => dogumTarihi = value; }
        public string DosyaNo { get => dosyaNo; set => dosyaNo = value; }
        public string Adi { get => adi; set => adi = value; }
        public string Soyadi { get => soyadi; set => soyadi = value; }
        public string TcNo { get => tcNo; set => tcNo = value; }
        public string DogumYeri { get => dogumYeri; set => dogumYeri = value; }
        public string BabaAdi { get => babaAdi; set => babaAdi = value; }
        public string AnneAdi { get => anneAdi; set => anneAdi = value; }
        public string Adres { get => adres; set => adres = value; }
        public string TelefonNo { get => telefonNo; set => telefonNo = value; }
        public string YakinNo { get => yakinNo; set => yakinNo = value; }
        public string KurumSicilNo { get => kurumSicilNo; set => kurumSicilNo = value; }
        public string YakinKurumSicilNo { get => yakinKurumSicilNo; set => yakinKurumSicilNo = value; }
        public string KurumAdi { get => kurumAdi; set => kurumAdi = value; }
        public string YakinKurumAdi { get => yakinKurumAdi; set => yakinKurumAdi = value; }
        public string KanGrubu { get => kanGrubu; set => kanGrubu = value; }
    }
}
