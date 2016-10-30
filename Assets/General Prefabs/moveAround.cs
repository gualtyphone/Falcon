using UnityEngine;
using System.Collections;

public class moveAround : MonoBehaviour {

    GameObject Camera;

    // Use this for initialization
    void Start () {
        Camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+0.5f), 0.1f);
            Camera.transform.RotateAround(transform.position, new Vector3(1.0f, 0.0f, 0.0f), 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), 0.1f);
            Camera.transform.RotateAround(transform.position, new Vector3(1.0f, 0.0f, 0.0f), -0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z ), 0.1f);
            Camera.transform.RotateAround(transform.position, new Vector3(0.0f, 1.0f, 0.0f), 0.5f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D is pressed");
            //this.gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), 0.1f);
            Camera.transform.RotateAround(transform.position, new Vector3(0.0f, 1.0f, 0.0f), -0.5f);
        }
        Camera.transform.LookAt(transform.position, Vector3.up);
        
    }
}
