using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
     
public class SimpleCarController : MonoBehaviour
{

    public bool isTouching;
    
    public void GetInput()
    {
        //m_horizontalInput = Input.GetAxis("Horizontal");
        
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
        
        if (isTouching)
        {
            m_horizontalInput += Input.GetAxis("Mouse X")  * Time.fixedDeltaTime;
            //transform.rotation = Q;



            // carController.m_horizontalInput = Input.GetAxis("Mouse X")* controlSpeed * Time.fixedDeltaTime;




        }
        else
        {
            if (m_horizontalInput > 0)
            {
                m_horizontalInput -= 0.1f;
            }
            
            if (m_horizontalInput < 0)
            {
                m_horizontalInput += 0.1f;
                
            }
        }
        
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput ;
        m_steeringAngle = Mathf.Clamp(m_steeringAngle, -60, 60);
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
        carRotation = carBody.transform.rotation;
        carRotation.y = m_steeringAngle * 0.1f;
        carRotation.y = Mathf.Clamp(carRotation.y, -6, 6);
        carBody.transform.rotation = Quaternion.Euler(0,carRotation.y,0);
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque = movSpeed * motorForce;
        frontPassengerW.motorTorque = movSpeed * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        if (GameManager.inst.playerState == GameManager.PlayerState.Playing)
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
        
    }

    public float m_horizontalInput;
    public float movSpeed;
    public float m_steeringAngle;
    public GameObject carBody;
    public Quaternion carRotation;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;
}
