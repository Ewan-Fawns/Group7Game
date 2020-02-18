using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchable : DraggedObject {
    private HingeJoint2D launchableHinge;
    private bool isFiring = false;
    // Use this for initialization
    void Start () {
        rb = gameObject.AddComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CatapultArm" && collision.GetComponent<CatapultArm>().getLaunchable() == null && isFiring == false)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getIsMovingStone() == true)
            {
                Destroy(distanceJoint);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setIsMovingStone(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setInteractable(null);
            }
            transform.position = collision.transform.position - new Vector3(1, -0.5f, 0);
            AttachLaunchable(collision);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.GetComponent<CatapultArm>().StoreLaunchable(gameObject);
            GetComponent<SpriteRenderer>().sortingOrder = -3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFiring = false;
        limitControl = true;

        //destroys the rigidbody when colliding with the ground, but only if the player isnt touching the collider
        if (collision.gameObject.tag == "Ground")
        {
            if (playerCollision == false && GameObject.Find("Character").GetComponent<PlayerController>().getIsMovingStone() == false)
            {
                Destroy(rb);
            }
        }
        //ensures the rune stone does not break the joint when colliding with another rune stone
        if (collision.gameObject.tag == "RuneStone")
        {
            isTouchingOtherObject = true;
        }
    }

    private void AttachLaunchable(Collider2D arm)
    {
        launchableHinge = gameObject.AddComponent<HingeJoint2D>();
        launchableHinge.connectedBody = arm.GetComponent<Rigidbody2D>();
    }

    public void launch(Vector3 target)
    {
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        limitControl = false;
        Vector3 launchVector;
        launchVector = target - transform.position;
        rb.velocity = launchVector;
    }

    public bool getIsFiring()
    {
        return isFiring;
    }

    public void setIsFiring(bool newIsFiring)
    {
        isFiring = newIsFiring;
    }

    public HingeJoint2D getLaunchableHinge()
    {
        return launchableHinge;
    }

    public void setLaunchableHinge(HingeJoint2D newLaunchableHinge)
    {
        launchableHinge = newLaunchableHinge;
    }
}
