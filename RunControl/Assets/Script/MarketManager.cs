using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Hamza;
public class MarketManager : MonoBehaviour
{
    public AudioSource ButonSes;
    [Header("---------DİL VERİLERİ")]
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();//Dil verilerini okur
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();//İlgili olanı alır
    public TextMeshProUGUI TextObjesi;//
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    BellekYonetimi _Bellekyonetim = new BellekYonetimi();

     void Start()
    {
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[3]);
        DilTercihYonetimi();
    }

    void DilTercihYonetimi()
    {
        string dil = _Bellekyonetim.VeriOku_s("Dil");

        if(dil == "TR")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_TR[0].Metin;

        }else if(dil == "EN")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_EN[0].Metin;

        }else if(dil == "RS")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_RS[0].Metin;

        }else if(dil == "SP")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_SP[0].Metin;

        }else if(dil == "FR")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_FR[0].Metin;
        }
        else if(dil == "AR")
        {
           
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_AR[0].Metin;
           
        }
        else
            Debug.Log("Something wrong.");
    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }
}
