using UnityEngine;
using System.Collections;

public class moevMeshHandle : MonoBehaviour {

    public bool[] buttons;
    public bool objSelected = false;
    public bool justPressed = false;
    public GameObject canvas;
    public float rangeSqr = 0.1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
        FalconUnity.getFalconButtonStates(0, out buttons);

        if (!objSelected && !justPressed)
        {
            foreach (GameObject handle in handles)
            {
                Vector3 pos;
                FalconUnity.getGodPosition(0, out pos);
                //Debug.Log("handleEEEE");
                float distanceSqr = (pos - handle.transform.position).sqrMagnitude;
                if (distanceSqr < rangeSqr /*GetComponent<Collider>().bounds.Contains(handle.transform.position)*/ && buttons[0])
                {
                    Debug.Log("handleEEEE");
                    handle.GetComponent<selectedHandle>().selected = true ;
                    justPressed = true;
                    objSelected = true;
                }
            }
        }

        if (objSelected)
        {
            foreach (GameObject handle in handles)
            {
                if (handle.GetComponent<selectedHandle>().selected == true)
                {
                    Vector3 pos;
                    FalconUnity.getGodPosition(0, out pos);
                    handle.transform.position = pos;
                }
            }
            //Don't try this because the falcon fucks up tremendously
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
        
        if (objSelected && buttons[0] && !justPressed)
        {
            objSelected = false;
            foreach (GameObject handle in handles)
            {
                handle.GetComponent<selectedHandle>().selected = false;
            }
            justPressed = true;
            //canvas.GetComponent<FalconRigidBody>().refreshShape();
        }

        if (!buttons[0]  && justPressed)
        {
            justPressed = false;
        }
        if (buttons[1])
        {
            canvas.GetComponent<FalconRigidBody>().disableShape();
        }
        if (buttons[2])
        {
            canvas.GetComponent<FalconRigidBody>().refreshShape();
        }
    }
}
