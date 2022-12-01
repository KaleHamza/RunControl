using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public Kamera _Kamera;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;
    public Slider _Slider;   
    public GameObject GecisNoktasi;
    public float ParmakPozisyonX;
    void Start()
    {
        float Fark = Vector3.Distance(transform.position,GecisNoktasi.transform.position);
        _Slider.maxValue = Fark;
    }
    private void FixedUpdate()//Hassas haraketlerde içine yazılabilr.
    {
        if(!SonaGeldikmi)
        transform.Translate(Vector3.forward * 1.65f * Time.deltaTime );    
    }

    void Update()
    {    
        if(Time.timeScale != 0)
        {
            
            if(SonaGeldikmi)
            {
                transform.position = Vector3.Lerp(transform.position,GidecegiYer.transform.position,.01f);
                if(_Slider.value != 0)
                _Slider.value -= .03f;
            }
            else
            {                   
                float Fark = Vector3.Distance(transform.position,GecisNoktasi.transform.position);
                _Slider.value = Fark;                    
               if(Input.touchCount>0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
                    switch(touch.phase)
                    {
                        case TouchPhase.Began:
                        ParmakPozisyonX = TouchPosition.x -  transform.position.x;
                        break;
                        
                        case TouchPhase.Moved: 
                        if(transform.position.x > -1.12 && transform.position.x < 1.16) 
                        {
                            transform.position = Vector3.Lerp( transform.position, new Vector3(TouchPosition.x - ParmakPozisyonX, transform.position.y, transform.position.z),.065f); 
                        }   
                        break;
                    }  
                }  
            }
            
           /* 
            if(SonaGeldikmi)
            {
                transform.position = Vector3.Lerp(transform.position,GidecegiYer.transform.position,.01f);
                if(_Slider.value != 0)
                _Slider.value -= .03f;
            }
            else
            {
                float Fark = Vector3.Distance(transform.position,GecisNoktasi.transform.position);
                _Slider.value = Fark;               
                if(transform.position.x>-1.12 && transform.position.x <1.16) 
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        
                        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x -.1f,transform.position.y,transform.position.z), 5f);
                    }
                    else if(Input.GetKey(KeyCode.RightArrow))
                    {
                        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x +.1f,transform.position.y,transform.position.z), 5f);                    
                    }
                }   
                
                                                
            }*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Carpma") || other.CompareTag("Bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetim(other.tag, sayi , other.transform);             
        }
        else if(other.CompareTag("SonTetikleyici"))
        {
            _Kamera.SonaGeldikmi = true;
            SonaGeldikmi = true;
            _GameManager.DusmanlariTetikle();
            Debug.Log(GameManager.AnlikKarakterSayisi);           
        }
        else if(other.CompareTag("BosKarakter"))
        {
            _GameManager.Karakterler.Add(other.gameObject);            
        }        
        else if(other.CompareTag("EkstraPuanObje"))
        {
            _GameManager.LevelPuan +=20;
            other.gameObject.SetActive(false);
           
        }
        
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("direk") || collision.gameObject.CompareTag("igneliKutu") || collision.gameObject.CompareTag("PervaneIgneler"))
        {   
            if(transform.position.x>0)
                transform.position = new Vector3(transform.position.x - .3f, transform.position.y ,transform.position.z);
            else
                transform.position = new Vector3(transform.position.x + .3f, transform.position.y ,transform.position.z);
        }
    }
}
