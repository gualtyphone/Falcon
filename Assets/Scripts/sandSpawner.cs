using UnityEngine;
using System.Collections;

public class sandSpawner : MonoBehaviour {

    public GameObject sand;
    public GameObject[] spawnedSand;
    public int count = 0;
	// Use this for initialization
	void Start () {
        FalconUnity.setGravity(new Vector3(0.0f, -9.0f, 0.0f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool[] buttons;
        FalconUnity.getFalconButtonStates(0, out buttons);
        if (buttons[1])
        {
            if (count < 1)
            {
                GameObject newSand = Instantiate(sand);
                newSand.transform.position = transform.position;
                count++;
            }
        }
        if (!buttons[1])
        {
            count = 0;
        }
    }
}
