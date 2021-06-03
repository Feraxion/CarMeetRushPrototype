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

            
            if (col.gameObject.GetComponent<ObstacleValue>().ObstacleScale > gameObject.transform.localScale.x)
            {
                Destroy(gameObject);
                GameManager.inst.playerState = GameManager.PlayerState.Died;
            }
            else
            {
                gameObject.transform.localScale /= col.gameObject.GetComponent<ObstacleValue>().ObstacleDamage;
                Destroy(col.gameObject);
            }        
            /*if (col.transform.localScale.x > gameObject.transform.localScale.x)
            {
                Destroy(gameObject);
                GameManager.inst.playerState = GameManager.PlayerState.Died;

                // Add gameover screen
            }
            else
            {
                gameObject.transform.localScale /= 1.5f;
                Destroy(col.gameObject);
                //MAYBE ADD SOME SHATTERED VERSIONS
            }    */        
        }
    }
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

    }
}
