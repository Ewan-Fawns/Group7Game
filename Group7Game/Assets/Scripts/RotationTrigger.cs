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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RotatingPlatform myScript = other.gameObject.GetComponent<RotatingPlatform>();

            myScript.enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RotatingPlatform myScript = other.gameObject.GetComponent<RotatingPlatform>();
            myScript.enabled = false;
        }
    }
}

// THIS SCRIPT DOESN'T WORK YET