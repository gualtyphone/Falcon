using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelLoad : MonoBehaviour {

    public string level;
    public float waitTime = 1;

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
            Debug.Log(1);
        }

    }
}
