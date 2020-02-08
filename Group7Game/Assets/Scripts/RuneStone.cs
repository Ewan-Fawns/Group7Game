using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : DraggedObject {
    private Vector3 origonalLocation; //Used to store the origonal location of the rune stone for teleportation
    public int identifier = 0; //identifier used to check if the rune stone is associated with the rune stone slot
    public int checkPoint = 0; //used to identify which checkpoint is associated with this runestone

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
        //limits the movement of the rune stone
        if(rb != null)
        {
            if (rb.velocity.x > 1)
            {
                rb.velocity = new Vector3(1f, rb.velocity.y, 0);
            }
            else if (rb.velocity.x < -1)
            {
                rb.velocity = new Vector3(-1f, rb.velocity.y, 0);
            }
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
                transform.position = collision.gameObject.transform.position + new Vector3(0,0.4f,0);
                collision.gameObject.GetComponent<RuneStoneSlot>().activate = true;
            }
            else
            {
                transform.position = origonalLocation;
            }
        }
    }

    public Vector3 getOrigonalPosition()
    {
        return origonalLocation;
    }
}
