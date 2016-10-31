using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelLoad : MonoBehaviour {

    public SphereManipulator falc;
    public int level;
    public float waitTime = 1;
    bool wait = false;
    float waitTim2 = 4;

    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (waitTime > 0)
        {

            waitTime -= Time.deltaTime;

        }     
	}

    void OnTriggerEnter() {

        if (waitTime <= 0)
        {
            Application.LoadLevel(level);
        }

    }

}
