using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayStartMessage : MonoBehaviour {

    public GameObject startMessage;
    public float counter = 3.0f;
    bool done = true;

	// Use this for initialization
	void Start () {
               
	}
	
	// Update is called once per frame
	void Update () {
        counter -= Time.deltaTime;

        if(counter <= 0 && !done){
            Debug.Log("dest");
            startMessage.GetComponent<Text>().enabled = false;
            done = false;
        }
	}
}
