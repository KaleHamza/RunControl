using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BosKarakter : MonoBehaviour
{   
    public GameManager _GameManager;
    public NavMeshAgent _Navmesh;
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakOlanMateryal;
    public Animator _Animator;
    public GameObject Target;
    bool Temasvar;
    
    private void LateUpdate()
    {   
        if(Temasvar)
            _Navmesh.SetDestination(Target.transform.position); 
    }

    void AnimasyonDegistirVeAnimasyonTetikle()
    {       
        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakOlanMateryal;
        _Renderer.materials = mats;        
        _Animator.SetBool("Saldir",true);        
        gameObject.tag = "AltKarakterler";
        GameManager.AnlikKarakterSayisi++ ;
    }

    Vector3 PozisyonVer()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("BosKarakter"))
            {
                AnimasyonDegistirVeAnimasyonTetikle();
                Temasvar = true;
                GetComponent<AudioSource>().Play();
            }
        }
        else if(other.CompareTag("igneliKutu"))
        {            
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(),false,false);
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Testere"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(),false,false);
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("PervaneIgneler"))
        {  
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(),false,false);
            gameObject.SetActive(false);
        }

        else if(other.CompareTag("Balyoz"))
        {          
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(),true,false);
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Dusman"))
        {
            _GameManager.YokOlmaEfektiOlustur(PozisyonVer(),false,false);
            gameObject.SetActive(false);
        }
    }
}
