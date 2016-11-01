using UnityEngine;
using System.Collections;

public class onLevelLoad : MonoBehaviour {

    public GameObject Screen;
    public Vector3 endPos;

	// Use this for initialization
	void Start () {
            
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(transform.position, endPos, (0.5f * Time.deltaTime));
         
        
	}
}
