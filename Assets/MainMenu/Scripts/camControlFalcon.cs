using UnityEngine;
using System.Collections;

public class camControlFalcon : MonoBehaviour {

    public GameObject GodObj;
    Vector3 oldPos;
    public float minFov = 25f;
    public float maxFov;

	// Use this for initialization
	void Start () {
        GodObj = GameObject.Find("GodObject");
        maxFov = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;
        FalconUnity.getGodPosition(0, out pos);
	    transform.LookAt(pos, Vector3.up);
        /*if(Camera.main.fieldOfView != maxFov && oldPos.z < pos.z) {
               
               Camera.main.fieldOfView--;
        }
        else if(Camera.main.fieldOfView != minFov && oldPos.z > pos.z)
        {

            Camera.main.fieldOfView++;
        }
        oldPos = pos;*/
    }
}
