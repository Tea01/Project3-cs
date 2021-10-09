using System;

namespace Soru1
{
    class BenimString
    {
        //nesnedeki eleman sayısını bulmak için
        public static int ElemanSayisi(string metin)
        {
            int elemanSayisi = 0;

            foreach (char karakter in metin)          //stringte bulunan karakterler birer birer kontrol edecek ve elemanSayısı'yı ekleyecek
            {
                elemanSayisi++;
            }
            return elemanSayisi;                 //nesnedeki eleman sayısını veriyor bize
        }
        //Iki string birleştirmek için metod
        public static string Birlestir(string metin1, string metin2)
        {
            return metin1 + metin2;
        }
        //stringin içerisinde yeni bir karakter konulan metod
        public static string ArayaGir(string arayaGirMetin, int indeks, string karakter)
        {
            string yeniMetin = "";

            for (int i = 0; i < ElemanSayisi(arayaGirMetin); i++)      //0'dan girilen metinin uzunluğuna kadar bir döngü
            {
                if (indeks == i)
                {
                    yeniMetin += karakter;
                    yeniMetin += arayaGirMetin[i];
                }
                else
                {
                    yeniMetin += arayaGirMetin[i];
                }
            }
            return yeniMetin;
        }
        //İstenilen değer geri veren metod
        public static string DegerAl(string degerAlMetin, int index, int harfKonumu)
        {
            string yeniString = "";

            for (int i = 0; i < ElemanSayisi(degerAlMetin); i++)
            {
                if (i == index)
                {
                    for (int j = 0; j < harfKonumu - index; j++)
                    {
                        yeniString += degerAlMetin[index++];
                    }
                }
            }
            return yeniString;
        }
        //İsetnilen konumda (indiste) verilen diziyi ayırıyor
        public static string DiziyeAyir(string diziyeAyirMetni, char harf)
        {
            string yeniText = "";

            for (int i = 0; i < ElemanSayisi(diziyeAyirMetni); i++)
            {
                if (harf == diziyeAyirMetni[i])
                {
                    continue;
                }
                yeniText += diziyeAyirMetni[i];
            }
            return yeniText;
        }
        //girilen string metni char diziye dönüştüren metod
        public static char[] CharDiziyeDonustur(string dizi)
        {
            char[] charDonustur = new char[ElemanSayisi(dizi)];
            for (int i = 0; i < ElemanSayisi(dizi); i++)
            {
                charDonustur[i] = dizi[i];
            }
            return charDonustur;
        }
        //İstenilen karakter için indisini geri döndüren metod
        public static void DegerIndis(string degerIndisMetni, string harfIndis)
        {
            string kucukHarf = degerIndisMetni.ToLower();
            //aranan kelimenin uzunluğunu veriyor
            int kelimeUzunluk = ElemanSayisi(harfIndis);

            //1 den dizi.Length'ye kadar tüm stringleri tek tek kontrol ediyor
            for (int i = 0; i < ElemanSayisi(kucukHarf); i++)
            {
                //i den sonraki kelimenin uzunluğuna kadar karakterden oluşan yeni bir string oluşturulur  
                string word = DegerAl(kucukHarf, kelimeUzunluk, i);

                if (word == harfIndis)         //eğer koşul sağlanırsa ekrana aranan kelimenin indeksini yazdıracak
                {
                    int indeks = kucukHarf.IndexOf(word);

                    while (indeks != -1)      //birden fazla aynı kelime varsa dizide while döngü ile kontrol edip ekrana yazdırıyoruz
                    {
                        Console.WriteLine("Kelime {0} indis: {1}", harfIndis, indeks);
                        indeks = kucukHarf.IndexOf(harfIndis, indeks + 1);
                        continue;
                    }
                    break;
                }
            }
        }
        //Girilen metinin harfleri A'dan Z'ye sıralayan metod
        public static string SiralaAZ(string AZmetin)
        {
            string azMetin = AZmetin.ToLower();

            string harfler = "abcçdefgğhıijklmnoöpqrsştuüvwxyz";
            char[] arry = CharDiziyeDonustur(harfler);                       //her karakter kontrolu yapmak için char[] dizi ihtiyacımız var

            for (int i = 0; i < ElemanSayisi(azMetin); i++)
            {
                for (int j = 0; j < ElemanSayisi(azMetin); j++)
                {
                    if (azMetin[j] == arry[i])
                    {
                        Console.Write(arry[i]);
                    }
                }
            }
            return new string(arry);
        }
        //Girilen metinin harfleri Z'den A'ye sıralayan metod
        public static string SiralaZA(string ZAmetin)
        {
            string zaMetin = ZAmetin.ToLower();

            string harfler = "zyxwvüutşsrqpöonmlkjiıhğgfedçcba";
            char[] arry = CharDiziyeDonustur(harfler);                       //her karakter kontrolu yapmak için char[] dizi ihtiyacımız var

            for (int i = 0; i < ElemanSayisi(harfler); i++)
            {
                for (int j = 0; j < ElemanSayisi(zaMetin); j++)
                {
                    if (zaMetin[j] == arry[i])
                    {
                        Console.Write(arry[i]);
                    }
                }
            }
            return new string(arry);
        }
        //Girilen metinin harfleri ters dödüren sıralayan metod
        public static string TersCevir(string tersCevir)
        {
            char[] chars = new char[ElemanSayisi(tersCevir)];
            for (int i = 0, j = ElemanSayisi(tersCevir) - 1; i <= j; i++, j--)
            {
                chars[i] = tersCevir[j];
                chars[j] = tersCevir[i];
            }
            return new string(chars);
        }
    }
    class Test
    {
        public static void Smth()
        {
            Console.WriteLine("********************  MENÜ  ********************");
            Console.WriteLine();
            Console.WriteLine("1. Metindeki eleman sayısını veren fonksiyon.");
            Console.WriteLine("------ Metnini yazın: Sakarya Üniversitesi ya da kısaca SAÜ.");
            string metin = "Sakarya Üniversitesi ya da kısaca SAÜ.";
            Console.WriteLine("- - - -Girdiğiniz metni için eleman sayısı = {0}", BenimString.ElemanSayisi(metin));

            Console.WriteLine();

            Console.WriteLine("2. İki string metin değeri birleştiren fonksiyon.");
            Console.WriteLine("-------Birleştirecek metinleri yazın: ");
            Console.WriteLine("-------1. metin =  Bilgi");
            string metin1 = "Bilgi";
            Console.WriteLine("-------2. metin = sayar");
            string metin2 = "sayar";
            Console.WriteLine("- - - -Girdiğiniz metinler için birleşik hali \"{0}\" dır.", BenimString.Birlestir(metin1, metin2));

            Console.WriteLine();

            Console.WriteLine("3. Bir metnin arasına yerleştirecek karakter yazan fonksiyon.");
            Console.WriteLine("-------Metnini yazın: TeaShkurti");
            string arayaGirMetin = "TeaShkurti";
            Console.WriteLine("-------Hangi indisde karakter yerleştirmek istiyorsunuz? 5");
            int indeks = 5;
            Console.WriteLine("-------Hangi karakter eklemek istiyorsunuz? 123");
            string karakter = "123";
            Console.WriteLine("- - - -Girdiğiniz değerler için metnin son hali = {0} ", BenimString.ArayaGir(arayaGirMetin, indeks, karakter));

            Console.WriteLine();

            Console.WriteLine("4. Belirtilen indisten başlayarak, belirtilen karakter kadar metni parçasını döndüren fonksiyon.");
            Console.WriteLine("-------Metnini yazın: Sakarya Üniversitesi");
            string degerAlMetin = "Sakarya Üniversitesi";
            Console.WriteLine("-------Indisini belirtin: 3");
            int index = 3;
            Console.WriteLine("-------Hangi karaktere kadar: 'v'");
            string character = "v";
            int harfKonumu = degerAlMetin.IndexOf(character);
            Console.WriteLine("- - - -Girdiğiniz değer için istenilen metni = \"{0}\" dur", BenimString.DegerAl(degerAlMetin, index, harfKonumu));

            Console.WriteLine();

            Console.WriteLine("5. Metinden karakter kaldıran fonksiyon.");
            Console.WriteLine("-------Metnini yazın: Bilgisayar ve Bilişim Fakültesi");
            string diziyeAyirMetni = "Bilgisayar ve Bilişim Fakültesi";
            Console.WriteLine("-------Karakter: 'i' ");
            char harf = 'i';
            Console.WriteLine("- - - -Girdiğiniz değer için istenilen metni = \"{0}\" dir", BenimString.DiziyeAyir(diziyeAyirMetni, harf));

            Console.WriteLine();

            Console.WriteLine("6. Verilen string metin, char diziye dönüştüren fonksiyon.");
            Console.WriteLine("-------Metnini yazın: Bilgisayar ");
            string dizi = "Bilgisayar";
            Console.Write("- - - -Girdiğiniz değer için char diziye kaydetilen metin: ");
            Console.WriteLine(BenimString.CharDiziyeDonustur(dizi));

            Console.WriteLine();

            Console.WriteLine("7. Aranan karakterin indisini döndüren fonksiyon.");
            Console.WriteLine("-------Metni yazın: Bilgisayar ve Bilişim Fakültesi");
            string degerIndisMetni = "Bilgisayar ve Bilişim Fakültesi";
            Console.WriteLine("-------Aranan kelime: \"i\" ");
            string harfIndis = "i";
            Console.WriteLine("- - - -Girdiğiniz değer için istenilen karakterin indisi: ");
            BenimString.DegerIndis(degerIndisMetni, harfIndis);

            Console.WriteLine();

            Console.WriteLine("8. Girilen metnin karakterlerini A-Z'ye sıralayan fonksiyon.");
            Console.WriteLine("------ Metnini yazın: Bilgisayar ve Bilişim Fakültesi");
            string AZmetin = "Bilgisayar ve Bilişim Fakültesi";
            Console.Write("- - - -Girdiğiniz metin karakterlerin A-Z'ye sıralama hali = ");
            BenimString.SiralaAZ(AZmetin);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("9. Girilen metnin karakterlerini Z-A'ya sıralayan fonksiyon.");
            Console.WriteLine("-------Metnini yazın: Bilgisayar ve Bilişim Fakültesi");
            string ZAmetin = "Bilgisayar ve Bilişim Fakültesi";
            Console.Write("- - - -Girdiğiniz metin karakterlerin Z-A'ya sıralama hali = ");
            BenimString.SiralaZA(ZAmetin);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("10. Girilen metin ters ceviren fonksiyon.");
            Console.WriteLine("-------Metni yazın: Google, YouTube");
            string tersCevir = "Google, YouTube";
            Console.WriteLine("- - - -Girdiğiniz metin karakterlerin ters ceviren hali = \"{0}\" dur", BenimString.TersCevir(tersCevir));

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("+ + +Başka bir işlem yapmak istiyor musunuz (E/H)? ");
            string cevap = Console.ReadLine();
            if (cevap.ToLower() == "e")
            {
                do
                {
                    Console.WriteLine("1. Metindeki eleman sayısını veren fonksiyon.");
                    Console.WriteLine("2. İki string metin değeri birleştiren fonksiyon.");
                    Console.WriteLine("3. Bir metnin arasına yerleştirecek karakter yazan fonksiyon.");
                    Console.WriteLine("4. Belirtilen indisten başlayarak, belirtilen karakter kadar metni parçasını döndüren fonksiyon.");
                    Console.WriteLine("5. Metinden karakter kaldıran fonksiyon.");
                    Console.WriteLine("6. Verilen string metin, char diziye dönüştüren fonksiyon.");
                    Console.WriteLine("7. Aranan karakterin indisini döndüren fonksiyon.");
                    Console.WriteLine("8. Girilen metnin karakterlerini A-Z'ye sıralayan fonksiyon.");
                    Console.WriteLine("9. Girilen metnin karakterlerini Z-A'ya sıralayan fonksiyon.");
                    Console.WriteLine("10. Girilen metin ters ceviren fonksiyon.");

                    Console.WriteLine();

                    Console.Write("Hangi fonksiyon seçmek istiyorsunuz? ");
                    int secenek = Int32.Parse(Console.ReadLine());

                    if (secenek == 1)
                    {
                        Console.Write("------ Metnini yazın: ");
                        string metinTest = Console.ReadLine();
                        Console.WriteLine("- - - -Girdiğiniz metni için eleman sayısı = {0}", BenimString.ElemanSayisi(metinTest));
                    }
                    else if (secenek == 2)
                    {
                        Console.WriteLine("-------Birleştirecek metinleri yazın: ");
                        Console.Write("-------1. metin =  ");
                        string metin1Test = Console.ReadLine();
                        Console.Write("-------2. metin = ");
                        string metin2Test = Console.ReadLine();
                        Console.WriteLine("- - - -Girdiğiniz metinler için birleşik hali \"{0}\" dır.", BenimString.Birlestir(metin1Test, metin2Test));
                    }
                    else if (secenek == 3)
                    {
                        Console.Write("-------Metnini yazın: ");
                        string arayaGirMetinTest = Console.ReadLine();
                        Console.Write("-------Hangi indisde karakter yerleştirmek istiyorsunuz? ");
                        int indeksTest = Int32.Parse(Console.ReadLine());
                        Console.Write("-------Hangi karakter eklemek istiyorsunuz? ");
                        string karakterTest = Console.ReadLine();
                        Console.WriteLine("- - - -Girdiğiniz değerler için metnin son hali = {0} ", BenimString.ArayaGir(arayaGirMetinTest, indeksTest, karakterTest));
                    }
                    else if (secenek == 4)
                    {
                        Console.Write("-------Metnini yazın: ");
                        string degerAlMetinTest = Console.ReadLine();
                        Console.Write("-------Indisini belirtin: ");
                        int indexTest = Int32.Parse(Console.ReadLine());
                        Console.Write("-------Hangi karaktere kadar: ");
                        string characterTest = Console.ReadLine();
                        int harfKonumuTest = degerAlMetinTest.IndexOf(characterTest);
                        Console.WriteLine("- - - -Girdiğiniz değer için istenilen metni = \"{0}\" dur", BenimString.DegerAl(degerAlMetinTest, indexTest, harfKonumuTest));
                    }
                    else if (secenek == 5)
                    {
                        Console.Write("-------Metnini yazın: ");
                        string diziyeAyirMetniTest = Console.ReadLine();
                        Console.Write("-------Karakter:  ");
                        char harfTest = Char.Parse(Console.ReadLine());
                        Console.WriteLine("- - - -Girdiğiniz değer için istenilen metni = \"{0}\" dir", BenimString.DiziyeAyir(diziyeAyirMetniTest, harfTest));
                    }
                    else if (secenek == 6)
                    {
                        Console.Write("-------Metnini yazın: ");
                        string diziTest = Console.ReadLine();
                        Console.Write("- - - -Girdiğiniz değer için char diziye kaydetilen metin: ");
                        Console.WriteLine(BenimString.CharDiziyeDonustur(diziTest));
                    }
                    else if (secenek == 7)
                    {
                        Console.Write("-------Metni yazın: ");
                        string degerIndisMetniTest = Console.ReadLine();
                        Console.Write("-------Aranan kelime:  ");
                        string harfIndisTest = Console.ReadLine();
                        Console.Write("- - - -Girdiğiniz değer için istenilen karakterin indisi: ");
                        BenimString.DegerIndis(degerIndisMetniTest, harfIndisTest);
                    }
                    else if (secenek == 8)
                    {
                        Console.Write("------ Metnini yazın: ");
                        string AZmetinTest = Console.ReadLine();
                        Console.Write("- - - -Girdiğiniz metin karakterlerin A-Z'ye sıralama hali = ");
                        BenimString.SiralaAZ(AZmetinTest);
                    }
                    else if (secenek == 9)
                    {
                        Console.Write("------ Metnini yazın: ");
                        string ZAmetinTest = Console.ReadLine();
                        Console.Write("- - - -Girdiğiniz metin karakterlerin A-Z'ye sıralama hali = ");
                        BenimString.SiralaAZ(ZAmetinTest);
                    }
                    else if (secenek == 10)
                    {
                        Console.Write("-------Metni yazın: ");
                        string tersCevirTest = Console.ReadLine();
                        Console.WriteLine("- - - -Girdiğiniz metin karakterlerin ters ceviren hali = \"{0}\" dur", BenimString.TersCevir(tersCevirTest));
                    }
                    else
                    {
                        Console.WriteLine("Yanlış bir değer girdiniz.");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("+ + +Başka bir işlem yapmak istiyor musunuz (E/H)? ");
                    cevap = Console.ReadLine();
                } while (cevap.ToLower() == "e");
                Console.Clear();
            }
            Console.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test.Smth();
        }
    }
}