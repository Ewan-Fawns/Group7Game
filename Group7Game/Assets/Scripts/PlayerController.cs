using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;//used to move the player
    public float speed = 1.0f; //the speed of the player
    public float jumpHeight = 5f; // determines how high the player can jump
    private bool isMovingStone = false; // used to check to see if the player is moving a rune stone
    private int checkPoint = 0; // used to check which checkpoint the player is at
    private bool isOnLadder = false;
    private bool isOnGround = false; // used to check if the player is on the ground
    private GameObject interactable = null;//used to check which game object is currently selected for interaction
    private bool jump = true;
    public Animator animator;
    private bool walk = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        if (rb.velocity.x != 0)
        {
            animator.SetBool("isWalking", true);

        }
        else animator.SetBool("isWalking", false);

        MovePlayer();
    }


    private void FixedUpdate()
    {

    }

    //used to move the player
    void MovePlayer()
    {
        bool isHoldingA = false;
        bool isHoldingD = false;

        if (isOnLadder == false)
        {
            //move left
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * speed);
                //rb.velocity = new Vector3(-1 * speed, rb.velocity.y, 0) ;
                transform.localScale = new Vector3(-0.3f, 0.3f, 1);
                isHoldingA = true;
            }
            //move right
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * speed);
                //rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0) ;
                transform.localScale = new Vector3(0.3f, 0.3f, 1);
                isHoldingD = true;
            }
            //jump
            if (Input.GetKey(KeyCode.W))
            {
                if (isOnGround == true && isMovingStone == false)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
                    isOnGround = false;
                }
            }
            //Used to limit speed
            if (rb.velocity.x > 5f)
            {
                rb.velocity = new Vector3(5f, rb.velocity.y, 0);
            }
            else if (rb.velocity.x < -5f)
            {
                rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 2.5f, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -2.5f, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.A) && isHoldingD == false && isOnGround == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKeyUp(KeyCode.D) && isHoldingA == false && isOnGround == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
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
            else if (interactable.tag == "RuneStone")
            {
                //if the player isnt moving a stone, adds the components

                if (isMovingStone == false)
                {
                    interactable.GetComponent<DraggedObject>().createDraggingComponents();
                    isMovingStone = true;
                }
                //if the player is moving a stone, destroys the components
                else
                {
                    Destroy(interactable.GetComponent<DraggedObject>().GetDJ());
                    Destroy(interactable.GetComponent<DraggedObject>().GetRB());
                    isMovingStone = false;
                }
            }
            //Creates a rigidbody and a distance joint on the launchable object for dragging
            else if (interactable.tag == "Launchable")
            {
                if (isMovingStone == false)
                {
                    interactable.GetComponent<DraggedObject>().createDraggingComponents();
                    isMovingStone = true;
                }
                //if the player is moving a stone, destroys the components
                else
                {
                    Destroy(interactable.GetComponent<DraggedObject>().GetDJ());
                    Destroy(interactable.GetComponent<DraggedObject>().GetRB());
                    isMovingStone = false;
                }
            }
            //Interaction to climb the ladder
            else if (interactable.tag == "Ladder")
            {
                if (isOnLadder == false)
                {
                    isOnLadder = true;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.gravityScale = 0f;
                    transform.position = new Vector3(interactable.transform.position.x, transform.position.y, 0);
                }
                else
                {
                    isOnLadder = false;
                    rb.gravityScale = 1.5f;
                }
            }
            //Interaction to fire the catapult
            else if (interactable.tag == "Catapult")
            {
                interactable.GetComponent<Catapult>().LaunchCatapult();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            checkPoint = collision.GetComponent<CheckPoint>().checkPointNum;
        }

        if (collision.gameObject.tag == "Ladder" && isMovingStone == false)
        {
            interactable = collision.gameObject;
        }

        if (collision.gameObject.tag == "Catapult" && isMovingStone == false)
        {
            interactable = collision.gameObject;
        }

        if (collision.gameObject.tag == "DragonsBreath")
        {
            GameObject.Find("CheckPointManager").GetComponent<CheckPointManager>().resetPuzzle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Pushes the player up if they are at the top of the ladder and drops the player if they are at the bottom
        if (collision.gameObject.tag == "Ladder" && isMovingStone == false)
        {
            interactable = null;
            if (isOnLadder == true && transform.position.y > collision.transform.position.y)
            {
                rb.gravityScale = 1.5f;
                rb.velocity = new Vector3(rb.velocity.x, 5f, 0);
                isOnLadder = false;
            }
            else if (isOnLadder == true && transform.position.y < collision.transform.position.y)
            {
                rb.gravityScale = 1.5f;
                isOnLadder = false;
            }
        }
        //makes the interactable null if the player leaves the catapult triggerbox
        if (collision.gameObject.tag == "Catapult" && isMovingStone == false)
        {
            interactable = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enables the player to jump again when touching the ground
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        //enables the player to jump and makes the runestone the active interactable object
        if (collision.gameObject.tag == "RuneStone" && isOnLadder == false)
        {
            isOnGround = true;
            interactable = collision.gameObject;
        }
        //enables the player to jump and makes the launchable the active interactable object
        if (collision.gameObject.tag == "Launchable" && isOnLadder == false)
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
            if (interactable.tag == "RuneStone" && isMovingStone == false)
            {
                interactable = null;
            }
        }

        if (collision.gameObject.tag == "Launchable")
        {
            if (interactable.tag == "Launchable" && isMovingStone == false)
            {
                interactable = null;
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
            if (isMovingStone == true)
            {
                Destroy(interactable.GetComponent<RuneStone>().GetDJ());
                Destroy(interactable.GetComponent<RuneStone>().GetRB());
                isMovingStone = false;
            }
        }

    }

    void createRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.mass = 0.5f;
        rb.gravityScale = 1.5f;
    }

    public bool getIsMovingStone()
    {
        return isMovingStone;
    }

    public void setIsMovingStone(bool newIsMovingStone)
    {
        isMovingStone = newIsMovingStone;
    }

    public GameObject getInteractable()
    {
        return interactable;
    }

    public void setInteractable(GameObject newInteractable)
    {
        interactable = newInteractable;
    }

    public void SetRB(Rigidbody2D newRB)
    {
        rb = newRB;
    }

    public Rigidbody2D GetRB()
    {
        return rb;
    }

    public int GetCheckPoint()
    {
        return checkPoint;
    }

    public void SetCheckPoint(int newCheckPoint)
    {
        checkPoint = newCheckPoint;
    }

}
