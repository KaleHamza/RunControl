using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusenAgacEngel : MonoBehaviour
{
    //Ozerk bi Engeldir.
    public Animator _DusenAgacAnimasyon;
    public GameObject Agac;
    public bool Sinir;
    private void OnTriggerEnter(Collider other)
    {
        if(Sinir)
        {
            if(other.CompareTag("Player"))
            {
            _DusenAgacAnimasyon.Play("Agac");
            
            }   
        }        
    }
    void AgacDustu()
    {
        Agac.tag = "Untagged";
    }
    
}
