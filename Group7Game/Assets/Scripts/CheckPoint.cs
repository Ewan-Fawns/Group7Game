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
            if(checkPointNum == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetCheckPoint())
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetRB().velocity = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;

                foreach (GameObject runeStone in GameObject.FindGameObjectsWithTag("RuneStone"))
                {
                    if(runeStone.GetComponent<RuneStone>().checkPoint == checkPointNum)
                    {
                        
                        runeStone.transform.position = runeStone.GetComponent<RuneStone>().getOrigonalPosition();
                        runeStone.GetComponent<DraggedObject>().DestroyRB();
                        runeStone.GetComponent<DraggedObject>().CreateRB();
                    }
                }

                foreach (GameObject runeStoneSlot in GameObject.FindGameObjectsWithTag("RuneStoneSlot"))
                {
                    if(runeStoneSlot.GetComponent<RuneStoneSlot>().checkPoint == checkPointNum)
                    {
                        runeStoneSlot.GetComponent<RuneStoneSlot>().SetActivate(false);
                    }
                }

                foreach (GameObject rotatingPlatform in GameObject.FindGameObjectsWithTag("RotatingPlatform"))
                {
                    if (rotatingPlatform.GetComponent<RotatingPlatform>().checkPoint == checkPointNum)
                    {

                        rotatingPlatform.transform.Rotate(-rotatingPlatform.transform.rotation.eulerAngles);
                        //if(rotatingPlatform.transform.rotation.eulerAngles.z > 0)
                        //{
                        //    rotatingPlatform.transform.Rotate();
                        //}else
                        //{
                        //    rotatingPlatform.transform.Rotate()
                        //}

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
