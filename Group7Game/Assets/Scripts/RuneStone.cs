using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : MonoBehaviour {
    private Vector3 origonalLocation; //Used to store the origonal location of the rune stone for teleportation
    private bool playerCollision = false; //used to prevent the rigidbody from being destroyed if the player is dragging it
    private bool isTouchingStone = false; //used to prevent bugs where collisions break the joint
    public bool isInteractable = true;//Used to check if the runestone is in the rune stone slot
    public Rigidbody2D rb;//Rigidbody is dynamically created under certain conditions
    public DistanceJoint2D distanceJoint; //Distance joint to be added to the player when dragging
    public int identifier = 0; //identifier used to check if the rune stone is associated with the rune stone slot

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
        //destroys the rigidbody when colliding with the ground, but only if the player isnt touching the collider
        if(collision.gameObject.tag == "Ground")
        {
            if(playerCollision == false)
            {
              Destroy(rb);
            }
        }
        //ensures the rune stone does not break the joint when colliding with another rune stone
        if (collision.gameObject.tag == "RuneStone")
        {
            isTouchingStone = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if the rune stone identifier matches the rune stone slots identifier, the rune stone will fit into the rune stone slot, otherwise it will be teleported back to its origonal location, 
        also sets the activate variable to true once the right runestone has collided.
        */
        if (collision.gameObject.tag == "RuneStoneSlot")
        {
            Destroy(distanceJoint);
            Destroy(rb);
            GameObject.Find("Character").GetComponent<PlayerController>().isMovingStone = false;
            if (collision.gameObject.GetComponent<RuneStoneSlot>().identifier == identifier)
            {
                isInteractable = false;
                transform.position = collision.gameObject.transform.position + new Vector3(0,0.4f,0);
                collision.gameObject.GetComponent<RuneStoneSlot>().activate = true;
            }
            else
            {
                transform.position = origonalLocation;

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        //stops the joint from being destroyed if the player
        if (collision.gameObject.tag == "Player")
        {
            playerCollision = false;
        }

        //makes the stone fall when pushed off a ledge and prevents the joint from breaking if you collide with another stone
        if(collision.gameObject.tag == "Ground" && isTouchingStone == false)
        {
            Destroy(distanceJoint);
        }
        //makes it possible for the rune stone to break the joint after falling off edge, should the player touch the rune stone with another rune stone
        if (collision.gameObject.tag == "RuneStone")
        {
            isTouchingStone = false;
        }

        
    }
}
