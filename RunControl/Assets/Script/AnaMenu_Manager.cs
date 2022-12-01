using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Hamza;

public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetimi _Bellekyonetim = new BellekYonetimi();
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    [Header("----------GENEL ISLEMLER")]
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _Varsayilan_ItemBilgileri = new List<ItemBilgileri>();    
    public AudioSource ButonSes;
    
    [Header("----------DİL VERİLERİ")]
    public List<DilVerileriAnaObje> _Varsayilan_DilVerileri = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();  
    public TextMeshProUGUI[] TextObjeler;
    [Header("----------YÜKLEME EKRANI")]
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    void Start()
    {
       
        _Bellekyonetim.KontrolEtveTanimla();
        _VeriYonetimi.IlkKurulumDosyaOlusturma(_Varsayilan_ItemBilgileri, _Varsayilan_DilVerileri);
        ButonSes.volume = _Bellekyonetim.VeriOku_f("MenuFX");//MenuFX yazmadığım için çalışmadı!!!!!!
        //_Bellekyonetim.VeriOku_f("Dil");
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[0]);
        DilTercihYonetimi();       
    }

    void DilTercihYonetimi()
    {
        string dil = _Bellekyonetim.VeriOku_s("Dil");
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
        else
            Debug.Log("Something wrong.");
    }

    public void SahneYukle(int Index)
    {
        
        ButonSes.Play();
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        ButonSes.Play();
        if(_Bellekyonetim.VeriOku_i("SonLevel")<35)
        StartCoroutine(LoadAsync(_Bellekyonetim.VeriOku_i("SonLevel")));
        else
        StartCoroutine(LoadAsync(34));
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
    
    public void CikisButonİslem(string durum)
    {
        ButonSes.Play();
        if(durum == "Evet")
            Application.Quit();
        else if(durum =="Cikis")
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }
}
