using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHATS
{
    public class Islem
    {
        
        string dosyaNo, saat, yapilanIslem, drKod, miktar, birimFiyat, sira, toplamTutar, taburcu,polikinlik,sevkTarihi;

        public string DosyaNo { get => dosyaNo; set => dosyaNo = value; }
        public string Saat { get => saat; set => saat = value; }
        public string YapilanIslem { get => yapilanIslem; set => yapilanIslem = value; }
        public string DrKod { get => drKod; set => drKod = value; }
        public string Miktar { get => miktar; set => miktar = value; }
        public string BirimFiyat { get => birimFiyat; set => birimFiyat = value; }
        public string Sira { get => sira; set => sira = value; }
        public string ToplamTutar { get => toplamTutar; set => toplamTutar = value; }
        public string Taburcu { get => taburcu; set => taburcu = value; }
        public string SevkTarihi { get => sevkTarihi; set => sevkTarihi = value; }
        public string Polikinlik { get => polikinlik; set => polikinlik = value; }
    }
}
