using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHATS
{
    public class Kullanici
    {
        private string kodu, ad, soyad, sifre, yetki, evTel, cepTel, adres, unvan, maas,
            dogumYeri, anneAd, babaAd, kanGrubu, tcKimlikNo, userName,cinsiyet,medeniHal;
        private DateTime dogumTarihi,iseBaslama;
        public Kullanici()
        {

        }
        public Kullanici(string kullaniciKodu)
        {
            this.kodu = kullaniciKodu;
        }
        public string Kodu { get => kodu; set => kodu = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Yetki { get => yetki; set => yetki = value; }
        public string EvTel { get => evTel; set => evTel = value; }
        public string CepTel { get => cepTel; set => cepTel = value; }
        public string Adres { get => adres; set => adres = value; }
        public string Unvan { get => unvan; set => unvan = value; }
        public DateTime IseBaslama { get => iseBaslama; set => iseBaslama = value; }
        public string Maas { get => maas; set => maas = value; }
        public string DogumYeri { get => dogumYeri; set => dogumYeri = value; }
        public string AnneAd { get => anneAd; set => anneAd = value; }
        public string BabaAd { get => babaAd; set => babaAd = value; }
        public string KanGrubu { get => kanGrubu; set => kanGrubu = value; }
        public string TcKimlikNo { get => tcKimlikNo; set => tcKimlikNo = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public string MedeniHal { get => medeniHal; set => medeniHal = value; }
        public DateTime DogumTarihi { get => dogumTarihi; set => dogumTarihi = value; }
    }
}
