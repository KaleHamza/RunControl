using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSes : MonoBehaviour
{
    private static GameObject instance;//Sistemde dolaştıracağımız için static dedik.
    public AudioSource Ses;
    void Start()
    {
        
        Ses.volume = PlayerPrefs.GetFloat("MenuSes");//tanımlı bi volum ayarı
        DontDestroyOnLoad(gameObject);//Sahne geçişinde objeyi kabetme

        if(instance == null)
            instance = gameObject;//Daha önce oluşturulmadıysa sen oluşturacaksın.
        else
            Destroy(gameObject);//İki kere oluşturulma gibi bi durum olduysa kendini yok et.
    }

    
    void Update()//Olabildiği kadar uzak durulmalı bu metottan,Sistemi yorabilir.
    {
        Ses.volume = PlayerPrefs.GetFloat("MenuSes");
    }
}
