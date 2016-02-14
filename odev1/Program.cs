using System;
using System.Linq;

namespace DersAtama
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ogrenciler = { "ali", "ahmet", "mehmet", "mahmut", "hasan", "hüseyin", "ramazan" };
            string[] dersler = { "c#", "c", "c++", "html", "java" };
            string cevap = "";


            int[] ogrenciIndexTut = new int[ogrenciler.Length]; //random seçilen ismin tekrar seçilmemesi adına, seçilen öğrenci indexleri tutuldu.
            int[] derslerIndexTut = new int[ogrenciler.Length]; // aynı şekilde.

            string[,] dersAtamalari = new string[ogrenciler.Length, 2];
            int ogrenciRandom;
            int derslerRandom;

            do
            {
                Random rnd = new Random();
                for (int i = 0; i < ogrenciIndexTut.Length; i++) // dizi index i 0 değeri alabildiğinden, indextutan dizilerimizin default değerlerini -1 liyoruz.
                {
                    ogrenciIndexTut[i] = -1;
                }

                for (int i = 0; i < derslerIndexTut.Length; i++)
                {
                    derslerIndexTut[i] = -1;
                }

                for (int i = 0; i < ogrenciler.Length; i++)
                {
                    do
                    {
                        ogrenciRandom = rnd.Next(0, ogrenciler.Length);


                    } while (ogrenciIndexTut.Contains(ogrenciRandom)); // içerisi true ise yani random değer önceden de atanmışsa random üretmeye devam et.

                    ogrenciIndexTut[i] = ogrenciRandom;  // kullanılan indexlerin tekrar kullanılmaması için..
                    dersAtamalari[i, 0] = ogrenciler[ogrenciRandom]; // aynı olmayan bir öğrenci ismi atandı.



                    do
                    {
                        derslerRandom = rnd.Next(0, dersler.Length);

                        if (i >= dersler.Length)// var olan tüm dersler atandı.aynı mı kontrolünü yapmaya gerek yok.
                        {
                            break;
                        }

                    } while (derslerIndexTut.Contains(derslerRandom)); //random sayı tut dizisinde varsa random üretmeye devam et.

                    derslerIndexTut[i] = derslerRandom;
                    dersAtamalari[i, 1] = dersler[derslerRandom]; // seçilen öğrenciye ders ataması.
                }


                for (int i = 0; i < dersAtamalari.GetLength(0); i++) // atanan dersler ekrana yazdırılır.
                {
                    Console.WriteLine("ogrenci adı:{0} ******* atanan ders:{1}", dersAtamalari[i, 0], dersAtamalari[i, 1]);
                }

                Console.WriteLine("\nTekrar oynamak ister misiniz?E/H");
                cevap = Console.ReadLine();

            } while (cevap.ToLower() == "e");


            Console.ReadKey();
        }
    }
}
