using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//Sahne yüklemesi
using Hamza;
using TMPro;
public class Ayarlar_Manager : MonoBehaviour
{
    public AudioSource ButonSes;
    public Slider MenuSes;
    public Slider MenuFX;
    public Slider OyunSes;

    BellekYonetimi _BellekYonetim = new BellekYonetimi();
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] TextObjeler;
    
    [Header("----------DİL TERCİHİ OBJELERİ")]
    public TextMeshProUGUI DilText;
    public Button[] DilButonlari;
    int AktifDilIndex ;

    void Start()
    {
        
        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFX");
        MenuSes.value = _BellekYonetim.VeriOku_f("MenuSes");
        MenuFX.value = _BellekYonetim.VeriOku_f("MenuFX");
        OyunSes.value = _BellekYonetim.VeriOku_f("OyunSes");       
        //_BellekYonetim.VeriKaydet_string("Dil","TR");
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[4]);
        DilTercihYonetimi();
        DilDurumunuKontrolEt();    
    }

    void DilTercihYonetimi()
    {
        string dil = _BellekYonetim.VeriOku_s("Dil");
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

    public void SesAyarla(string HangiAyar)
    {
        switch(HangiAyar)
        {
            case "menuses":               
                _BellekYonetim.VeriKaydet_float("MenuSes",MenuSes.value);
                break;
            case "menufx":           
                _BellekYonetim.VeriKaydet_float("MenuFX",MenuFX.value);
                break;
            case "oyunses":
                _BellekYonetim.VeriKaydet_float("OyunSes",OyunSes.value);
                break;

        }

    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);//Sıfır indeksli sahneyi bana oynat
    }
 
    void DilDurumunuKontrolEt()
   
   {
        string dil = _BellekYonetim.VeriOku_s("Dil");
        if(dil == "TR")
        {   
            AktifDilIndex = 0;
            DilText.text = "TÜRKÇE";
            DilButonlari[0].interactable = false;
        }
        else if(dil == "EN")
        {
             AktifDilIndex = 1;
            DilText.text = "ENGLISH";
        } 
        else if(dil == "RS")
        {
            AktifDilIndex = 2;
            DilText.text = "РУССКИЙ";
        }
        else if(dil == "SP")
        {
             AktifDilIndex = 3;
             DilText.text = "ESPAÑOL";
            
        }
        else if(dil == "FR")
        {
            AktifDilIndex = 4;
             DilText.text = "FRANCÉS";
        }
        else if(dil == "AR")
        {
            AktifDilIndex = 5;
             DilText.text = "ﻲﺑﺮﻋ";
            DilButonlari[1].interactable = false;
        }
   
   
   }
    
    
    
    
    public void DilDegistir(string Yon)
    {
        if(Yon =="ileri")
        {
            
            AktifDilIndex++;
            if(AktifDilIndex == 1)
                    {
                    AktifDilIndex = 1;
                    DilText.text = "ENGLISH";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","EN");
                    DilTercihYonetimi();
                    
                    }
            else if(AktifDilIndex == 2)
                {
                     AktifDilIndex = 2;
                    DilText.text = "РУССКИЙ";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","RS");
                    DilTercihYonetimi();
                    
                }
            
            else if(AktifDilIndex == 3)
                {
                     AktifDilIndex = 3;
                    DilText.text = "ESPAÑOL";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","SP");
                    DilTercihYonetimi();
                    
                }
            else if(AktifDilIndex == 4)
                {
                    AktifDilIndex = 4;
                    DilText.text = "FRANCÉS";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","FR");
                    DilTercihYonetimi();
                    
                }
            else if(AktifDilIndex == 5)
                {
                    AktifDilIndex = 5;
                    DilText.text = "ﻲﺑﺮﻋ";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = false;
                    _BellekYonetim.VeriKaydet_string("Dil","AR");
                    DilTercihYonetimi();
                    
                }
           
                    
            
            

        }else
        {
            
            AktifDilIndex--;
            if(AktifDilIndex == 0)
                    {
                     AktifDilIndex = 1;
                    DilText.text = "TÜRKÇE";
                    DilButonlari[0].interactable = false;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","TR");
                    DilTercihYonetimi();
                    
                    }
            else if(AktifDilIndex == 1)
                    {
                    AktifDilIndex = 1;
                    DilText.text = "ENGLISH";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","EN");
                    DilTercihYonetimi();
                    
                    }
            else if(AktifDilIndex == 2)
                {
                     AktifDilIndex = 2;
                    DilText.text = "РУССКИЙ";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","RS");
                    DilTercihYonetimi();
                    
                }
            else if(AktifDilIndex == 3)
                {
                     AktifDilIndex = 3;
                    DilText.text = "ESPAÑOL";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","SP");
                    DilTercihYonetimi();
                    
                }
                else if(AktifDilIndex == 4)
                {
                    AktifDilIndex = 4;
                    DilText.text = "FRANCÉS";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = true;
                    _BellekYonetim.VeriKaydet_string("Dil","FR");
                    DilTercihYonetimi();
                    
                }
                else if(AktifDilIndex == 5)
                {
                    AktifDilIndex = 5;
                    DilText.text = "ﻲﺑﺮﻋ";
                    DilButonlari[0].interactable = true;
                    DilButonlari[1].interactable = false;
                    _BellekYonetim.VeriKaydet_string("Dil","AR");
                    DilTercihYonetimi();
                    
                }
                
        

        }


        ButonSes.Play();

    }
}
