using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hamza;
using TMPro;
using UnityEngine.SceneManagement;

public class Ozellestirme : MonoBehaviour
{
    int SapkaIndex = -1;
    int SopaIndex = -1;
    int MateryalIndex = -1;
    int AktifIslemPaneliIndex;
    string SatinAlmaText;
    string ItemText;
    BellekYonetimi _BellekYonetimi = new BellekYonetimi();
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();    
    [Header("---------PANLER İŞLEMLERİ")]   
    public GameObject[] islemPanelleri;   
    public GameObject islemCanvasi; 
    public GameObject[] GenelPaneller;
    public Button[] islemButonlari;
    [Header("----------SOPALAR")]
    public GameObject[] Sopalar;
    public Button[] SopaButonlari;
    public TextMeshProUGUI SopaText;
    [Header("----------SAPKALAR")]
    public GameObject[] Sapkalar;  
    public Button[] SapkaButonlari;
    public TextMeshProUGUI SapkaText;
    [Header("----------MATERIAL")]
    public Material[] Materyaller;
    public Material VarsayilanTema;
    public Button[] MateryalButonlari;
    public TextMeshProUGUI MateryalText;
    public SkinnedMeshRenderer _Renderer;
    [Header("----------GENEL VERİLER")]
    public Animator Kaydedildi_Animator;
    public AudioSource[] Sesler;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] TextObjeler;
    public Text PuanText;
        
    void Start()
    {   
        PuanText.text = _BellekYonetimi.VeriOku_i("Puan").ToString();
        _VeriYonetimi.Load();
        _ItemBilgileri = _VeriYonetimi.ListeyiAktar();
        DurumuKontrolEt(0,true);
        DurumuKontrolEt(1,true);
        DurumuKontrolEt(2,true);        
        foreach (var item in Sesler)
        {
            item.volume = _BellekYonetimi.VeriOku_f("MenuFX");
        }
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[1]);
        DilTercihYonetimi();        
    }

   /* void OpsiyonelDilTercihYonetimi()
    {   
        
        for (int i = 0; i < TextObjeler.Length; i++)
        {
            TextObjeler[i].text = Dili_Yakala()[i].Metin;
        }
        SatinAlmaText = Dili_Yakala()[4].Metin;
        ItemText = Dili_Yakala()[3].Metin;
    }
    
    void Dili_Yakala()
    {
        string dil = _BellekYonetimi.VeriOku_s("Dil");
        if(dil== "TR")
            return _DilVerileriAnaObje[0]._DilVerileri_TR;
        if(dil== "EN")
            return _DilVerileriAnaObje[0]._DilVerileri_EN;
        if(dil== "Mandarin")
            return _DilVerileriAnaObje[0]._DilVerileri_Mandarin;
        if(dil== "Hindi")
            return _DilVerileriAnaObje[0]._DilVerileri_Hindi;
        if(dil== "SP")
            return _DilVerileriAnaObje[0]._DilVerileri_SP;
        if(dil== "FR")
            return _DilVerileriAnaObje[0]._DilVerileri_FR;    
    }*/
    
    void DilTercihYonetimi()
    {
        string dil = _BellekYonetimi.VeriOku_s("Dil");
        if(dil == "TR")
        {           
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin;
            }
            SatinAlmaText = _DilVerileriAnaObje[0]._DilVerileri_TR[4].Metin;
            ItemText = _DilVerileriAnaObje[0]._DilVerileri_TR[3].Metin;

        }
        else if(dil == "EN")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin;
            }
            SatinAlmaText = _DilVerileriAnaObje[0]._DilVerileri_EN[4].Metin;
            ItemText = _DilVerileriAnaObje[0]._DilVerileri_EN[3].Metin;
        }
        else if(dil == "RS")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_RS[i].Metin;
            }
            SatinAlmaText = _DilVerileriAnaObje[0]._DilVerileri_RS[4].Metin;
            ItemText = _DilVerileriAnaObje[0]._DilVerileri_RS[3].Metin;
        }else if(dil == "SP")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_SP[i].Metin;
            }
            SatinAlmaText =_DilVerileriAnaObje[0]._DilVerileri_SP[4].Metin; 
            ItemText = _DilVerileriAnaObje[0]._DilVerileri_SP[3].Metin;
        }else if(dil == "FR")
        {
            for (int i = 0; i < TextObjeler.Length; i++)
            {
                TextObjeler[i].text = _DilVerileriAnaObje[0]._DilVerileri_FR[i].Metin;
            }
            SatinAlmaText =_DilVerileriAnaObje[0]._DilVerileri_FR[4].Metin;
            ItemText = _DilVerileriAnaObje[0]._DilVerileri_FR[3].Metin;
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

    void DurumuKontrolEt(int Bolum,bool islem=false)
    {
        if(Bolum ==0)
        {
            #region 
            if(_BellekYonetimi.VeriOku_i("AktifSapka") == -1)
            {
                foreach (var item in Sapkalar)
                {
                    item.SetActive(false);
                }
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = false;
                if(!islem)
                {
                    SapkaIndex = -1;
                    SapkaText.text = ItemText;
                }                
            }
            else
            {
                foreach (var item in Sapkalar)
                {
                    item.SetActive(false);
                }
                
                SapkaIndex = _BellekYonetimi.VeriOku_i("AktifSapka");
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text =_ItemBilgileri[SapkaIndex].Item_Ad;
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = true;
            }
            #endregion
        }
        else if(Bolum ==1)
        {
                #region 
            if(_BellekYonetimi.VeriOku_i("AktifSopa") == -1)
            {
                foreach (var item in Sopalar)
                {
                    item.SetActive(false);
                }
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = false;
                if(!islem)
                {
                    SopaIndex = -1;
                    SopaText.text = ItemText;
                }               
            }else
            {
                foreach (var item in Sopalar)
                {
                    item.SetActive(false);
                }
                SopaIndex = _BellekYonetimi.VeriOku_i("AktifSopa");
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = true;
            }
            #endregion            
        }
       
        else if(Bolum == 2)
        {
            if(_BellekYonetimi.VeriOku_i("AktifTema") == -1)
            {
                
                if(!islem)
                {
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = false;
                    MateryalIndex = -1;
                    MateryalText.text = ItemText;
                }
                else
                {
                    TextObjeler[4].text = SatinAlmaText;
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayilanTema;
                    _Renderer.materials = mats;
                }
                
                

            }else
            {
                MateryalIndex = _BellekYonetimi.VeriOku_i("AktifTema");
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;
                TextObjeler[4].text = SatinAlmaText;
                MateryalText.text = _ItemBilgileri[MateryalIndex +7 ].Item_Ad;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = true;
            }
        }
    }
     
    public void SatinAl()
    {
        Sesler[1].Play();
        if(AktifIslemPaneliIndex !=-1)
        {
            switch(AktifIslemPaneliIndex)
            {
                case 0:
                 SatinAlmaSonuc(SapkaIndex);                
                    break;                
                case 1:
                 int Index = SopaIndex +3;
                 SatinAlmaSonuc(Index);                 
                    break;                
                case 2:
                int Index2 = MateryalIndex + 7;
                SatinAlmaSonuc(Index2);
                    break; 
            }
        }       
    }

    public void Kaydet()
    {
        Sesler[2].Play();
        if(AktifIslemPaneliIndex != -1)
        {
            switch(AktifIslemPaneliIndex)
            {
                case 0:
                    KaydetmeSonuc("AktifSapka",SapkaIndex);
                    break;                
                case 1:
                    KaydetmeSonuc("AktifSopa",SopaIndex);
                    break;               
                case 2:
                    KaydetmeSonuc("AktifTema",MateryalIndex);
                    break;
            }
        }
    }

    public void Sapka_Yonbutonlari(string islem)
    {
        Sesler[0].Play();
        if(islem=="ileri")
        {
            if(SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                if(!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    TextObjeler[4].text = _ItemBilgileri[SapkaIndex].Puan + "-"+SatinAlmaText;
                    islemButonlari[1].interactable = false;                    
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SapkaIndex].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;

                }else
                {
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                if(!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    TextObjeler[4].text = _ItemBilgileri[SapkaIndex].Puan + "-"+SatinAlmaText;
                    islemButonlari[1].interactable = false;                    
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SapkaIndex].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }else
                {
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }
            

            if(SapkaIndex == Sapkalar.Length -1)
                SapkaButonlari[1].interactable = false;
            else
                SapkaButonlari[1].interactable = true;
            
            if(SapkaIndex != -1)
                SapkaButonlari[0].interactable= true;



        }else
        {
            if(SapkaIndex != -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;
                if(SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaButonlari[0].interactable = true;
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                    if(!_ItemBilgileri[SapkaIndex].SatinAlmaDurumu)
                    {
                        TextObjeler[4].text = _ItemBilgileri[SapkaIndex].Puan + "-"+SatinAlmaText;
                        islemButonlari[1].interactable = false;                    
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SapkaIndex].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                    }else
                    {
                        TextObjeler[4].text = SatinAlmaText;
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                    SapkaText.text = ItemText;
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                }
            }
            else
            {
                SapkaButonlari[0].interactable = false;    
                SapkaText.text = ItemText;
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
            }

            if(SapkaIndex != Sapkalar.Length -1)
                SapkaButonlari[1].interactable = true;
        
        
        }
    }
    
    public void Sopa_Yonbutonlari(string islem)
    {
        Sesler[0].Play();
        if(islem=="ileri")
        {
            if(SopaIndex == -1)
            {
                SopaIndex = 0;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                if(!_ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    TextObjeler[4].text = _ItemBilgileri[SopaIndex + 3].Puan + "-"+SatinAlmaText;
                    islemButonlari[1].interactable = false;
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SopaIndex + 3].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }else
                {
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }

            }else
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex++;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                if(!_ItemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    TextObjeler[4].text = _ItemBilgileri[SopaIndex + 3].Puan + "-"+SatinAlmaText;
                    islemButonlari[1].interactable = false;
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SopaIndex + 3].Puan)
                        islemButonlari[0].interactable = false;
                    else
                        islemButonlari[0].interactable = true;
                }else
                {
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }

            if(SopaIndex == Sopalar.Length -1)
                SopaButonlari[1].interactable = false;
            else
                SopaButonlari[1].interactable = true;
            
            if(SopaIndex != -1)
                SopaButonlari[0].interactable= true;



        }else
        {
            if(SopaIndex != -1)
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex--;
                if(SopaIndex != -1)
                {
                Sopalar[SopaIndex].SetActive(true);
                SopaButonlari[0].interactable = true;
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                if(!_ItemBilgileri[SopaIndex + 3 ].SatinAlmaDurumu)
                    {
                        TextObjeler[4].text = _ItemBilgileri[SopaIndex + 3].Puan + "-"+SatinAlmaText;
                        islemButonlari[1].interactable = false;
                    if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[SopaIndex + 3].Puan)
                            islemButonlari[0].interactable = false;
                    else
                            islemButonlari[0].interactable = true;
                    }else
                    {
                        TextObjeler[4].text = SatinAlmaText;
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SopaButonlari[0].interactable = false;
                    SopaText.text = ItemText;
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;
                    islemButonlari[1].interactable = true;
                }
            }
            else
            {
                SopaButonlari[0].interactable = false;    
                SopaText.text = ItemText;
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
                islemButonlari[1].interactable = true;
            }

            if(SopaIndex != Sopalar.Length -1)
                SopaButonlari[1].interactable = true;
        
        
        }
    }

    public void Materyal_Yonbutonlari(string islem)
    {
        Sesler[0].Play();
        if(islem=="ileri")
        {
            if(MateryalIndex == -1)
            {
                MateryalIndex = 0;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;          
                MateryalText.text = _ItemBilgileri[MateryalIndex + 7].Item_Ad;

                if(!_ItemBilgileri[MateryalIndex + 7 ].SatinAlmaDurumu)
                    {
                        TextObjeler[4].text = _ItemBilgileri[MateryalIndex + 7 ].Puan + "-"+SatinAlmaText;
                        islemButonlari[1].interactable = false;
                        if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[MateryalIndex + 7].Puan)
                        islemButonlari[0].interactable = false;
                        else
                        islemButonlari[0].interactable = true;
                    }else
                    {
                        TextObjeler[4].text = SatinAlmaText;
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }

            }else
            {
                
                MateryalIndex++;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;
                MateryalText.text = _ItemBilgileri[MateryalIndex + 7].Item_Ad;

                if(!_ItemBilgileri[MateryalIndex + 7 ].SatinAlmaDurumu)
                    {
                        TextObjeler[4].text = _ItemBilgileri[MateryalIndex + 7 ].Puan + "-"+SatinAlmaText;
                        islemButonlari[1].interactable = false;
                        if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[MateryalIndex + 7].Puan)
                        islemButonlari[0].interactable = false;
                        else
                        islemButonlari[0].interactable = true;
                    }else
                    {
                        TextObjeler[4].text = SatinAlmaText;
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }
            }

            if(MateryalIndex == Materyaller.Length -1)
                MateryalButonlari[1].interactable = false;
            else
                MateryalButonlari[1].interactable = true;
            
            if(MateryalIndex != -1)
                MateryalButonlari[0].interactable= true;



        }else
        {
            if(MateryalIndex != -1)
            {
                
                MateryalIndex--;
                if(MateryalIndex != -1)
                {
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;
                MateryalButonlari[0].interactable = true;
                MateryalText.text = _ItemBilgileri[MateryalIndex + 7].Item_Ad;

                if(!_ItemBilgileri[MateryalIndex + 7 ].SatinAlmaDurumu)
                    {
                        TextObjeler[4].text = _ItemBilgileri[MateryalIndex + 7 ].Puan + "-"+SatinAlmaText;
                        islemButonlari[1].interactable = false;
                        if(_BellekYonetimi.VeriOku_i("Puan")<_ItemBilgileri[MateryalIndex + 7].Puan)
                        islemButonlari[0].interactable = false;
                        else
                        islemButonlari[0].interactable = true;
                    }else
                    {
                        TextObjeler[4].text = SatinAlmaText;
                        islemButonlari[0].interactable = false;
                        islemButonlari[1].interactable = true;
                    }

                }
                else
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayilanTema;
                    _Renderer.materials = mats;
                    MateryalButonlari[0].interactable = false;
                    MateryalText.text = ItemText;
                    TextObjeler[4].text = SatinAlmaText;
                    islemButonlari[0].interactable = false;

                    

                }
            }
            else
            {
                Material[] mats = _Renderer.materials;
                mats[0] = VarsayilanTema;
                _Renderer.materials = mats;
                
                MateryalButonlari[0].interactable = false;    
                MateryalText.text = ItemText;
                TextObjeler[4].text = SatinAlmaText;
                islemButonlari[0].interactable = false;
            }

            if(MateryalIndex != Materyaller.Length -1)
                MateryalButonlari[1].interactable = true;
        
        
        }
    }
    
    public void islemPaneliCikart(int Index)
    {
        Sesler[0].Play();
        DurumuKontrolEt(Index);
        GenelPaneller[0].SetActive(true);
        AktifIslemPaneliIndex = Index;
        islemPanelleri[Index].SetActive(true);
        GenelPaneller[1].SetActive(true);
        islemCanvasi.SetActive(false);
        
    }
    public void GeriDon()
    {
        Sesler[0].Play();
        GenelPaneller[0].SetActive(false);
        islemCanvasi.SetActive(true);
        GenelPaneller[1].SetActive(false);
        islemPanelleri[AktifIslemPaneliIndex].SetActive(false);
        DurumuKontrolEt(AktifIslemPaneliIndex,true);
        AktifIslemPaneliIndex = -1;
        
    }

    public void AnaMenuyeDon()
    {
        Sesler[0].Play();
        _VeriYonetimi.Save(_ItemBilgileri);
        SceneManager.LoadScene(0);
    }

    //---------------------------------------------
    void SatinAlmaSonuc(int Index)
     {
            _ItemBilgileri[Index].SatinAlmaDurumu = true;
            TextObjeler[4].text = SatinAlmaText;
            islemButonlari[0].interactable = false;
            islemButonlari[1].interactable=true;
            _BellekYonetimi.VeriKaydet_int("Puan",_BellekYonetimi.VeriOku_i( "Puan") - _ItemBilgileri[Index].Puan);
            PuanText.text =_BellekYonetimi.VeriOku_i("Puan").ToString();       

     }
    
    void KaydetmeSonuc(string key,int Index)
    {
        _BellekYonetimi.VeriKaydet_int(key, Index);
        islemButonlari[1].interactable = false;
        if(!Kaydedildi_Animator.GetBool("ok"))
        Kaydedildi_Animator.SetBool("ok",true);

    }
}


