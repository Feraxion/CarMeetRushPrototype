using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [Header("Diamond Components")]
    [SerializeField] public float turnSpeed = 90f; 
    
    private void OnTriggerEnter(Collider col)
    {
        // check that the object we collided with is the player
        if (col.gameObject.tag != "Player")
        {
            return;
        }

        // Add to the player's diamond 
        GameManager.inst.IncrementDiamond();

        //Destroy the diamond object
        Destroy(gameObject);
    }

     void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
