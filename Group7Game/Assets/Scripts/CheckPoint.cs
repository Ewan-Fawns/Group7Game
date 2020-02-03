using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public int checkPointNum; //used to determine if the player is at this particular checkpoint
    public List<GameObject> destroyables;//used to store destroyable gameobject for reinstantiation
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        resetPuzzle();
	}

    private void resetPuzzle()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(checkPointNum == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().checkPoint)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rb.velocity = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;

                foreach (GameObject runeStone in GameObject.FindGameObjectsWithTag("RuneStone"))
                {
                    if(runeStone.GetComponent<RuneStone>().checkPoint == checkPointNum)
                    {
                        runeStone.transform.position = runeStone.GetComponent<RuneStone>().getOrigonalPosition();
                    }
                }

                foreach (GameObject runeStoneSlot in GameObject.FindGameObjectsWithTag("RuneStoneSlot"))
                {
                    if(runeStoneSlot.GetComponent<RuneStoneSlot>().checkPoint == checkPointNum)
                    {
                        runeStoneSlot.GetComponent<RuneStoneSlot>().activate = false;
                    }
                }

                foreach (GameObject destroyable in destroyables)
                {
                    destroyable.SetActive(true);
                }
            }
        }
    }
}
