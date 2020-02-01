using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;//used to move the player
    public float speed = 1.0f; //the speed of the player
    public float jumpHeight = 5f; // determines how high the player can jump
    private bool isOnGround = false; // used to check if the player is on the ground
    public bool isMovingStone = false; // used to check to see if the player is moving a rune stone
    private GameObject interactable = null;//used to check which game object is currently selected for interaction
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Interact();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //used to move the player
    void MovePlayer()
    {
        
        //move left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
        //jump
        if (Input.GetKey(KeyCode.W))
        {
            if(isOnGround == true && isMovingStone == false)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
                isOnGround = false;
            }
        }

        //Used to limit speed
        if (rb.velocity.x > 10.0f)
        {
            rb.velocity = new Vector3(10.0f, rb.velocity.y, 0);
        }
        else if (rb.velocity.x < -10.0f)
        {
            rb.velocity = new Vector3(-10.0f, rb.velocity.y, 0);
        }
       
    }

    void Interact()
    {
        //used for all interactable objects
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //used for bug fixing
            if (interactable == null)
            {
                print("No interactable");
            }

            //Creates a rigidbody and a distance joint on the runestone object for dragging
            if (interactable.tag == "RuneStone")
            {
                //if the player isnt moving a stone, adds the components
                
                if(isMovingStone == false)
                {
                    interactable.GetComponent<RuneStone>().rb = interactable.AddComponent<Rigidbody2D>();
                    interactable.GetComponent<RuneStone>().rb.freezeRotation = true;
                    interactable.GetComponent<RuneStone>().rb.mass = 0.5f;
                    interactable.GetComponent<RuneStone>().rb.gravityScale = 1.5f;
                    interactable.GetComponent<RuneStone>().distanceJoint = interactable.AddComponent<DistanceJoint2D>();
                    interactable.GetComponent<RuneStone>().distanceJoint.connectedBody = rb;
                    isMovingStone = true;
                }
                //if the player is moving a stone, destroys the components
                else
                {
                    Destroy(interactable.GetComponent<RuneStone>().distanceJoint);
                    Destroy(interactable.GetComponent<RuneStone>().rb);
                    isMovingStone = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enables the player to jump again when touching the ground
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        //enables the player to jump and makes the runestone the active interactable object
        if (collision.gameObject.tag == "RuneStone")
        {
            isOnGround = true;
            interactable = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //interactable is removed thereby stopping functionality when not touching
        if (collision.gameObject.tag == "RuneStone")
        {
            if(interactable.tag == "RuneStone" && isMovingStone == false)
            {
                interactable = null;
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
            if(isMovingStone == true)
            {
                Destroy(interactable.GetComponent<RuneStone>().distanceJoint);
                Destroy(interactable.GetComponent<RuneStone>().rb);
                isMovingStone = false;
            }
        }
    }
}
