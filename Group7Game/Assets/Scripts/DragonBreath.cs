using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DragonBreath : MonoBehaviour {
    public float speed;
    public float timeInterval;
    private float timePassed = 0;
    public float stopShake;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timePassed >= timeInterval)
        {
            transform.position = new Vector3(GameObject.Find("Character").transform.position.x + 30, GameObject.Find("Character").transform.position.y + 18, 0);
            timePassed = 0;
            CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.5f;
            
        }
        if (timePassed >= stopShake)
        {
            CinemachineVirtualCamera vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        }
        timePassed += Time.deltaTime;
	}

    private void FixedUpdate()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }

    public void resetTime()
    {
        timePassed = 0;
    }

}
