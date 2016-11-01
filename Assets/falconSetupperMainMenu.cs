using UnityEngine;
using System.Collections;

public class falconSetupperMainMenu : MonoBehaviour {

    GameObject FalconWaypoint;
    GameObject MainFalcon;
    GameObject holder;

    // Use this for initialization
    void Start () {
        FalconWaypoint = GameObject.Find("FalconWaypoint");
        MainFalcon = GameObject.Find("Falcon 1");
        holder = GameObject.Find("holder");
        
        holder.SetActive(false);

        MainFalcon.transform.position = FalconWaypoint.transform.position;

        MainFalcon.GetComponent<moveAround>().enabled = false;
        MainFalcon.GetComponent<FalconDistanceMainMenu>().enabled = true;
        MainFalcon.GetComponentInChildren<RecordPreviousPos>().enabled = false;
        MainFalcon.GetComponentInChildren<moevMeshHandle>().enabled = false;
        foreach (Transform child in MainFalcon.transform)
        {
            if (child.gameObject.name == "FalconShape")
            {
                Debug.Log("FOUND");
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        FalconWaypoint = GameObject.Find("FalconWaypoint");
        MainFalcon = GameObject.Find("Falcon 1");
        

        MainFalcon.transform.position = FalconWaypoint.transform.position;

        MainFalcon.GetComponent<moveAround>().enabled = false;
        MainFalcon.GetComponent<FalconDistanceMainMenu>().enabled = true;
        MainFalcon.GetComponentInChildren<RecordPreviousPos>().enabled = false;
        MainFalcon.GetComponentInChildren<moevMeshHandle>().enabled = false;
        foreach (Transform child in MainFalcon.transform)
        {
            if (child.gameObject.name == "FalconShape")
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
