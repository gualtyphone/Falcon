﻿using UnityEngine;
using System.Collections;

public class MoveFalconWithMouse : MonoBehaviour {

    public GameObject Falcon;
    public Vector3 vec;

	// Use this for initialization
	void Start () {
        //vec = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (new Vector3(Input.mousePosition.x + -650, Input.mousePosition.y + -150, Falcon.transform.position.z)) / 50;
	}
}
