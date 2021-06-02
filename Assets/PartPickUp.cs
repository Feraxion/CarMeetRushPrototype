﻿using System;
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

    public GameObject currentBumpers;
    public GameObject currentTires;
    public GameObject currentTires2;
    public GameObject currentTires3;
    public GameObject currentTires4;


    public bool exhaustUpgradedOnce;

    //public GameObject repair;
    public ParticleSystem carSmokeLevel0;
    public ParticleSystem carSmokeLevel1;
    public ParticleSystem carSmokeLevel2;

    
    
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
            
            
                // 0 - boya // 1- spoiler ve ust body //2-tampon ve jant //3- repair // 4- motor // 5- turbo// 6- deccccccal 
                switch (other.gameObject.GetComponent<PartInfo>().partID)
                {
                    
                
                case 5:
                    if (exhaustUpgradedOnce)
                    {
                        carSmokeLevel1.gameObject.SetActive(false);
                        carSmokeLevel2.gameObject.SetActive(true);
                        Destroy(other.gameObject);

                    }
                    else
                    {
                        carSmokeLevel0.gameObject.SetActive(false);
                        carSmokeLevel1.gameObject.SetActive(true);
                        Destroy(other.gameObject);


                    }

                    carBody.GetComponent<PlayerMovement>().movementSpeed += 2;
                    break;
                case 4:
                    if (exhaustUpgradedOnce)
                    {
                        carSmokeLevel1.gameObject.SetActive(false);
                        carSmokeLevel2.gameObject.SetActive(true);
                        Destroy(other.gameObject);

                    }
                    else
                    {
                        carSmokeLevel0.gameObject.SetActive(false);
                        carSmokeLevel1.gameObject.SetActive(true);
                        Destroy(other.gameObject);

                    }
                    carBody.GetComponent<PlayerMovement>().movementSpeed += 2;

                    break;
                case 3:
                    
                    break;
                case 2:
                    currentBumpers.gameObject.SetActive(true);
                    currentTires.gameObject.SetActive(true);
                    currentTires2.gameObject.SetActive(true);
                    currentTires3.gameObject.SetActive(true);
                    currentTires4.gameObject.SetActive(true);
                    
                    Destroy(other.gameObject);
                    break;
                case 1:
                    currentSpoiler.gameObject.SetActive(true);
                    currentRoofParts.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                    break;
                default:
                    print ("Incorrect intelligence level.");
                    break;
                }
            
            
        }
    }
}
