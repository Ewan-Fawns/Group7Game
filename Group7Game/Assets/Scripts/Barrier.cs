using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {
    public GameObject attachedRuneStone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //destroys the barrier once the rune stot has been filled
		if(attachedRuneStone.GetComponent<RuneStoneSlot>().activate == true)
        {
            Destroy(gameObject);
        }
	}
}
