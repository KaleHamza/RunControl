using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GoogleMobileAds.Api;

namespace Hamza
{

    public class Matematiksel_islemler 
    {       
        public void Carpma(int GelenSayi, List<GameObject> Karakterler,Transform Pozisyon,List<GameObject> OlusmaEfektleri)
        {                       
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * GelenSayi) - GameManager.AnlikKarakterSayisi; 
            int sayi = 0;
            foreach (var item in Karakterler)
            {  
                if(sayi < DonguSayisi)
                {
                    if(!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusmaEfektleri)
                        {
                            if(!item2.activeInHierarchy)
                            {                        
                                item2.SetActive(true);
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;                                
                    }
                }else
                {   
                    sayi = 0;
                    break;
                }
            }
            GameManager.AnlikKarakterSayisi *= GelenSayi;  
            
                     
        }
        
        public void Toplama(int GelenSayi, List<GameObject> Karakterler,Transform Pozisyon,List<GameObject> OlusmaEfektleri)
        {
            int sayi1 = 0;
            foreach (var item in Karakterler)
            {  
                if(sayi1 < GelenSayi)
                {
                    if(!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusmaEfektleri)
                        {
                            if(!item2.activeInHierarchy)
                            {                                    
                                item2.SetActive(true);
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi1++;                                  
                    }

                }else
                {   
                    sayi1 = 0;
                    break;
                }
            }
            GameManager.AnlikKarakterSayisi += GelenSayi;   
            
        }

        public void Cikartma(int GelenSayi, List<GameObject> Karakterler,List<GameObject> YokOlmaEfektleri)
        {
            if(GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if(!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f,item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);        
                }
                GameManager.AnlikKarakterSayisi = 1;
                  
            }
            else
            {            
                int sayi2 = 0;
                foreach (var item in Karakterler)
                {  
                    if(sayi2 != GelenSayi)
                    {
                        if(item.activeInHierarchy)
                        {   
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if(!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f,item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi2++;                                
                        }
                    }else
                    {   
                        sayi2 = 0;
                        break;
                    }
                }
                GameManager.AnlikKarakterSayisi -= GelenSayi;   
                         
            }
        }

        public void Bolme(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {

            if (GameManager.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.AnlikKarakterSayisi = 1;   
                
            }
            else
            {
                int bolen = GameManager.AnlikKarakterSayisi / GelenSayi;
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != bolen)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }


                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;
                        }

                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }
                }
                if (GameManager.AnlikKarakterSayisi % GelenSayi == 0)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                   
                }
                else if (GameManager.AnlikKarakterSayisi % GelenSayi == 1)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi++;
                    
                }
                else if (GameManager.AnlikKarakterSayisi % GelenSayi == 2)
                {
                    GameManager.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.AnlikKarakterSayisi += 2;
                    
                }

            }

        }
    }

    public class BellekYonetimi
    {
        public void VeriKaydet_string(string Key,string value)
        {   
            PlayerPrefs.SetString(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_int(string Key,int value)
        {
            PlayerPrefs.SetInt(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_float(string Key, float value)
        {
            PlayerPrefs.SetFloat(Key,value);
            PlayerPrefs.Save();
        }

        public string VeriOku_s(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }
        
        public int VeriOku_i(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }
        
        public float VeriOku_f(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }

        public void KontrolEtveTanimla()
        {
            
            if(!PlayerPrefs.HasKey("SonLevel"))//Sistemde SonLevel isminde anahtar var mı?
            {
                PlayerPrefs.SetInt("SonLevel",5);//Yoksa 5 Id li eleman son level olur.
                PlayerPrefs.SetInt("Puan",600);
                PlayerPrefs.SetInt("AktifSapka",-1);
                PlayerPrefs.SetInt("AktifSopa",-1);
                PlayerPrefs.SetInt("AktifTema",-1);
                PlayerPrefs.SetFloat("MenuSes",1);
                PlayerPrefs.SetFloat("MenuFX",1);
                PlayerPrefs.SetFloat("OyunSes",1);
                PlayerPrefs.SetString("Dil","TR");
                PlayerPrefs.SetInt("Gecisreklamsayisi",1);
                PlayerPrefs.SetInt("Odulreklamsayisi",1);
            }
        }
    }
    
    [Serializable]//Bu classın serileşmesini ve liste gibi kullanabilmemizi sağlıyor

    public class ItemBilgileri
    {
        public int GrupIndex;//Şapka,sopa gibi grupların indexi
        public int Item_Index;//İlgili modelin listedeki sırası
        public string Item_Ad;//İtemin adı
        public int Puan;//İtemin bedeli ne?
        public bool SatinAlmaDurumu;
    }

    public class VeriYonetimi
    {
            public void Save(List<ItemBilgileri> _ItemBilgileri)
        {   
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
                bf.Serialize(file, _ItemBilgileri);
                file.Close();
        }   

            
        
        List<ItemBilgileri> _ItemicListe;
        
        public void Load()
        {
            if(File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd",FileMode.Open);
            _ItemicListe = (List<ItemBilgileri>)bf.Deserialize(file);
            file.Close();
            
            }
        }

        public List<ItemBilgileri> ListeyiAktar()
        {
            return _ItemicListe;
        }

         public void IlkKurulumDosyaOlusturma(List<ItemBilgileri> _ItemBilgileri,List<DilVerileriAnaObje> _DilVerileri)
        {   
                if(!File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
                    bf.Serialize(file, _ItemBilgileri);
                    file.Close();
                }

                if(!File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Create(Application.persistentDataPath + "/DilVerileri.gd");
                    bf.Serialize(file, _DilVerileri);
                    file.Close();
                }
            
        }   

        //------------------------------------------
        List<DilVerileriAnaObje> _DilVerileriicListe;

        public void Dil_Load()
        {
            if(File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
            {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DilVerileri.gd",FileMode.Open);
            _DilVerileriicListe = (List<DilVerileriAnaObje>)bf.Deserialize(file);
            file.Close();
            
            }
        }

        public List<DilVerileriAnaObje> DilVerileriListeyiAktar()
        {
            return _DilVerileriicListe;
        }
    }


//------------------------------------------------DİL YÖNETİMİ

    [Serializable]

    public class DilVerileriAnaObje
    {
        
        public List<DilVerileri_TR> _DilVerileri_TR = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_EN = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_AR = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_RS = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_SP = new List<DilVerileri_TR>();
        public List<DilVerileri_TR> _DilVerileri_FR = new List<DilVerileri_TR>();
        
    }
    [Serializable]
    public class DilVerileri_TR
    {
        public string Metin;
    }



//------------------------------------------------DİL YÖNETİMİ

    public class ReklamYonetim
    {
        public InterstitialAd interstitial;
        public RewardedAd _RewardedAd;
        //GEÇİŞ REKLAMI
        public void RequestInterstitial()
        {
            string AdUnitId;
            #if UNITY_ANDROID
                                            AdUnitId = "ca-app-pub-3940256099942544/1033173712";
            #elif UNITY_IPHONE
                                            AdUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                        AdUnitId = "unexpected_platform";
                                #endif   
                        interstitial = new InterstitialAd(AdUnitId);
                        AdRequest request = new AdRequest.Builder().Build();// Reklam isteği yollama ve çalıştırma
                        interstitial.LoadAd(request); //oluşturulan isteği Loadladık

                        interstitial.OnAdClosed +=GecisReklamiKapatildi; //Bu işlem tetiklendiğinde += Geçiş reklamı kapatılırsa sağdaki fonksyion çalışır
                    }

        void GecisReklamiKapatildi(object Sender ,EventArgs args)//NORMAL FONKSİYON DEĞİL ABONE OLAN BİR FONKSYİON (PARANTEZ O YÜZDEN BÖYLE DOLU)
        {
            interstitial.Destroy();
            RequestInterstitial();
        }

        public void GecisReklamiGoster()
        {
            if(PlayerPrefs.GetInt("Gecisreklamsayisi")== 2)
            {
                if(interstitial.IsLoaded())
                {
                    PlayerPrefs.SetInt("Gecisreklamsayisi",1);
                    interstitial.Show();
                }
                else
                {
                    interstitial.Destroy();
                    RequestInterstitial();
                }                
            }
            else
            {
                PlayerPrefs.SetInt("Gecisreklamsayisi", PlayerPrefs.GetInt("Gecisreklamsayisi") + 1);
            }
            
            
        }

        //ÖDÜLLÜ REKLAM

        public void RequestRewardedAd()
        {
            string AdUnitId;
            #if UNITY_ANDROID
                                            AdUnitId = "ca-app-pub-3940256099942544/5224354917";
            #elif UNITY_IPHONE
                                            AdUnitId = "ca-app-pub-3940256099942544/1712485313";
            #else
                        AdUnitId = "unexpected_platform";
                                #endif
                        _RewardedAd = new RewardedAd(AdUnitId);
                        AdRequest request = new AdRequest.Builder().Build();
                        _RewardedAd.LoadAd(request);

                        _RewardedAd.OnUserEarnedReward += OdulReklamiTamamlandi;
                        _RewardedAd.OnAdClosed += OdulReklamiKapatildi;
                        _RewardedAd.OnAdClosed += OdulReklamiYuklendi;
                    }
        void OdulReklamiTamamlandi(object Sender ,Reward e)
        {
            string type = e.Type;
            double amount = e.Amount;
            Debug.Log("Ödül Alınsın : " + type + "--" + amount);
        }
        void OdulReklamiKapatildi(object Sender ,EventArgs e)
        {
            Debug.Log("Ödüllü Reklam Kapatıldı");
            RequestRewardedAd();
        }
        void OdulReklamiYuklendi(object Sender ,EventArgs e)
        {
            Debug.Log("Ödüllü Reklam Yüklendi");
            RequestRewardedAd();
        }

        public void OdulReklamiGoster()
        {            
                if(_RewardedAd.IsLoaded())
                {                 
                    _RewardedAd.Show();
                }
        }
    }



}