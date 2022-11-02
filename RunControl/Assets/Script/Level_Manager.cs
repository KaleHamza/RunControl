using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hamza;
using TMPro;

public class Level_Manager : MonoBehaviour
{
    public Button[] Butonlar;
    public int Level;
    public Sprite KilitButon;
    BellekYonetimi _Bellekyonetim = new BellekYonetimi();
    public AudioSource ButonSes;
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    [Header("---------DİL VERİLERİ")]
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] TextObjeler;
    [Header("---------SAHNE YÜKLEM OBJELERİ")]
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    void Start()
    {
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[2]);
        DilTercihYonetimi();

        ButonSes.volume = _Bellekyonetim.VeriOku_f("MenuFX");
        //_Bellekyonetim.VeriKaydet_int("SonLevel",Level);
        int mevcutLevel = _Bellekyonetim.VeriOku_i("SonLevel") -4 ;
        int Index = 1;
        
        for (int i = 0; i < Butonlar.Length; i++)
        {
            if(Index <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<Text>().text = Index.ToString();
                int SahneIndex = Index + 4;
                Butonlar[i].onClick.AddListener(delegate { SahneYukle(SahneIndex); });
                
            }else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitButon;
                Butonlar[i].enabled = false;
            }
            Index++;
        }

        
    }

    void DilTercihYonetimi()
    {
        string dil =_Bellekyonetim.VeriOku_s("Dil");
        if(dil == "TR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin;
            }

        }else if(dil == "EN")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin;
            }
        }else if(dil == "RS")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_RS[i].Metin;
            }
        }else if(dil == "SP")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_SP[i].Metin;
            }
        }else if(dil == "FR")
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
        StartCoroutine(LoadAsync(Index));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);//Sahne yüklenme oranını verir loadsceneAsync ve yüklenince girilen SceneIndexine göre sahneyi çalıştırır.
        YuklemeEkrani.SetActive(true);
        while (!operation.isDone)//isDone : tamamlandı .Yani tamamlanmadıysa devam et diyoruz.
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);//Clamp 01 gelen değeri 0 a veya 1 e daha yakınsa yakın olana yuvarlar.
            YuklemeSlider.value = progress;
            yield return null;
        }
    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }


}
