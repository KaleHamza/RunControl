using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzerkUcanTasAlanSinir : MonoBehaviour
{   
    public GameObject UcanTaslar;
    public Animator _TasAlanAnimasyon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            UcanTaslar.SetActive(true);
           _TasAlanAnimasyon.Play("UcanTasEngeli");
        }   
    }
}
