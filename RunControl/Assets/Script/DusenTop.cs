using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusenTop : MonoBehaviour
{
    public static bool TopDussun;
    public GameObject Toplar;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            if(!Toplar.activeInHierarchy)
            {
                Toplar.SetActive(true);
            }
            
            if(GameManager.AnlikKarakterSayisi <=0)
            {
                GameManager.AnlikKarakterSayisi = 1;
                Debug.Log("IF ICINDE " + GameManager.AnlikKarakterSayisi);
            }
        }
    }
}
