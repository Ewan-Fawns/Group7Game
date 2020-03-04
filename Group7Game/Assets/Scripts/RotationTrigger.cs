using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    public List<GameObject> rotatingPlatforms;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject platform in rotatingPlatforms)
            {
                RotatingPlatform myScript = platform.gameObject.GetComponent<RotatingPlatform>();

                myScript.enabled = true;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject platform in rotatingPlatforms)
            {
                RotatingPlatform myScript = platform.gameObject.GetComponent<RotatingPlatform>();
                myScript.enabled = false;
            }
            
        }
    }
}

// THIS SCRIPT DOESN'T WORK YET