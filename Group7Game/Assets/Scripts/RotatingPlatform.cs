using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {
    public float rotationSpeed;
    public int checkPoint = 0;
    private JointMotor2D motorReference;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        motorReference = GetComponent<HingeJoint2D>().motor;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Rotate()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        motorReference.motorSpeed = 10;
        GetComponent<HingeJoint2D>().motor = motorReference;
    }

    public void StopRotation()
    {
        rb.bodyType = RigidbodyType2D.Static;
        motorReference.motorSpeed = 0;
        GetComponent<HingeJoint2D>().motor = motorReference;
    }
}
