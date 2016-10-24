using UnityEngine;
using System.Collections;

public class moveAround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+0.5f), 0.1f);
            if (transform.rotation.x < 85.0f)
            transform.Rotate(new Vector3(0.1f, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z ), 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), 0.1f);
        }
    }
}
