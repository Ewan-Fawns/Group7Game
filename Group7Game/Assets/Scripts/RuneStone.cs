using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : MonoBehaviour {
    private Vector3 origonalLocation;
    private bool playerCollision = false;
    public Rigidbody2D rb;
    public DistanceJoint2D distanceJoint;
	// Use this for initialization
	void Start () {
        origonalLocation = transform.position;
        rb = gameObject.AddComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if(playerCollision == false)
            {
                Destroy(rb);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCollision = false;
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(distanceJoint);
        }
    }
}
