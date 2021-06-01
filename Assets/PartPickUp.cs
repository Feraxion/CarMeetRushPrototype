using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PartPickUp : MonoBehaviour
{

    public GameObject carBody;
    public GameObject currentSpoiler;
    public GameObject currentRoofParts;
    public GameObject currentDeccal;
    public GameObject currentEngine;
    public GameObject repair;
    public ParticleSystem carSmoke;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Part"))
        {
            
            if (other.gameObject.GetComponent<PartInfo>().partID == 1)
            {
                currentSpoiler.gameObject.SetActive(true);
                Destroy(other.gameObject);
            }
            
        }
    }
}
