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
     
public class SimpleCarController : MonoBehaviour {
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        //m_verticalInput = Input.GetAxis("Vertical");
        
        
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput ;
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
