using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class winGame : MonoBehaviour {

    public GameObject endMessage;
    public float counter = 2.0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;
        FalconUnity.getGodPosition(0, out pos);
        if (GetComponent<Collider>().bounds.Contains(pos))
        {
            Debug.Log("Win");
            endMessage.GetComponent<Text>().enabled = true;
            endMessage.GetComponent<Text>().text = "You Win!!!";
        }
	}

    void OnTriggerEnter()
    {
       Debug.Log("Win");
       endMessage.GetComponent<Text>().enabled = true;
        endMessage.GetComponent<Text>().text = "You Win!!!";
    }
}
