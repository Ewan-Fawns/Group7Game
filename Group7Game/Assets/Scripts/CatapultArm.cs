using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultArm : MonoBehaviour {
    JointMotor2D MotorRef;
    private bool hasLaunched = false;
    private float resetTime = 0;
	// Use this for initialization
	void Start () {
        MotorRef = GetComponent<HingeJoint2D>().motor;
	}
	
	// Update is called once per frame
	void Update () {
		if(hasLaunched == true)
        {
            resetTime += Time.deltaTime;
            if(resetTime >= 1.5)
            {
                ResetArm();
                resetTime = 0;
                
            }
        }
	}

    public void RotateArm()
    {
        MotorRef.motorSpeed = 400;
        GetComponent<HingeJoint2D>().motor = MotorRef;
        hasLaunched = true;
    }

    private void ResetArm()
    {
        MotorRef.motorSpeed = -50;
        GetComponent<HingeJoint2D>().motor = MotorRef;
        hasLaunched = false;
    }


}
