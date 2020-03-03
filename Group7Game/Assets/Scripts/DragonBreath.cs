using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreath : MonoBehaviour {
    public float speed;
    public float timeInterval;
    private float timePassed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timePassed >= timeInterval)
        {
            transform.position = new Vector3(GameObject.Find("Character").transform.position.x + 30, GameObject.Find("Character").transform.position.y + 18, 0);
            timePassed = 0;
        }
        timePassed += Time.deltaTime;
	}

    private void FixedUpdate()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }
}
