using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {
    public GameObject attachedArm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaunchCatapult()
    {
        attachedArm.GetComponent<CatapultArm>().RotateArm();
    }
}
