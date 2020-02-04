using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public List<GameObject> attached;
    public bool isRotating = false;
    public int checkPoint = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotatePlatforms()
    {
        foreach(GameObject attachedObject in attached)
        {
            attachedObject.GetComponent<RotatingPlatform>().Rotate();
            isRotating = true;
        }
    }

    public void StopRotatePlatforms()
    {
        foreach (GameObject attachedObject in attached)
        {
            attachedObject.GetComponent<RotatingPlatform>().StopRotation();
        }
        isRotating = false;
    }
}
