

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    namespace NDP_odev2
    {
        class Pencerem : Form
        {
            public Pencerem(int genislik = 600, int yukseklik = 500)
            {
                Width = genislik;
                Height = yukseklik;

                mBtnHesapla = new Button();
                mBtnHesapla.Text = "HESAPLA";
                mBtnHesapla.SetBounds(190, 360, 200, 70);
                Controls.Add(mBtnHesapla);
                mBtnHesapla.Click += MBtnHesapla_Click;

                mTxtYazi = new TextBox();
                mTxtYazi.SetBounds(250, 100, 70, 100);
                mTxtYazi.TextAlign = HorizontalAlignment.Center;
                Controls.Add(mTxtYazi);

                mLblFatura = new Label();
                mLblFatura.SetBounds(50, 200, 470, 20);
                mLblFatura.BorderStyle = BorderStyle.FixedSingle;
                mLblFatura.TextAlign = (System.Drawing.ContentAlignment)HorizontalAlignment.Center;
                Controls.Add(mLblFatura);

            }

            private Button mBtnHesapla;
            private TextBox mTxtYazi;
            private Label mLblFatura;

            private void MBtnHesapla_Click(object sender, EventArgs e)
            {
                string tamKisim;
                string kesirliKisim;
                string girilendeger = mTxtYazi.Text;
                int girilendegeruzunlugu = girilendeger.Length;//girilendegerin uzunlugunu aliyorum
                int girilennoktasayisi = 0;
                for (int i = 0; i < girilendegeruzunlugu; i++)//girilen degerdeki nokta sayisini veren dongu
                {
                    if (girilendeger[i] == '.')
                    {
                        girilennoktasayisi++;
                    }
                }
                bool farklikaraktervarmi = true;
                for (int i = 0; i < girilendegeruzunlugu; i++)
                {
                    if (girilendeger[i] != '.' && !(char.IsDigit(girilendeger[i])))//girilen degrede istenmeyen karakter varmi diye bakiyorum
                    {
                        farklikaraktervarmi = false;
                    }

                }

                if (farklikaraktervarmi)//eger girilen degerde istenemyen karakter yok ise
                {
                    if (girilennoktasayisi <= 1)// çoklu nokta kullanma hatası çözüm
                    {
                        int ondalikvarmi = girilendeger.IndexOf(".");//girilen degerde nokta olup olmadigina bakiyorum
                        int tamkisimuzunlugu;
                        int kesirlikisimuzunlugu;

                        if (ondalikvarmi != -1)//eger dizide nokta varsa diziyi tam ve kesirli olmak uzere 2 kisima ayiriyorum
                        {
                            string[] kısım = girilendeger.Split('.');
                            tamKisim = kısım[0];
                            kesirliKisim = kısım[1];
                            tamkisimuzunlugu = tamKisim.Length;
                            kesirlikisimuzunlugu = kesirliKisim.Length;
                        }
                        else//eger dizide nokta yoksa kesirli kisima null degeri atiyorum
                        {
                            tamKisim = girilendeger;
                            kesirliKisim = null;
                            tamkisimuzunlugu = tamKisim.Length;
                            kesirlikisimuzunlugu = 0;
                        }

                        if (ondalikvarmi != 0 && ondalikvarmi != girilendegeruzunlugu - 1)// yanlış nokta kullanma hatası çözümü
                        {

                            if (tamkisimuzunlugu <= 5 && kesirlikisimuzunlugu <= 2)//istenilen sayida karakter girilmemesi sorunu cozumu
                            {
                                int kesirlionlarbasamagi = 0;
                                int kesirlibirlerbasamagi = 0;

                                if (kesirliKisim != null)//eger girilen degerde kesirli kisim var ise
                                {
                                    int kesirlikisimdegeri = int.Parse(kesirliKisim);//string olan kersirli kisim ifadfesini integer yapiyorum
                                    kesirlionlarbasamagi = kesirlikisimdegeri / 10;
                                    kesirlibirlerbasamagi = kesirlikisimdegeri % 10;
                                }
                                //yazdiricagim degerlere once bull atiyorum
                                string onbinler = null;
                                string binler = null;
                                string yüzler = null;
                                string onlar = null;
                                string birler = null;
                                string kesirlionlar = null;
                                string kesirlibirler = null;

                                string[] Birler = { "", " BİR", " İKİ", " ÜÇ", " DÖRT", " BEŞ", " ALTI", " YEDİ", " SEKİZ", " DOKUZ" };

                                string[] Onlar = { "", " ON", " YİRMİ", " OTUZ", " KIRK", " ELLİ", " ALTMIŞ", " YETMİŞ", " SEKSEN", " DOKSAN" };

                                int tamKisimDegeri = int.Parse(tamKisim);

                                //bolme ve mod alma islemleri gerceklestirilerek basamaklardaki sayilarin bulundugu kisim
                                int onbinlerbas = tamKisimDegeri / 10000;
                                int binlerbas = (tamKisimDegeri % 10000) / 1000;
                                int yüzlerbas = (tamKisimDegeri % 1000) / 100;
                                int onlarbas = (tamKisimDegeri % 100) / 10;
                                int birlerbas = (tamKisimDegeri % 10);

                                for (int i = 1; i < 10; i++)//yukarida tanimladigim dizinin elemanlarina ulasmak icin yazdigim dongu
                                {
                                    if (i == onbinlerbas)//dongudeki rakam onbinlerbasamagindaki rakama esit ise
                                    {
                                        onbinler = Onlar[i];

                                        if (binlerbas == 0)
                                        {
                                            onbinler += " BİN";
                                        }
                                    }

                                    if (i == binlerbas)//dongudeki rakam onbinlerbasamagindaki rakama esit ise
                                    {
                                        binler = Birler[i] + " BİN";
                                        if (1 == binlerbas && onbinlerbas == 0)
                                        {
                                            binler = " BİN";
                                        }

                                    }

                                    if (i == yüzlerbas)//dongudeki rakam yüzbinlerbasamagindaki rakama esit ise
                                    {
                                        yüzler = Birler[i] + " YÜZ";
                                    }

                                    if (yüzlerbas == 1)
                                    {
                                        yüzler = " YÜZ";
                                    }


                                    if (i == onlarbas)//dongudeki rakam onlarbasamagindaki rakama esit ise
                                    {
                                        onlar = Onlar[i];
                                    }

                                    if (i == birlerbas)//dongudeki rakam birlerbasamagindaki rakama esit ise
                                    {
                                        birler = Birler[i];
                                    }

                                    if (i == kesirlionlarbasamagi)//dongudeki rakam kesirlionlarbasamagindaki rakama esit ise
                                    {
                                        kesirlionlar = Onlar[i];
                                    }

                                    if (i == kesirlibirlerbasamagi)//dongudeki rakam kesirlibirlerbasamagindaki rakama esit ise
                                    {
                                        kesirlibirler = Birler[i];
                                    }

                                }

                                if (onbinlerbas == 0 && binlerbas == 0 && yüzlerbas == 0 && onlarbas == 0 && birlerbas == 0 && kesirlibirlerbasamagi == 0 && kesirlionlarbasamagi == 0)
                                    mLblFatura.Text = ("SIFIR TL SIFIR KURUŞ");//sifir tl sifir kurus istinasinin yazdirilmasi

                                else if ((ondalikvarmi == -1 && kesirlibirler == null && kesirlionlar == null) || (kesirlibirlerbasamagi == 0 && kesirlionlarbasamagi == 0))
                                    mLblFatura.Text = (onbinler + binler + yüzler + onlar + birler + " TL");//kuruş kısmı bulunmayan degerin yazdirilmasi
                                else if (birlerbas == 0 && onlarbas == 0 && yüzlerbas == 0 && binlerbas == 0 && onbinlerbas == 0)
                                    mLblFatura.Text = (kesirlionlar + kesirlibirler + " KURUŞ");//tam kismi bulunmayan degerin yazdirilmasi

                                else mLblFatura.Text = (onbinler + binler + yüzler + onlar + birler + " TL" + kesirlionlar + kesirlibirler + " KURUŞ");//tam kismi ve kesirli kismi bulunan degerin yazdirilmasi

                            }
                            else MessageBox.Show("TAM KISIM EN FAZLA 5 , KESİRLİ KISIM EN FAZLA 2 BASAMAK OLABİLİR", "KARAKTER SAYISI AŞMA HATASI");
                        }
                        else MessageBox.Show("EĞER NOKTA DEĞERİ GİRİLİRSE İFADENİN TAM VE KESİRLİ KISIMI BULUNMALIDIR", "NOKTA KULLANMA HATASI");
                    }
                    else MessageBox.Show("GİRİLEN DEGER BİRDEN FAZLA NOKTA İÇEREMEZ", "FAZLA NOKTA KULLANMA HATASI");

                }
                else MessageBox.Show("GİRİLEN DEGER YALNIZCA BİR RAKAM VEYA NOKTA OLABİLİR", "GECERSİZ KARAKTER KULLANMA HATASI");
            }

        }

    }
