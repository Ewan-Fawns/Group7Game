using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public List<GameObject> backgrounds;
    private List<GameObject> currentBackgrounds;

	// Use this for initialization
	void Start () {
        GameObject character = GameObject.Find("Character");
        Instantiate(backgrounds[0], character.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
