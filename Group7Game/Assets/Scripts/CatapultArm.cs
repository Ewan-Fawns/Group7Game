﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultArm : MonoBehaviour {
    JointMotor2D MotorRef;
    public GameObject launchable;
	// Use this for initialization
	void Start () {
        MotorRef = GetComponent<HingeJoint2D>().motor;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void RotateArm()
    {
        MotorRef.motorSpeed = 400;
        GetComponent<HingeJoint2D>().motor = MotorRef;
    }

    public void ResetArm()
    {
        MotorRef.motorSpeed = -50;
        GetComponent<HingeJoint2D>().motor = MotorRef;
    }

    public void StoreLaunchable(GameObject launchableRef)
    {
        launchable = launchableRef;
    }

    public void ReleaseLaunchable(Vector3 target)
    {
        Destroy(launchable.GetComponent<Launchable>().launchableHinge);
        launchable.GetComponent<Launchable>().isFiring = true;
        launchable.GetComponent<CircleCollider2D>().enabled = true;
        launchable.GetComponent<Launchable>().launch(target);
        launchable = null;
    }
}
