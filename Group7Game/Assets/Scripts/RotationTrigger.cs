using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            RotatingPlatform myScript = other.gameObject.GetComponent<RotatingPlatform>();

            myScript.enabled = true;
        }
    }

    void OnTriggerExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            RotatingPlatform myScript = other.gameObject.GetComponent<RotatingPlatform>();
            myScript.enabled = false;
        }
    }
}

// THIS SCRIPT DOESN'T WORK YET