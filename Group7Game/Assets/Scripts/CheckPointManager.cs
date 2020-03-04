using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        checkReset();
    }

    private void checkReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetPuzzle();
        }
    }

    public void resetPuzzle()
    {
        foreach (GameObject checkPoint in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {


            if (checkPoint.GetComponent<CheckPoint>().checkPointNum == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetCheckPoint())
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetRB().velocity = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Player").transform.position = checkPoint.transform.position;
                GameObject.FindGameObjectWithTag("DragonsBreath").GetComponent<DragonBreath>().resetTime();
                foreach (GameObject runeStone in GameObject.FindGameObjectsWithTag("RuneStone"))
                {
                    if (runeStone.GetComponent<RuneStone>().checkPoint == checkPoint.GetComponent<CheckPoint>().checkPointNum)
                    {
                        if (runeStone.GetComponent<DraggedObject>().GetRB() != null)
                        {
                            runeStone.GetComponent<DraggedObject>().DestroyRB();
                        }

                        runeStone.GetComponent<DraggedObject>().afterFrame = true;
                        runeStone.transform.position = runeStone.GetComponent<RuneStone>().getOrigonalPosition();

                    }
                }

                foreach (GameObject runeStoneSlot in GameObject.FindGameObjectsWithTag("RuneStoneSlot"))
                {
                    if (runeStoneSlot.GetComponent<RuneStoneSlot>().checkPoint == checkPoint.GetComponent<CheckPoint>().checkPointNum)
                    {
                        runeStoneSlot.GetComponent<RuneStoneSlot>().SetActivate(false);
                    }
                }

                foreach (GameObject rotatingPlatform in GameObject.FindGameObjectsWithTag("RotatingPlatform"))
                {
                    if (rotatingPlatform.GetComponent<RotatingPlatform>().checkPoint == checkPoint.GetComponent<CheckPoint>().checkPointNum)
                    {

                        rotatingPlatform.transform.Rotate(-rotatingPlatform.transform.rotation.eulerAngles);
                    }
                }

                foreach (GameObject destroyable in checkPoint.GetComponent<CheckPoint>().destroyables)
                {
                    destroyable.SetActive(true);
                }
                

            }
        }
    }
}
