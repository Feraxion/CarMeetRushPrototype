using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject playerMesh;
    public float diamondPickUpScaleRate;
    public Animator anim;
    public PlayerMovement pMov;

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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            pMov.enabled = false;
        //GameManager.inst.playerState = GameManager.PlayerState.Finish;
        //gameObject.GetComponent<Animator>().enabled = true;
        anim.SetTrigger("CarDrift");

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
}
