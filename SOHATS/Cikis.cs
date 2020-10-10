using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHATS
{
    public class Cikis
    {
        string dosyaNo, sevkTarihi, cikisSaati, odeme, toplamTutar;

        public string DosyaNo { get => dosyaNo; set => dosyaNo = value; }
        public string SevkTarihi { get => sevkTarihi; set => sevkTarihi = value; }
        public string CikisSaati { get => cikisSaati; set => cikisSaati = value; }
        public string Odeme { get => odeme; set => odeme = value; }
        public string ToplamTutar { get => toplamTutar; set => toplamTutar = value; }
    }
}
