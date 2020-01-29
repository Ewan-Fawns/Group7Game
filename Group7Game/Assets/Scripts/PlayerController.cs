using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 100.0f; //the speed of the player
    public float jumpHeight = 1.0f; // determines how high the player can jump
    private bool isOnGround = false; // used to check if the player is on the ground
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

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
            if(isOnGround == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
                isOnGround = false;
                print("jumped");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}
