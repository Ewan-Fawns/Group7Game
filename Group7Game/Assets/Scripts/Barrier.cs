using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {
    public List<GameObject> RuneStoneSlots;
    public bool isBreakable = false;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        int complete = 0;

        foreach (GameObject slot in RuneStoneSlots)
        {

            if(slot.GetComponent<RuneStoneSlot>().activate == true)
            {
                complete++;
            }
        }

        if(complete == RuneStoneSlots.Count)
        {
            gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Launchable" && isBreakable == true)
        {
            if(collision.gameObject.GetComponent<Launchable>().isFiring == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
