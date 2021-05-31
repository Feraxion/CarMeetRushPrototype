using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject changedSphere; // after finishLine our character will be sphere
    public GameObject playerMesh;
    public bool isSphere;
    public float diamondPickUpScaleRate;
    
    public float sphereFinishSize;
    public float sphereScaleDownSpeed;

    [Header("End Game Particle")]
    [SerializeField] public GameObject endGameParticle;
    [SerializeField] public GameObject nextLevelScreen;

    private void Start()
    {
    }
    private void Update()
    {

        
        
        if (isSphere)
        {
            //Rotates to give feeling
            changedSphere.transform.Rotate(4,0,0);
            
            //If its smaller than desired size
            if (gameObject.transform.localScale.x <= sphereFinishSize)
            {
                GameManager.inst.playerState = GameManager.PlayerState.Finish;
                foreach (Transform child in endGameParticle.transform)
                {
                    child.GetComponent<ParticleSystem>().Play();
                }
            }
            else 
            {
                //Else it keeps shrinking
                gameObject.transform.localScale -= Vector3.one * sphereScaleDownSpeed;
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            MakeSphere();
            Debug.Log("Character changed");
            //GameManager.inst.playerState = GameManager.PlayerState.Finish;
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
        
        // when player gets pixels our character will scale
        if(col.gameObject.tag == "Pixel")
        {
            gameObject.transform.localScale += Vector3.one * diamondPickUpScaleRate;
            Destroy(col.gameObject);
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
    void MakeSphere()
    {
        //Disables the body mesh and collider
        playerMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        
        //Activates the sphere mesh and collider
        changedSphere.GetComponent<SphereCollider>().enabled = true;
        changedSphere.GetComponent<MeshRenderer>().enabled = true;
        isSphere = true;

    }

    void NextLevel()
    {
        nextLevelScreen.SetActive(true);
        Destroy(this.gameObject);
    }
}
