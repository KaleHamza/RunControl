using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;
    public static bool Kalite=false;
    void Start()
    {
        target_offset = transform.position - target.position;//Kamera pozisyonundan hedef pozisyonunu cikar.
        if(!Kalite)
        {
            Screen.SetResolution(Screen.currentResolution.width/2,Screen.currentResolution.height/2,true);
            Kalite=true;
        }
           
    }

    private void LateUpdate()
    {
        if(!SonaGeldikmi)
            transform.position = Vector3.Lerp(transform.position,target.position + target_offset,.125f);
        else
            transform.position = Vector3.Lerp(transform.position,GidecegiYer.transform.position,.015f);
    }
}
