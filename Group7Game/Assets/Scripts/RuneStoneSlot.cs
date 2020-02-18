using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStoneSlot : MonoBehaviour
{
    public int identifier = 0; //identifier used to check if the rune stone is associated with the rune stone slot
    private bool activate = false; //Used for activating functionality to the attached objects.
    public int checkPoint = 0; //Used to identify which checkpoint is associated with this rune stone slot
    // Use this for initialization
   void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool GetActivate()
    {
        return activate;
    }

    public void SetActivate(bool newActivate)
    {
        activate = newActivate;
    }
}
