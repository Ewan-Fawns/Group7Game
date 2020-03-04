using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public List<GameObject> backgrounds;
    public List<GameObject> currentBackgrounds;
    private GameObject character;
    private int lastIndex = -1;
    public List<Vector3> origonalPositions;
    private float origonalX;
    // Use this for initialization
    void Start () {
        character = GameObject.Find("Character");
        origonalX = character.transform.position.x;
        Vector3 characterPos = character.transform.position - new Vector3((19.2f * 2),0,0);
        Quaternion characterRot = character.transform.rotation;
        for (int i = 0; i < 5; i++)
        {
            GameObject background = Instantiate(backgrounds[Random.Range(0, backgrounds.Count)], characterPos, characterRot);
            background.transform.position = new Vector3(background.transform.position.x + (19.2f * i), background.transform.position.y + 4, background.transform.position.z);
            currentBackgrounds.Add(background);
            origonalPositions.Add(background.transform.position);
            lastIndex++;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (character.transform.position.x >= currentBackgrounds[lastIndex].transform.position.x - 19.2f)
        {
            Vector3 backgroundPos = currentBackgrounds[lastIndex].transform.position + new Vector3(19.2f,0, 0);
            Quaternion backgroundRot = currentBackgrounds[lastIndex].transform.rotation;
            GameObject background = Instantiate(backgrounds[Random.Range(0, backgrounds.Count)], backgroundPos, backgroundRot);
            currentBackgrounds.Add(background);
            origonalPositions.Add(background.transform.position);
            lastIndex++;
        }
        if (character.transform.position.x <= currentBackgrounds[0].transform.position.x + 19.2f)
        {
            Vector3 backgroundPos = currentBackgrounds[0].transform.position + new Vector3(-19.2f, 0, 0);
            Quaternion backgroundRot = currentBackgrounds[0].transform.rotation;
            GameObject background = Instantiate(backgrounds[Random.Range(0, backgrounds.Count)], backgroundPos, backgroundRot);
            currentBackgrounds.Insert(0, background);
            origonalPositions.Insert(0, background.transform.position);
            lastIndex++;
        }
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < currentBackgrounds.Count; i++)
        {
            currentBackgrounds[i].transform.position = origonalPositions[i] + new Vector3(origonalX - (character.transform.position.x/15),0,0);
        }
    }
    
}
