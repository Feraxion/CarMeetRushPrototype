using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    private Transform GO;

    [SerializeField]
    private int RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //GO = gameObject.transform;
        //GO.transform.rotation.x  += 5f;
        
        gameObject.transform.Rotate(RotateSpeed,0f,0f);
    }
}
