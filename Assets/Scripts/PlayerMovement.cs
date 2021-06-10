using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    [Header("Speed Settings")]
    public float movementSpeed;
    public float controlSpeed;
    public float turningRate = 30f; 
    private Quaternion _targetRotation = Quaternion.identity;
    public bool getReadyToStart;

    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;

    //Animation
    //public Animator animator;
    
    //Not sure about this// Getting playerstate from gamemanager
    public GameManager.PlayerState playerState;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        //Make sure its in sync
        playerState =  GameManager.inst.playerState ;

        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            GetInput();
            GetComponent<ObstacleRotator>().enabled = false;
            
            var rotationVectorCar = transform.rotation.eulerAngles;
            rotationVectorCar= Vector3.zero;
            transform.rotation = Quaternion.Euler(rotationVectorCar);

            //Makes camera rotation 0 for gameplay after menu view
            var rotationVector = Camera.main.transform.rotation.eulerAngles;
            //rotationVector.y = 0;
            rotationVector.x = 0f;
            rotationVector.y = 10.7f;
            rotationVector.z = -17f;
            
            Camera.main.GetComponent<NewCameraFollow>().offset = rotationVector;
            //Camera.main.transform.rotation = Quaternion.Euler(rotationVector);
            
            //Camera.main.GetComponent<CameraFollow>().enabled = true; 5 ve -8.5 y z

        }
    }

    private void FixedUpdate()
    {
        //Start game if in Playing State
        if (playerState == GameManager.PlayerState.Playing)
        {
            //RigidBody Eklentisinden sonra burası rigidbody olarak değişecek
            //m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += m_Rigidbody.AddForce(transform.forward * movementSpeed);
            //transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            m_Rigidbody.velocity = Vector3.forward * movementSpeed;
            //animator.SetTrigger("GameStart"); // start the animation
            //m_Rigidbody.AddForce(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
            if (isTouching)
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                //transform.rotation = Q;
                
                

            }
            
            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);


        }

        if (getReadyToStart)
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

        }
        
    }

    public void SetBlendedEulerAngles()
    {
        _targetRotation = Quaternion.Euler(Vector3.zero);
        getReadyToStart = true;

    }
    
    
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
