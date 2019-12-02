using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
     public int points = 0;

     //public ParticleSystem boostEffect;
     private Rigidbody rb;

     public bool breaking =  false;
     public float brakeTorque = 5000f;

    float _speed;
    float _fwSpeed;

    //new
    public float Speed {
        get
        {
            return _speed;
        }
    }
     public float FwSpeed {
        get
        {
            return _fwSpeed;
        }
    }
    //notNew

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
        _fwSpeed = (frontPassengerW.rpm / 5000);
    }
    private void Accelerate()
    {
        // 2WD
        rearDriverW.motorTorque = m_verticalInput * motorForce;
        rearPassengerW.motorTorque = m_verticalInput * motorForce;
        
        // 4WD
        frontPassengerW.motorTorque = m_verticalInput * motorForce;
        frontDriverW.motorTorque = m_verticalInput * motorForce;

        //new
        _speed = (rearPassengerW.rpm / 5000);
        
        //print(rearPassengerW.rpm);
    }

    private void Brake () {
        if (Input.GetButton("Jump"))
        {
            breaking=true;
        } else {
            breaking=false;
        }
        if (breaking == true) {
            rearDriverW.brakeTorque = brakeTorque;
            rearPassengerW.brakeTorque = brakeTorque;
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
        } else {
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

/*
    private void Boost () {
        if (Input.GetButtonDown("HandBrake"))
        {
            boostEffect.Play();
        }
        if (Input.GetButtonUp("HandBrake"))
        {
            boostEffect.Stop();           
        }       
    }
*/
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _colider, Transform _transform){
        Vector3 _pos = transform.position;
        Quaternion _quat = _transform.rotation;
        

        _colider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate(){
        GetInput();
        Steer();
        Accelerate();
        Brake();
        UpdateWheelPoses();
        //Boost();

        if(Input.GetButtonDown("Fire3"))
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 500000);
        }
        

        //nytt
        //float speed = rb.velocity.magnitude;
        //Debug.Log(rb.velocity.magnitude);
    }
    
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 45;
    public float motorForce = 100;

}
