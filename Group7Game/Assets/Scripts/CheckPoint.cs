using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public int checkPointNum; //used to determine if the player is at this particular checkpoint
    public List<GameObject> destroyables;//used to store destroyable gameobject for reinstantiation
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        resetPuzzle();
    }

    private void resetPuzzle()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            //checks to see if player is at checkpoint and resets the player position
            if (checkPointNum == GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().checkPoint)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().rb.velocity = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;

                //resets rune stones
                foreach (GameObject runeStone in GameObject.FindGameObjectsWithTag("RuneStone"))
                {
                    if (runeStone.GetComponent<RuneStone>().checkPoint == checkPointNum)
                    {
                        runeStone.transform.position = runeStone.GetComponent<RuneStone>().getOrigonalPosition();
                    }
                }

                //resets rune stone slots
                foreach (GameObject runeStoneSlot in GameObject.FindGameObjectsWithTag("RuneStoneSlot"))
                {
                    if (runeStoneSlot.GetComponent<RuneStoneSlot>().checkPoint == checkPointNum)
                    {
                        runeStoneSlot.GetComponent<RuneStoneSlot>().activate = false;
                    }
                }

                //resets rolling stones
                foreach (GameObject RollingStone in GameObject.FindGameObjectsWithTag("RollingStone"))
                {
                    if (RollingStone.GetComponent<RollingStone>().checkPoint == checkPointNum)
                    {
                        RollingStone.GetComponent<RollingStone>().reset();
                        RollingStone.transform.position = RollingStone.GetComponent<RollingStone>().getOrigonalPosition();
                    }
                }
                //resets rotating platforms
                foreach (GameObject RotatingPlatform in GameObject.FindGameObjectsWithTag("RotatingPlatform"))
                {
                    if (RotatingPlatform.GetComponent<RotatingPlatform>().checkPoint == checkPointNum)
                    {
                        RotatingPlatform.GetComponent<RotatingPlatform>().StopRotation();
                        RotatingPlatform.transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                }

                //resets buttons
                foreach (GameObject RotatingPlatform in GameObject.FindGameObjectsWithTag("Button"))
                {
                    if (RotatingPlatform.GetComponent<Button>().checkPoint == checkPointNum)
                    {
                        RotatingPlatform.GetComponent<Button>().isRotating = false;
                    }
                }

                //resets destroyables (barriers) ect
                foreach (GameObject destroyable in destroyables)
                {
                    destroyable.SetActive(true);
                }
            }
        }
    }
}
