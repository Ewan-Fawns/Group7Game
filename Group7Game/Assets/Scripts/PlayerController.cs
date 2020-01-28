using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;


	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
        Moveplayer();
	}

    void Moveplayer()
    {
        if(Input.GetKeyDown("space"))
        {

        }
    }
}
