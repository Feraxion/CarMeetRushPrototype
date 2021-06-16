using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject playerMesh;
    public float diamondPickUpScaleRate;
    public Animator anim;
    public PlayerMovement pMov;
    public Camera finishCam;

    [Header("End Game Particle")]
    [SerializeField] public GameObject endGameParticle;
    [SerializeField] public GameObject nextLevelScreen;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //gameObject.GetComponent<Animator>().enabled = false;
        pMov = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
    }
    
 
   


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            pMov.enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //gameObject.transform.rotation = Vector3.zero;
        //GameManager.inst.playerState = GameManager.PlayerState.Finish;
        //gameObject.GetComponent<Animator>().enabled = true;
           // anim.applyRootMotion = false;
            //anim.SetBool("Drift", true);
            anim.SetTrigger("Drifter");
            
            StartCoroutine(ExampleCoroutine());

            //3 saniyelik coroutine

            //anim.Play("CarAnim");
            
        } 

        if (col.gameObject.tag == "2xZone")
        {
            GameManager.inst.bonusMultiplier = 2;
        }
        
        
        if (col.gameObject.tag == "3xZone")
        {
            GameManager.inst.bonusMultiplier = 3;
        }
        
        
        if (col.gameObject.tag == "4xZone")
        {
            GameManager.inst.bonusMultiplier = 4;
        }       
        if (col.gameObject.tag == "Obstacle")
        {

            
            
                Destroy(gameObject);
                GameManager.inst.playerState = GameManager.PlayerState.Died;
                
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            Destroy(gameObject);
            GameManager.inst.playerState = GameManager.PlayerState.Died;
                
        }    }

    void NextLevel()
    {
        nextLevelScreen.SetActive(true);
        Destroy(this.gameObject);
    }

    IEnumerator ExampleCoroutine()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        Camera.main.enabled = false;
        finishCam.gameObject.SetActive(true);
        endGameParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        GameManager.inst.FinishScreen.SetActive(true);


    }
}
