using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PartPickUp : MonoBehaviour
{

    public GameObject currentBrokenBody;
    public GameObject upgradedBody;
    public GameObject currentSpoiler;
    public GameObject currentDeccal;
    public GameObject upgradedDeccal;
    public GameObject currentBrokenFront;
    public GameObject currentRepairedFront;

    public GameObject repair;
    public ParticleSystem carSmoke;

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
                    case 6:
                        currentDeccal.gameObject.SetActive(false);
                        upgradedDeccal.gameObject.SetActive(true);
                        Destroy(other.gameObject);

                        GetComponent<PlayerMovement>().movementSpeed += 0.2f;
                        break;
                    
                
                case 5:
                    if (exhaustUpgradedOnce)
                    {
                        carSmokeLevel1.gameObject.SetActive(false);
                        carSmokeLevel2.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        GetComponent<PlayerMovement>().movementSpeed += 3;

                    }
                    else
                    {
                        carSmokeLevel0.gameObject.SetActive(false);
                        carSmokeLevel1.gameObject.SetActive(true);
                        Destroy(other.gameObject);
                        exhaustUpgradedOnce = true;
                        GetComponent<PlayerMovement>().movementSpeed += 0.2f;


                    }

                    break;
                case 4:
                    if (exhaustUpgradedOnce)
                    {
                        carSmokeLevel1.gameObject.SetActive(false);
                        carSmokeLevel2.gameObject.SetActive(true);
                        //repair.gameObject.SetActive(false);

                        Destroy(other.gameObject);
                        
                        GetComponent<PlayerMovement>().movementSpeed += 3;


                    }
                    else
                    {
                        carSmokeLevel0.gameObject.SetActive(false);
                        carSmokeLevel1.gameObject.SetActive(true);
                        //repair.gameObject.SetActive(false);
                        exhaustUpgradedOnce = true;


                        Destroy(other.gameObject);
                        GetComponent<PlayerMovement>().movementSpeed += 0.2f;

                        

                    }

                    break;
                case 3:
                    
                    currentBrokenBody.gameObject.SetActive(false);
                    upgradedBody.gameObject.SetActive(true);
                    currentBrokenFront.gameObject.SetActive(false);
                    currentRepairedFront.gameObject.SetActive(true);
                    repair.gameObject.SetActive(true);
                    carSmoke.gameObject.SetActive(false);
                    Destroy(other.gameObject);

                    GetComponent<PlayerMovement>().movementSpeed += 0.2f;
                    break;
                case 2:
                    currentTires.gameObject.SetActive(true);
                    currentTires2.gameObject.SetActive(true);
                    currentTires3.gameObject.SetActive(true);
                    currentTires4.gameObject.SetActive(true);
                    
                    Destroy(other.gameObject);
                    break;
                case 1:
                    currentSpoiler.gameObject.SetActive(true);
                    Destroy(other.gameObject);
                    break;
                default:
                    print ("Incorrect intelligence level.");
                    break;
                }
            
            
        }
    }
}
