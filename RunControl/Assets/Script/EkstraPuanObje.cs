using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkstraPuanObje : MonoBehaviour
{
    public GameManager _GameManager;
    
        private void OnTriggerEnter(Collider other)
        {
            
            if(other.CompareTag("AltKarakterler") || other.CompareTag("BosKarakter") || other.CompareTag("Player") )
            {
                _GameManager.LevelPuan +=_GameManager.LevelEkstraPuanDeger;
                 gameObject.SetActive(false);
            }
            
           
        }  
}
