using UnityEngine;
using System.Collections;

public class falconSetupperSculpting : MonoBehaviour {

    GameObject FalconWaypoint;
    GameObject MainFalcon;
    
	// Use this for initialization
	void Start () {
        FalconWaypoint = GameObject.Find("FalconWaypoint");
        MainFalcon = GameObject.Find("Falcon 1");

        MainFalcon.transform.position = FalconWaypoint.transform.position;

        MainFalcon.GetComponent<moveAround>().enabled = true;
        MainFalcon.GetComponent<FalconDistanceMainMenu>().enabled = false;
        MainFalcon.GetComponentInChildren<RecordPreviousPos>().enabled = false;
        MainFalcon.GetComponentInChildren<moevMeshHandle>().enabled = true;
        foreach (Transform child in MainFalcon.transform)
        {
            if (child.gameObject.name == "FalconShape")
            {
                Debug.Log("FOUND");
                child.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
