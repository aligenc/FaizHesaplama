using System;
using System.Collections.Generic;

namespace FaizHesaplama
{
    class Faiz
    {
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public decimal FaizOrani { get; set; }

        public Faiz() { }
        public Faiz(DateTime baslangic, DateTime bitis, decimal faizorani)
        {
            Baslangic = baslangic;
            Bitis = bitis;
            FaizOrani = faizorani;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Type for exit");
            decimal anapara = 87000;

            List<Faiz> paralar = new List<Faiz>();
            paralar.Add(new Faiz(new DateTime(2017, 03, 13), new DateTime(2017, 03, 24), Convert.ToDecimal(12.50)));
            paralar.Add(new Faiz(new DateTime(2017, 03, 24), new DateTime(2017, 04, 14), Convert.ToDecimal(12.75)));
            paralar.Add(new Faiz(new DateTime(2017, 04, 14), new DateTime(2017, 05, 04), Convert.ToDecimal(13.00)));
            paralar.Add(new Faiz(new DateTime(2017, 05, 04), new DateTime(2017, 06, 16), Convert.ToDecimal(13.50)));
            paralar.Add(new Faiz(new DateTime(2017, 06, 16), new DateTime(2017, 07, 11), Convert.ToDecimal(14.00)));
            paralar.Add(new Faiz(new DateTime(2017, 07, 11), new DateTime(2017, 07, 18), Convert.ToDecimal(13.75)));
            paralar.Add(new Faiz(new DateTime(2017, 07, 18), new DateTime(2017, 08, 25), Convert.ToDecimal(13.50)));
            paralar.Add(new Faiz(new DateTime(2017, 08, 25), DateTime.Now, Convert.ToDecimal(13.75)));

            Console.WriteLine("Giriş Anapara: " + anapara);
            Console.WriteLine("------------");
            Console.WriteLine("Başlangıç T. | Bitiş T. | Gün | FaizOrani | Faiz | [ Anapara ]");
            decimal anaparaTemp = anapara;

            foreach (var item in paralar)
            {
                TimeSpan t = item.Bitis - item.Baslangic;
                decimal faiz = (anapara / 100) * (item.FaizOrani / 365) * t.Days;
                anapara = anapara + faiz * Convert.ToDecimal(0.85);
                anapara = Math.Round(anapara, 2);

                Console.WriteLine(item.Baslangic.ToShortDateString() + " | " + item.Bitis.ToShortDateString() + " | " + t.Days + " | %" + item.FaizOrani + " | " + Math.Round(faiz, 2) + " | [" + anapara + "]");
            }
            Console.WriteLine("------------");
            Console.WriteLine("Çıkış Anapara: " + anapara);
            TimeSpan timeTotal = paralar[paralar.Count - 1].Bitis - paralar[0].Baslangic;
            Console.WriteLine("Toplam Vade Gün Sayısı: " + timeTotal.Days);
            Console.WriteLine("Kazanılan Faiz: " + (anapara - anaparaTemp));
            //+68 TL
            Console.ReadLine();

        }
    }
}
