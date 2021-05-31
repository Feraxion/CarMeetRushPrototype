using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;

    public float offsetX;
    public float offsetY;

    public float offsetZ;

    public float cameraXrotation;

    public float cameraFov;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

        if (playerTransform == null)
        {
            return;
        }else{Vector3 camPos = transform.position;

            camPos.x = playerTransform.position.x;
            camPos.y = playerTransform.position.y;
            camPos.z = playerTransform.position.z;


            Camera.main.fieldOfView = cameraFov;
            
            transform.localEulerAngles = new Vector3(cameraXrotation,gameObject.transform.eulerAngles.y,gameObject.transform.eulerAngles.z);
            

            camPos.x += offsetX;
            camPos.y += offsetY;
            camPos.z += offsetZ;


            transform.position = camPos;}
    }
}
