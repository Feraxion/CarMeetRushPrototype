using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartInfo : MonoBehaviour
{
    
    // 0 - boya // 1- spoiler ve ust body //2-tampon ve jant //3- repair // 4- motor // 5- turbo// 6- deccccccal 
    public int partID;
    public ParticleSystem partPickupParticle;
    public bool showedOnce;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Makes sure that it works only once when gameobject activated
        if (gameObject.activeInHierarchy && !showedOnce)
        {
            partPickupParticle.Play();
            showedOnce = true;
        }
    }
}
