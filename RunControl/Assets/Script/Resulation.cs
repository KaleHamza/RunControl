using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width/2,Screen.currentResolution.height/2,true);   
    }

}
