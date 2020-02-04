using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : MonoBehaviour {
    public Vector3 origonalLocation;
    public Rigidbody2D rb;
    public int checkPoint = 0;

    // Use this for initialization
    void Start () {
        origonalLocation = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
    }

    public Vector3 getOrigonalPosition()
    {
        return origonalLocation;
    }

    public void reset()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        print("nope");
    }
}
