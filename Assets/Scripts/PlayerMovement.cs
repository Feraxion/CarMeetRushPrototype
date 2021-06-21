using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public Vector3 lastPos;
    public Quaternion rotateAcceleration;
    [Header("Speed Settings")]
    public float movementSpeed;
    public float controlSpeed;
    public float turningRate = 30f; 
    private Quaternion _targetRotation = Quaternion.identity;
    public bool getReadyToStart;
    public bool cameraSet;
    public GameObject centerOfMass;

    public SimpleCarController carController;
    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;
    public float speedLimit;

    //Animation
    //public Animator animator;
    
    //Not sure about this// Getting playerstate from gamemanager
    public GameManager.PlayerState playerState;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.centerOfMass = centerOfMass.transform.position;
        m_Rigidbody.ResetInertiaTensor();

    }

    private void Update()
    {
        //Make sure its in sync
        playerState =  GameManager.inst.playerState ;

        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            //GetInput();
           // GetComponent<ObstacleRotator>().enabled = false;
            
           // var rotationVectorCar = transform.rotation.eulerAngles;
           //  rotationVectorCar= Vector3.zero;
           //  transform.rotation = Quaternion.Euler(rotationVectorCar);

           
           
            //Makes camera rotation 0 for gameplay after menu view
            if (!cameraSet)
            {
                var rotationVector = Camera.main.transform.rotation.eulerAngles;
                //rotationVector.y = 0;
                rotationVector.x = 0f;
                rotationVector.y = 10.7f;
                rotationVector.z = -12f;
            
                Camera.main.GetComponent<NewCameraFollow>().offset = rotationVector;
                cameraSet = true;
            }

            lastPos = m_Rigidbody.velocity;

            lastPos.z = Mathf.Clamp(m_Rigidbody.velocity.z, 0, speedLimit);
            Vector3 xPos = transform.position;
            xPos.x = Mathf.Clamp(xPos.x, -25, 13);
            transform.position = xPos;

            m_Rigidbody.velocity = lastPos;

            //Camera.main.transform.rotation = Quaternion.Euler(rotationVector);

            //Camera.main.GetComponent<CameraFollow>().enabled = true; 5 ve -8.5 y z

        }

        if (playerState == GameManager.PlayerState.Finish)
        {
            m_Rigidbody.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (playerState == GameManager.PlayerState.Prepare)
        {
            var rotationVectorCar = transform.rotation.eulerAngles;
            rotationVectorCar= Vector3.zero;
            transform.rotation = Quaternion.Euler(rotationVectorCar);
        }
        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            //RigidBody Eklentisinden sonra burası rigidbody olarak değişecek
            //m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            /////////////m_Rigidbody.velocity = Vector3.forward * movementSpeed;
            //animator.SetTrigger("GameStart"); // start the animation
            //m_Rigidbody.AddForce(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            //if (isTouching)
           // {
                //touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                //transform.rotation = Q;



               // carController.m_horizontalInput = Input.GetAxis("Mouse X")* controlSpeed * Time.fixedDeltaTime;




            //}
            
            //lastPos.x = transform.position.x;

            
            //transform.position = new Vector3(touchPosX, 0, transform.position.z);
            

            /*
            if (lastPos.x > transform.position.x)
            {
                transform.Rotate(0,-1,0,Space.Self);
            }

            if (lastPos.x < transform.position.x)
            {
                transform.Rotate(0,1,0,Space.Self);
            }

            rotateAcceleration = transform.rotation;
            rotateAcceleration.y = Mathf.Clamp(transform.rotation.y, -10, 10);
            transform.rotation = rotateAcceleration;
            
            if (lastPos.x == transform.position.x)
            {
                transform.Rotate(0,-1 * (transform.rotation.y),0,Space.Self);

            }*/
            
        }

        /*if (getReadyToStart)
        {
            GetComponent<ObstacleRotator>().enabled = false;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
            
            Vector3 cameraStartMovement = new Vector3(5f, -1f, 0f);
            
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,cameraStartMovement,2 * Time.deltaTime);
            
            Camera.main.transform.LookAt(m_Rigidbody.gameObject.transform);
            
            if (transform.rotation.y == 0f)
            {
                getReadyToStart = false;
                GameManager.inst.playerState = GameManager.PlayerState.Playing;
                GameManager.inst.StartScreen.SetActive(false);
            }

        }*/
        
    }

    // public void SetBlendedEulerAngles()
    // {
    //     _targetRotation = Quaternion.Euler(Vector3.zero);
    //     getReadyToStart = true;
    //
    // }
    
    
    //Testing Inputs
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    //Mobile Inputs
    void GetInputMobile()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
