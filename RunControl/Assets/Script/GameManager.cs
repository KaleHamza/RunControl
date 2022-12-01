using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hamza;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static int AnlikKarakterSayisi = 1 ;
    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfekti;
    Matematiksel_islemler _Matematiksel_islemler = new Matematiksel_islemler();
    BellekYonetimi _BellekYonetimi = new BellekYonetimi();
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    //ReklamYonetim _ReklamYonetim = new ReklamYonetim();
    Scene _Scene;

    [Header("----------LEVEL VERİLERİ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;
    bool SonaGeldikmi;
    public int LevelZorlukKatsayi;
    public int LevelPuan;
    public int LevelEkstraPuanDeger;
    [Header("----------SAPKALAR")]
    public GameObject[] Sapkalar;
    [Header("----------SOPALAR")]
    public GameObject[] Sopalar;
    [Header("----------MATERIAL")]
    public Material[] Materyaller;
    public Material VarsayilanTema;
    public SkinnedMeshRenderer _Renderer;
    [Header("-----GENEL VERİLER")]
    public AudioSource[] Sesler;
    public GameObject[] islemPanelleri;
    public Slider OyunSesiAyar;
    public Button[] _DurdurVeAyarla;
    public TextMeshProUGUI[] PanelTextler;
    [Header("-----Dil VERİLERİ")]
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] TextObjeler;
    [Header("-----LOADING VERİLERİ")]
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;
    private void Awake()
    {
        Sesler[0].volume = _BellekYonetimi.VeriOku_f("OyunSes");
        Sesler[2].volume = _BellekYonetimi.VeriOku_f("OyunSes");
        OyunSesiAyar.value = _BellekYonetimi.VeriOku_f("OyunSes");
        Sesler[1].volume = _BellekYonetimi.VeriOku_f("MenuFX");
        Destroy(GameObject.FindWithTag("MenuSes"));
        ItemleriKontrolEt();
    }
    
    void Start()
    { 
       
        PanelTextler[3].text = LevelEkstraPuanDeger.ToString();
        DusmanlariOlustur();
        _Scene = SceneManager.GetActiveScene();
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[5]);
        DilTercihYonetimi();        
        //_ReklamYonetim.RequestRewardedAd();
        //_ReklamYonetim.RequestInterstitial();
        
        AnlikKarakterSayisi = 1;
        
    }
    
    void DilTercihYonetimi()
    {   
        string dil = _BellekYonetimi.VeriOku_s("Dil");
        if(dil == "TR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin;
            }
        }
        else if(dil == "EN")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin;
            }
        }
        else if(dil == "RS")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_RS[i].Metin;
            }
        }
        else if(dil == "SP")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_SP[i].Metin;
            }
        }
        else if(dil == "FR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_FR[i].Metin;
            }
        }
        else if(dil == "AR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_AR[i].Metin;
            }
        }
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }
    
    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if(item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikmi = true;
        SavasDurumu();
    }
    
    void SavasDurumu()
    {
        if(SonaGeldikmi)
        {
            if(AnlikKarakterSayisi == 1 || KacDusmanOlsun ==0)
            {
                OyunBittimi = true;
                foreach (var item in Dusmanlar)
                {
                    if(item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir",false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if(item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir",false);
                    }
                }                
                _AnaKarakter.GetComponent<Animator>().SetBool("Saldir",false);
                //_ReklamYonetim.GecisReklamiGoster();               
                if(AnlikKarakterSayisi<KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun )
                {
                    islemPanelleri[3].SetActive(true);     
                    _DurdurVeAyarla[0].interactable = false;
                    _DurdurVeAyarla[1].interactable = false;
                }
                else
                {  
                    if(AnlikKarakterSayisi>5)
                    {
                        if(_Scene.buildIndex == _BellekYonetimi.VeriOku_i("SonLevel"))
                        {
                            LevelPuan=40;
                            _BellekYonetimi.VeriKaydet_int("SonLevel",_BellekYonetimi.VeriOku_i("SonLevel") + 1);
                        }         
                    }else
                    {
                        if(_Scene.buildIndex == _BellekYonetimi.VeriOku_i("SonLevel"))
                        {
                            LevelPuan = 20;
                            _BellekYonetimi.VeriKaydet_int("SonLevel",_BellekYonetimi.VeriOku_i("SonLevel") + 1);
                        }
                    }
                   KazandinPanel();                   
                }  
            }
            
        }        
    }

    public void AdamYonetim(string islemturu,int GelenSayi , Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
            _Matematiksel_islemler.Carpma(GelenSayi,Karakterler,Pozisyon,OlusmaEfektleri);                
                break;
            case "Toplama":
            _Matematiksel_islemler.Toplama(GelenSayi,Karakterler,Pozisyon,OlusmaEfektleri);
                break;
            case "Cikartma":
            _Matematiksel_islemler.Cikartma(GelenSayi,Karakterler,YokOlmaEfektleri);
                break;
            case "Bolme":
            _Matematiksel_islemler.Bolme(GelenSayi,Karakterler,YokOlmaEfektleri);                    
                break;                        
        }
    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon,bool Balyoz = false,bool Durum = false)
    {
        foreach (var item in YokOlmaEfektleri)
        {   
            if(!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if(!Durum)
                    AnlikKarakterSayisi--;                  
                else
                    KacDusmanOlsun--;
                break;
            } 
        }        
        if(Balyoz)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, .005f,Pozisyon.z);
            foreach (var item in AdamLekesiEfekti)
            {   
                if(!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
            }
        }
        if(!OyunBittimi)
            SavasDurumu();
    }   

    public void ItemleriKontrolEt()
    {
        if(_BellekYonetimi.VeriOku_i("AktifSapka") != -1)
            Sapkalar[_BellekYonetimi.VeriOku_i("AktifSapka")].SetActive(true);        
        if(_BellekYonetimi.VeriOku_i("AktifSopa") != -1)
            Sopalar[_BellekYonetimi.VeriOku_i("AktifSopa")].SetActive(true);        
        if(_BellekYonetimi.VeriOku_i("AktifTema") != -1)
        {
            Material[] mats = _Renderer.materials;
            mats[0] = Materyaller[_BellekYonetimi.VeriOku_i("AktifTema")];
            _Renderer.materials = mats;
        }
        else
        {
            Material[] mats = _Renderer.materials;
            mats[0] = VarsayilanTema;
            _Renderer.materials = mats;            
        }
    }

    public void CikisButonİslem(string durum)
    {
        Sesler[1].Play();
        Time.timeScale = 0;
        if(durum == "durdur")
        {
            Sesler[0].mute = true;
            islemPanelleri[0].SetActive(true);
            _DurdurVeAyarla[0].interactable = false;
            _DurdurVeAyarla[1].interactable = false;
        }
        else if(durum == "devamet")
        {
            Sesler[0].mute = false;
            islemPanelleri[0].SetActive(false);
            Time.timeScale = 1;
            _DurdurVeAyarla[0].interactable = true;
            _DurdurVeAyarla[1].interactable = true;
        }
        else if(durum == "tekrar")
        {
            Sesler[0].mute = false;
            SceneManager.LoadScene(_Scene.buildIndex);
            Time.timeScale = 1;   
            _DurdurVeAyarla[0].interactable = true;
            _DurdurVeAyarla[1].interactable = true; 
            
        }
        else if(durum == "anasayfa")
        {
            Sesler[0].mute = true;
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            _DurdurVeAyarla[0].interactable = true;
            _DurdurVeAyarla[1].interactable = true;
        }            
    }
    
    public void Ayarlar(string durum)
    {
        
        if(durum == "ayarla")
        {         
            Sesler[0].mute = true;
            islemPanelleri[1].SetActive(true);
            Time.timeScale = 0;
            _DurdurVeAyarla[0].interactable = false;
            _DurdurVeAyarla[1].interactable = false;
        }
        else if(durum == "kapat")
        {
            Sesler[0].mute = false;
            _DurdurVeAyarla[0].interactable = true;
            _DurdurVeAyarla[1].interactable = true;
            islemPanelleri[1].SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public void SesiAyarla()
    {   
        _BellekYonetimi.VeriKaydet_float("OyunSes",OyunSesiAyar.value);
        Sesler[0].volume = OyunSesiAyar.value;
        Sesler[2].volume = OyunSesiAyar.value;
        
    }

    public void SonrakiLevel()
    {
        StartCoroutine(LoadAsync(_Scene.buildIndex + 1));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        YuklemeEkrani.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            YuklemeSlider.value = progress;
            yield return null;
        }
    }

    /*public void OdulReklami()
    {
        _ReklamYonetim.OdulReklamiGoster();
        _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i("Puan")+200);
        PanelTextler[0].text = _BellekYonetimi.VeriOku_i("Puan").ToString();
    }*/

    void KazandinPanel()
    {   
        _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i("Puan")+LevelPuan + AnlikKarakterSayisi * LevelZorlukKatsayi);
        PanelTextler[0].text = PlayerPrefs.GetInt("Puan").ToString();
        PanelTextler[1].text = (AnlikKarakterSayisi).ToString() + " Arthur";
        PanelTextler[2].text = "+ "+(AnlikKarakterSayisi * LevelZorlukKatsayi).ToString();
        _DurdurVeAyarla[0].interactable = false;
        _DurdurVeAyarla[1].interactable = false;
        islemPanelleri[2].SetActive(true);
    }
    
}
