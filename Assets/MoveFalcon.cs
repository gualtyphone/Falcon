using UnityEngine;
using System.Collections;

public class MoveFalcon : MonoBehaviour {

    public GameObject Falcon;
    public Vector3 vec;

	// Use this for initialization
	void Start () {
        //vec = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (Input.mousePosition + vec) / 50;
	}
}
